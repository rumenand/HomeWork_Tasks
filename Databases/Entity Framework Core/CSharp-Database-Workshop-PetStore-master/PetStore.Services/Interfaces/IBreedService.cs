using System.Collections.Generic;

using PetStore.ServiceModels.Breeds;

namespace PetStore.Services.Interfaces
{
    public interface IBreedService
    {
        void AddBreed(BreedServiceModel model);

        ICollection<BreedServiceModel> GetAll();

        bool RemoveById(string id);

        //   bool RemoveByName(string name);

        void EditBreed(string id, BreedServiceModel model);
    }
}
