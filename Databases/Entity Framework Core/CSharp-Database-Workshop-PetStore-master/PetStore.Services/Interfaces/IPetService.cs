using System.Collections.Generic;

using PetStore.ServiceModels.Pets.InputModels;
using PetStore.ServiceModels.Pets.OutputModels;

namespace PetStore.Services.Interfaces
{
    public interface IPetService
    {
        void AddPet(AddPetInputServiceModel model);

        ICollection<ListAllPetsServiceModel> GetAll();

      //  ICollection<ListAllProductsByProductTypeServiceModel> ListAllByProductType(string type);

      //  ICollection<ListAllProductsByNameServiceModel> SearchByName(string searchStr, bool caseSensitive);

     //   bool RemoveById(string id);

     //   bool RemoveByName(string name);

      //  void EditProduct(string id, EditProductInputServiceModel model);

      //  ProductDetailsServiceModel GetById(string id);
    }
}
