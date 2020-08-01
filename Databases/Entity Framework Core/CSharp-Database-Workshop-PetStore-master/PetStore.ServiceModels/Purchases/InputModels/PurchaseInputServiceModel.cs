
using PetStore.Models;
using PetStore.ServiceModels.Orders.InputModels;

namespace PetStore.ServiceModels.Purchases.InputModels
{
    public class PurchaseInputServiceModel
    {
        public Product Product { get; set; }
        public Client Client { get; set; }
        public int Quantity { get; set; }
        public string OrderId { get; set; }
    }
}
