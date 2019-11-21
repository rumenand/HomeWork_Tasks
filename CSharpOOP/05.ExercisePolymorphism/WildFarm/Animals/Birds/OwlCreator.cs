
namespace WildFarm.Animals.Birds
{
    class OwlCreator : IAnimalCreator
    {
        public Animal Create(string[] args)
        {
            return new Owl(args[1], double.Parse(args[2]), double.Parse(args[3]));
        }
    }
}
