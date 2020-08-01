
using AutoMapper;
using PetStore.Models;
using PetStore.ServiceModels.Clients.InputModels;
using PetStore.ServiceModels.Clients.OutputModels;

namespace PetStore.Mapping
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            this.CreateMap<AddCLientInputServiceModel, Client>();
            this.CreateMap<EditClientInputServiceModel, Client>();
            this.CreateMap<Client, ListAllClientsServiceModel>();
            this.CreateMap<ClientDetailsServiceModel, Client>()
                .ForMember(x=>x.PetsBuyed,y=>y.MapFrom(x=>x.PetsBuyed));
        }
    }
}
