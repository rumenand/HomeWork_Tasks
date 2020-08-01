using AutoMapper;
using PetStore.Models;
using PetStore.ServiceModels.Breeds;
using PetStore.ViewModels.Breed;

namespace PetStore.Mapping
{
   public class BreedProfile : Profile
    {
        public BreedProfile()
        {
            this.CreateMap<Breed, BreedServiceModel>()
                .ReverseMap();
            this.CreateMap<BreedViewModel, BreedServiceModel>()
                .ReverseMap();
        }
    }
}
