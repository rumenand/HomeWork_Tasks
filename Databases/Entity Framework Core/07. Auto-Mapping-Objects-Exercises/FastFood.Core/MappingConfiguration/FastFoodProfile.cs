namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Models;
    using ViewModels.Positions;
    using ViewModels.Categories;
    using ViewModels.Employees;
    using ViewModels.Items;
    using ViewModels.Orders;
    using System;
    using FastFood.Models.Enums;
    using System.Globalization;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Category
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.CategoryName));
            this.CreateMap<Category, CategoryAllViewModel>();

            //Positions
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionId, y => y.MapFrom(z => z.Id))
                .ForMember(x=>x.PositionName,y => y.MapFrom(z=>z.Name));
            this.CreateMap<RegisterEmployeeInputModel, Employee>();
            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x => x.Position, y => y.MapFrom(z => z.Position.Name));

            //Items

            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(z => z.Id));
            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x=>x.Category,y=>y.MapFrom(z=>z.Category.Name));
            this.CreateMap<CreateItemInputModel, Item>();

            //Orders
            this.CreateMap<CreateOrderInputModel, Order>()
                .ForMember(x => x.DateTime, y => y.MapFrom(x => DateTime.UtcNow))
                .ForMember(x => x.Type, y => y.MapFrom(x => OrderType.ToGo));
            this.CreateMap<CreateOrderInputModel, OrderItem>();

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(x => x.Employee, y => y.MapFrom(z => z.Employee.Name))
                .ForMember(x => x.DateTime, y => y.MapFrom(z => z.DateTime.ToString("D", CultureInfo.InvariantCulture)))
                .ForMember(x=>x.OrderId,y=>y.MapFrom(z=>z.Id));

        }
    }
}
