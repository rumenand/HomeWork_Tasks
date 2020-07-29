using AutoMapper;
using ProductShop.Dtos.Import;
using ProductShop.Dtos.Export;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ProductImportDTO, Product>();
            this.CreateMap<Product, ProductExportDTO>()
                .ForMember(x => x.BuyerFullName, y => y.MapFrom(z => z.Buyer.FirstName + " " + z.Buyer.LastName));
            this.CreateMap<User, UsersExportDTO>()
                .ForMember(x => x.soldProducts, y => y.MapFrom(z => z.ProductsSold
                         .Select(p => new ProductDto
                         {
                             Name = p.Name,
                             Price = p.Price
                         })));
            this.CreateMap<Category, CategoryExportDTO>()
                .ForMember(x => x.Count, y => y.MapFrom(z => z.CategoryProducts.Count))
                .ForMember(x => x.AveragePrice, y => y.MapFrom(z => (double)z.CategoryProducts.Average(p => p.Product.Price)))
                .ForMember(x => x.TotalRevenue, y => y.MapFrom(z => (double)z.CategoryProducts.Sum(p => p.Product.Price)));
        }
    }
}
