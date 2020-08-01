using AutoMapper;
using AutoMapper.QueryableExtensions;

using PetStore.Common;
using PetStore.Data;
using PetStore.Models;
using PetStore.ServiceModels.Breeds;
using PetStore.Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStore.Services
{
    public class BreedService : IBreedService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public BreedService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddBreed(BreedServiceModel model)
        {
            try
            {
                Breed breed = this.mapper.Map<Breed>(model);

                this.dbContext.Breeds.Add(breed);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new ArgumentException(ExceptionMessages.InvalidBreed);
            }
        }

        public ICollection<BreedServiceModel> GetAll()
        {
            var breeds = this.dbContext
              .Breeds
              .ProjectTo<BreedServiceModel>(this.mapper.ConfigurationProvider)
              .ToList();

            return breeds;
        }
        public void EditBreed(string id, BreedServiceModel model)
        {
            Breed breed = this.mapper.Map<Breed>(model);

            Breed breedToUpdate = this.dbContext
                .Breeds
                .Find(id);

            if (breedToUpdate == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidBreed);
            }
            breedToUpdate.Name = breed.Name;

            this.dbContext.SaveChanges();
        }
        public bool RemoveById(string id)
        {
            Breed breedToRemove = this.dbContext
                .Breeds
                .Find(int.Parse(id));

            if (breedToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidBreed);
            }

            this.dbContext.Breeds.Remove(breedToRemove);
            int rowsAffected = this.dbContext.SaveChanges();

            bool wasDeleted = rowsAffected == 1;

            return wasDeleted;
        }
    }
}
