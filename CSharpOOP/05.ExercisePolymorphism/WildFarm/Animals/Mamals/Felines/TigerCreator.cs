
namespace WildFarm.Animals.Mamals.Felines
{
    public class TigerCreator : IAnimalCreator
    {
        public Animal Create(string[] args)
        {
            return new Tiger(args[1], double.Parse(args[2]), args[3], args[4]);
        }
    }
}
