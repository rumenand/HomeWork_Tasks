using AutoMapper;
using PetStore.Models;
using PetStore.ServiceModels.Pets.InputModels;

namespace PetStore.Mapping
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            this.CreateMap<AddPetInputServiceModel, Pet>();
        }
    }
}
