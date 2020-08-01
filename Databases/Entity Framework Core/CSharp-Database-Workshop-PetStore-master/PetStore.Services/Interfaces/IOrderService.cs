
using PetStore.ServiceModels.Orders.InputModels;
using PetStore.ServiceModels.Orders.OutputModels;
using System.Collections.Generic;

namespace PetStore.Services.Interfaces
{
    public interface IOrderService
    {
        void AddOrder(AddOrderInputServiceModel model);

        ICollection<ListAllOrdersServiceModel> GetAll();


        bool RemoveById(string id);

        void EditOrder(string id, EditOrdertInputServiceModel model);

        //  DetailsOrderServiceModel GetById(string id);
    }
}
