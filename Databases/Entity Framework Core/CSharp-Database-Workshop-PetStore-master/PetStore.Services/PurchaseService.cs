
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PetStore.Common;

using PetStore.Data;
using PetStore.Models;
using PetStore.ServiceModels.Purchases.InputModels;
using PetStore.ServiceModels.Purchases.OutputModels;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStore.Services
{
    public class PurchaseService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public PurchaseService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public void BuyProduct(PurchaseInputServiceModel model)
        {
           
            try
            {
                var clientProduct = this.mapper.Map<ClientProduct>(model);

                this.dbContext.ClientProducts.Add(clientProduct);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPurchase);
            }
        }
        public List<ClientPurchaseServiceModel> GetClientsPurchases(string clientId)
        {
            var purchases = this.dbContext.ClientProducts
                            .Where(x => x.Client.Id == clientId)
                            .ProjectTo<ClientPurchaseServiceModel>(this.mapper.ConfigurationProvider)
                            .ToList();

            return purchases;
        }
    }
}
