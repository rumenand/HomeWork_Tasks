
namespace WildFarm.Animals.Mamals
{
    class DogCreator : IAnimalCreator
    {
        public Animal Create(string[] args)
        {
          return  new Dog(args[1], double.Parse(args[2]), args[3]);
        }
    }
}
