
using PetStore.ServiceModels.Clients.InputModels;
using PetStore.ServiceModels.Clients.OutputModels;
using System.Collections.Generic;

namespace PetStore.Services.Interfaces
{
    public interface IClientService
    {
        void AddClient(AddCLientInputServiceModel model);

        ICollection<ListAllClientsServiceModel> GetAll();


        bool RemoveById(string id);

        void EditClient(string id, EditClientInputServiceModel model);

        ClientDetailsServiceModel GetById(string id);
    }
}
