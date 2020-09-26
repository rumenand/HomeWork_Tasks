namespace CarDealer
{
    using AutoMapper;

    using CarDealer.Dtos.Import;
    using CarDealer.Dtos.Export;
    using CarDealer.Models;
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupllierImportDTO, Supplier>();
            this.CreateMap<PartImportDTO, Part>();
            this.CreateMap<CarImportDTO, Car>()
                .ForMember(x => x.TravelledDistance, y => y.MapFrom(x => x.TraveledDistance));
            this.CreateMap<CustomerImportDTO, Customer>();
            this.CreateMap<SaleImportDTO, Sale>();
            this.CreateMap<Car, CarExportDTO>();
            this.CreateMap<Car, CarBMWExportDTO>();
            this.CreateMap<Supplier, SupplierExportDTO>()
                .ForMember(x => x.PartsCount, y => y.MapFrom(x => x.Parts.Count));
        }
    }
}
