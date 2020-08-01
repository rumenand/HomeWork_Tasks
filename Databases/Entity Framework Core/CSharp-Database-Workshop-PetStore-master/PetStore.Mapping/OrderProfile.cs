using AutoMapper;

using PetStore.Models;
using PetStore.ServiceModels.Orders.InputModels;
using PetStore.ServiceModels.Orders.OutputModels;

namespace PetStore.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            this.CreateMap<AddOrderInputServiceModel, Order>();
            this.CreateMap<Order, ListAllOrdersServiceModel>();
            this.CreateMap<EditOrdertInputServiceModel, Order>();
        }
    }
}
