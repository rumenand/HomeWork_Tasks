
namespace WildFarm.Animals.Creators
{
    using WildFarm.Animals.Mamals;
    class MouseCreator : IAnimalCreator
    {
        public Animal Create(string[] args)
        {
            return new Mouse(args[1], double.Parse(args[2]), args[3]);
        }
    }
}
