
namespace WildFarm.Animals.Birds
{
    class HenCreator : IAnimalCreator
    {
        public Animal Create(string[] args)
        {
            return new Hen(args[1], double.Parse(args[2]), double.Parse(args[3]));
        }
    }
}
