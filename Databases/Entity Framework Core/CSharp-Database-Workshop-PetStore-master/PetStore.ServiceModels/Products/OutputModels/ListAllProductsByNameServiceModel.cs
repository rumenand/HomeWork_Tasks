namespace PetStore.ServiceModels.Products.OutputModels
{
    public class ListAllProductsByNameServiceModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string ProductType { get; set; }

        public decimal Price { get; set; }
    }
}
