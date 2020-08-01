
namespace PetStore.ServiceModels.Pets.OutputModels
{
    public class ListAllPetsServiceModel
    {
        public string Name { get; set; }

        public string Gender { get; set; }

        public byte Age { get; set; }

        public decimal Price { get; set; }

        public string Breed { get; set; }
    }
}
