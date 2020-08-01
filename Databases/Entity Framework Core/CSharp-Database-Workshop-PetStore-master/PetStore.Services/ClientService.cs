
using AutoMapper;
using AutoMapper.QueryableExtensions;

using PetStore.Common;
using PetStore.Data;
using PetStore.Models;
using PetStore.ServiceModels.Clients.InputModels;
using PetStore.ServiceModels.Clients.OutputModels;
using PetStore.Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStore.Services
{
    public class ClientService : IClientService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public ClientService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public void AddClient(AddCLientInputServiceModel model)
        {
            try
            {
                var client = this.mapper.Map<Client>(model);

                this.dbContext.Clients.Add(client);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new ArgumentException(ExceptionMessages.InvalidClient);
            }
        }

        public void EditClient(string id, EditClientInputServiceModel model)
        {
            var client = this.mapper.Map<Client>(model);

            var clientToUpdate = this.dbContext
                .Clients
                .Find(id);

            if (clientToUpdate == null)
            {
                throw new ArgumentException(ExceptionMessages.ProductNotFound);
            }
            clientToUpdate.Username = client.Username;
            clientToUpdate.Password = client.Password;
            clientToUpdate.Email = client.Email;
            clientToUpdate.FirstName = client.FirstName;
            clientToUpdate.LastName = client.LastName;

            this.dbContext.SaveChanges();
        }

        public ICollection<ListAllClientsServiceModel> GetAll()
        {
            var client = this.dbContext
               .Clients
               .ProjectTo<ListAllClientsServiceModel>(this.mapper.ConfigurationProvider)
               .ToList();

            return client;
        }

        public ClientDetailsServiceModel GetById(string id)
        {
            var clientForDetails = this.dbContext
               .Clients
               .FirstOrDefault(p => p.Id == id);
            return this.mapper.Map<ClientDetailsServiceModel>(clientForDetails);
        }

        public bool RemoveById(string id)
        {
            var clientToRemove = this.dbContext
              .Clients
              .Find(id);

            if (clientToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidClient);
            }

            this.dbContext.Clients.Remove(clientToRemove);
            int rowsAffected = this.dbContext.SaveChanges();

            bool wasDeleted = rowsAffected == 1;

            return wasDeleted;
        }
    }
}
