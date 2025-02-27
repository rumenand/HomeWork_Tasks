﻿using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniORM
{
	public abstract class DbContext
	{
		private readonly DatabaseConnection connection;
		private readonly Dictionary<Type, PropertyInfo> dbSetProperties;

		internal static readonly Type[] AllowedSqlTypes =
		{
			typeof(string),
			typeof(int),
			typeof(uint),
			typeof(long),
			typeof(ulong),
			typeof(decimal),
			typeof(bool),
			typeof(DateTime)
		};

		protected DbContext(string connectionString)
		{
			this.connection = new DatabaseConnection(connectionString);
			this.dbSetProperties = this.DiscoverDbSets();
			using(new ConnectionManager(connection))
			{
				this.InitializeDbSets();
			}
			this.MapAllRelations();
		}

		public void SaveChanges()
		{
			var dbSets = this.dbSetProperties
				.Select(pi => pi.Value.GetValue(this))
				.ToArray();
			foreach (IEnumerable<object> dbSet in dbSets)
			{
				var invalidEntites = dbSet.Where(entity => !IsObjectValid(entity)).ToArray();
				if (invalidEntites.Any())
				{
					throw new InvalidOperationException(
						$"{invalidEntites.Length} Invalid Entities found in {dbSet.GetType().Name}");
				}
			}
			using (new ConnectionManager(connection))
			{
				using (var transaction = this.connection.StartTransaction())
				{
					foreach (IEnumerable<object> dbSet in dbSets)
					{
						var dbSetType = dbSet.GetType().GetGenericArguments().First();
						var persistMethod = typeof(DbContext).GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic)
							.MakeGenericMethod(dbSetType);
						try
						{
							persistMethod.Invoke(this, new object[] { dbSet });
						}
						catch (TargetInvocationException tie)
						{
							throw tie.InnerException;
						}
						catch (InvalidOperationException)
						{
							transaction.Rollback();
							throw;
						}
						catch (SqlException)
						{
							transaction.Rollback();
							throw;
						}						
					}
					transaction.Commit();
				}
			}			
		}
		private void Persist<TEntity>(DbSet<TEntity> dbSet)
			where TEntity : class, new()
		{
			var tableName = GetTableName(typeof(TEntity));
			var columns = this.connection.FetchColumnNames(tableName).ToArray();
			if (dbSet.ChangeTracker.Added.Any())
			{
				this.connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
			}
			var modifiedEntities = dbSet.ChangeTracker.GetModifiedEntities(dbSet).ToArray();
			if (modifiedEntities.Any())
			{
				this.connection.UpdateEntities(modifiedEntities, tableName, columns);
			}
			if (dbSet.ChangeTracker.Removed.Any())
			{
				this.connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
			}
		}
		private void InitializeDbSets()
		{
			foreach (var dbSet in this.dbSetProperties)
			{
				var dbSetType = dbSet.Key;
				var dbSetProperty = dbSet.Value;
				var populateDbSetGeneric = typeof(DbContext)
					.GetMethod("PopulateDbSet", BindingFlags.Instance | BindingFlags.NonPublic)
					.MakeGenericMethod(dbSetType);
				populateDbSetGeneric.Invoke(this, new object[] { dbSetProperty });
			}
		}
		private void PopulateDbSet<TEntity>(PropertyInfo dbSet)
			where TEntity : class, new()
		{
			var entities = LoadTableEntities<TEntity>();
			var dbSetInstance = new DbSet<TEntity>(entities);
			ReflectionHelper.ReplaceBackingField(this, dbSet.Name, dbSetInstance);
		}
		private void MapAllRelations()
		{
			foreach (var dbSetProperty in this.dbSetProperties)
			{
				var dbSetType = dbSetProperty.Key;
				var mapRelationsGeneric = typeof(DbContext)
					.GetMethod("MapRelations", BindingFlags.Instance | BindingFlags.NonPublic)
					.MakeGenericMethod(dbSetType);
				var dbSet = dbSetProperty.Value.GetValue(this);
				mapRelationsGeneric.Invoke(this, new[] { dbSet });
			}
		}
		private void MapRelations<TEntity>(DbSet<TEntity> dbSet)
			where TEntity : class, new()
		{
			var entityType = typeof(TEntity);
			MapNavigationProperties(dbSet);
			var collections = entityType.GetProperties()
				.Where(pi => pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
				.ToArray();
			foreach (var collection in collections)
			{
				var collectionType = collection.PropertyType.GenericTypeArguments.First();
				var mapCollectionMethod = typeof(DbContext)
					.GetMethod("MapCollection", BindingFlags.Instance | BindingFlags.NonPublic)
					.MakeGenericMethod(entityType, collectionType);
				mapCollectionMethod.Invoke(this, new object[] { dbSet, collection });
			}
		}
		private void MapCollection<TDbSet, TCollection>(DbSet<TDbSet> dbSet,PropertyInfo collectionProperty)
			where TDbSet : class,new() where TCollection : class, new()
		{
			var entityType = typeof(TDbSet);
			var collectionType = typeof(TCollection);
			var primaryKeys = collectionType.GetProperties()
				.Where(pi => pi.HasAttribute<KeyAttribute>())
				.ToArray();
			var primaryKey = primaryKeys.First();
			var foreignKey = entityType.GetProperties()
				.First(pi => pi.HasAttribute<KeyAttribute>());
			var isManyToMany = primaryKeys.Length >= 2;
			if(isManyToMany)
			{
				primaryKey = collectionType.GetProperties()
					.First(pi => collectionType
					.GetProperty(pi.GetCustomAttribute<ForeignKeyAttribute>().Name)
					.PropertyType == entityType);
			}
			var navigationDbSet = (DbSet<TCollection>) this.dbSetProperties[collectionType].GetValue(this);
			foreach (var entity in dbSet)
			{
				var primaryKeyValue = foreignKey.GetValue(entity);
				var navigationEntities = navigationDbSet
					.Where(navEntity => primaryKey.GetValue(navEntity).Equals(primaryKeyValue))
					.ToArray();
				ReflectionHelper.ReplaceBackingField(entity, collectionProperty.Name, navigationEntities);
			}
		}
		private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSet)
			where TEntity : class, new()
		{
			var entityType = typeof(TEntity);
			var foreignKeys = entityType.GetProperties()
				.Where(pi => pi.HasAttribute<ForeignKeyAttribute>())
				.ToArray();
			foreach (var fKey in foreignKeys)
			{
				var navPropName = fKey.GetCustomAttribute<ForeignKeyAttribute>().Name;
				var navProp = entityType.GetProperty(navPropName);
				var navDbSet = this.dbSetProperties[navProp.PropertyType].GetValue(this);
				var navPKey = navProp.PropertyType.GetProperties().First(pi => pi.HasAttribute<KeyAttribute>());
				foreach (var entity in dbSet)
				{
					var fKeyValue = fKey.GetValue(entity);
					var navPropValue = ((IEnumerable<object>)navDbSet)
						.First(cNavProp => navPKey.GetValue(cNavProp).Equals(fKeyValue));
					navProp.SetValue(entity, navPropValue);
				}
			}
		}
		private static bool IsObjectValid(object e)
		{
			var validationContex = new ValidationContext(e);
			var validationErrors = new List<ValidationResult>();
			var validationResult = Validator.TryValidateObject(e, validationContex, validationErrors, validateAllProperties: true);
			return validationResult;
		}

		private IEnumerable<TEntity> LoadTableEntities<TEntity>()
			where TEntity : class
		{
			var table = typeof(TEntity);
			var columns = GetEntityColumnNames(table);
			var tableName = GetTableName(table);
			var fetchedRows = this.connection.FetchResultSet<TEntity>(tableName, columns).ToArray();
			return fetchedRows;
		}
		private string GetTableName(Type tableType)
		{
			var tableName = ((TableAttribute)Attribute.GetCustomAttribute(tableType,typeof(TableAttribute)))?.Name;
			if (tableName == null)
			{
				tableName = this.dbSetProperties[tableType].Name;
			}
			return tableName;
		}
		private Dictionary<Type,PropertyInfo>DiscoverDbSets()
		{
			var dbSets = this.GetType().GetProperties()
				.Where(pi => pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
				.ToDictionary(pi => pi.PropertyType.GetGenericArguments().First(), pi => pi);
			return dbSets;
		}
		private string[] GetEntityColumnNames(Type table)
		{
			var tableName = this.GetTableName(table);
			var dbColumns = this.connection.FetchColumnNames(tableName);
			var columns = table.GetProperties()
				.Where(pi => dbColumns.Contains(pi.Name) &&
				!pi.HasAttribute<NotMappedAttribute>() &&
				AllowedSqlTypes.Contains(pi.PropertyType))
				.Select(pi => pi.Name)
				.ToArray();
			return columns;
		}
	}
}