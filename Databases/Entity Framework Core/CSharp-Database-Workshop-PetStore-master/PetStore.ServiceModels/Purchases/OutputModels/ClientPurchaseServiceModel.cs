
namespace PetStore.ServiceModels.Purchases.OutputModels
{
    public class ClientPurchaseServiceModel
    {
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public int Quantitty { get; set; }
        public decimal Price { get; set; }
    }
}
