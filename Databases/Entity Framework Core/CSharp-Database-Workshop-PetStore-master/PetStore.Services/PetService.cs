using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using PetStore.Common;
using PetStore.Data;
using PetStore.Models;
using PetStore.ServiceModels.Pets.InputModels;
using PetStore.ServiceModels.Pets.OutputModels;
using PetStore.Services.Interfaces;

namespace PetStore.Services
{
    public class PetService : IPetService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public PetService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public void AddPet(AddPetInputServiceModel model)
        {
            try
            {
                Pet pet = this.mapper.Map<Pet>(model);

                this.dbContext.Pets.Add(pet);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPet);
            }
        }


        public ICollection<ListAllPetsServiceModel> GetAll()
        {
            var pets = this.dbContext
               .Pets
               .ProjectTo<ListAllPetsServiceModel>(this.mapper.ConfigurationProvider)
               .ToList();

            return pets;
        }

      
    }
}
