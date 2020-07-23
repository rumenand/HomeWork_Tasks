using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.Models;
using CarDealer.DTO;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<CarInsertModel,Car>();
        }
    }
}
