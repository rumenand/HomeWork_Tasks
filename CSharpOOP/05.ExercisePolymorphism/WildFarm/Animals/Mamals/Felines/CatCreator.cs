
namespace WildFarm.Animals.Mamals.Felines
{
    public class CatCreator : IAnimalCreator
    {
        public Animal Create(string[] args)
        {
            return new Cat(args[1], double.Parse(args[2]), args[3], args[4]);
        }
    }
}
