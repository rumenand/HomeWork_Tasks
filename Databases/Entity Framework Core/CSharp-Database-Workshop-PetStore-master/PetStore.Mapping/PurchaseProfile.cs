
using AutoMapper;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.ServiceModels.Purchases.InputModels;
using PetStore.ServiceModels.Purchases.OutputModels;
using System;

namespace PetStore.Mapping
{
    public class PurchaseProfile : Profile
    {
        public PurchaseProfile()
        {
            this.CreateMap<PurchaseInputServiceModel, ClientProduct>()
                .ForMember(x => x.ClientId, y => y.MapFrom(x => x.Client.Id))
                .ForMember(x => x.ProductId, y => y.MapFrom(x => x.Product.Id));

            this.CreateMap<ClientProduct, ClientPurchaseServiceModel>()
                .ForMember(x => x.ProductName, y => y.MapFrom(x => x.Product.Name))
                .ForMember(x => x.ProductType, y => y.MapFrom(x => x.Product.ProductType.ToString()))
                .ForMember(x => x.Price, y => y.MapFrom(x => x.Product.Price));
        }
    }
}
