using System;
using AutoMapper;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;
using PetStore.ViewModels.Product.OutputModels;
using PetStore.ViewModels.Product.InputModels;
using PetStore.ViewModels.Product;

namespace PetStore.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<AddProductInputServiceModel, Product>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => Enum.Parse(typeof(ProductType), x.ProductType)));
            this.CreateMap<Product, ListAllProductsByProductTypeServiceModel>();
            this.CreateMap<Product, ListAllProductsServiceModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => x.ProductType.ToString()));
            this.CreateMap<Product, ListAllProductsByNameServiceModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => x.ProductType.ToString()));
            this.CreateMap<EditProductInputServiceModel, Product>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => Enum.Parse(typeof(ProductType), x.ProductType)));
            this.CreateMap<Product, ProductDetailsServiceModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => x.ProductType.ToString()));
            this.CreateMap<CreateProductInputModel, AddProductInputServiceModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => x.ProductType.ToString()));
            this.CreateMap<ListAllProductsServiceModel, ListAllProductsViewModel>()
                .ForMember(x => x.ProductId, y => y.MapFrom(x => x.Id));
            this.CreateMap<ListAllProductsByNameServiceModel, ListAllProductsViewModel>()
                .ForMember(x => x.ProductId, y => y.MapFrom(x => x.Id));
            this.CreateMap<ProductDetailsServiceModel, ProductDetailsViewModel>()
                .ForMember(x => x.Price, y => y.MapFrom(x => x.Price.ToString()));
            this.CreateMap<ProductDetailsServiceModel, ProductEditViewModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => Enum.Parse(typeof(ProductType), x.ProductType)));
            this.CreateMap<ProductEditViewModel, EditProductInputServiceModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => x.ProductType.ToString()));
        }
    }
}
