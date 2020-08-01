
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PetStore.Common;
using PetStore.Data;
using PetStore.Models;
using PetStore.ServiceModels.Orders.InputModels;
using PetStore.ServiceModels.Orders.OutputModels;
using PetStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStore.Services
{
    public class OrderService : IOrderService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public OrderService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public void AddOrder(AddOrderInputServiceModel model)
        {
            try
            {
                var order = this.mapper.Map<Order>(model);

                this.dbContext.Orders.Add(order);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new ArgumentException(ExceptionMessages.InvalidOrder);
            }
        }

        public void EditOrder(string id, EditOrdertInputServiceModel model)
        {
            var order = this.mapper.Map<Order>(model);

            var orderToUpdate = this.dbContext
                .Orders
                .Find(id);

            if (orderToUpdate == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidOrder);
            }
            orderToUpdate.Town = order.Town;
            orderToUpdate.Address = order.Address;
            orderToUpdate.Notes = order.Notes;

            this.dbContext.SaveChanges();
        }

        public ICollection<ListAllOrdersServiceModel> GetAll()
        {
            var orders = this.dbContext
                 .Orders
                 .ProjectTo<ListAllOrdersServiceModel>(this.mapper.ConfigurationProvider)
                 .ToList();

            return orders;
        }

        public bool RemoveById(string id)
        {
            var orderToRemove = this.dbContext
                .Orders
                .Find(id);

            if (orderToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidOrder);
            }

            this.dbContext.Orders.Remove(orderToRemove);
            int rowsAffected = this.dbContext.SaveChanges();

            bool wasDeleted = rowsAffected == 1;

            return wasDeleted;
        }
    }
}
