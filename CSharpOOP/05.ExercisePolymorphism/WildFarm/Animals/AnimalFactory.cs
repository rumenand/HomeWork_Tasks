
namespace WildFarm.Animals
{
    using System;
    using WildFarm.Animals.Creators;
    public class AnimalFactory
    {
        public AnimalFactory()
        {
         
        }
        public Animal CreateAnimal (string [] args)
        {
            Type anType = Type.GetType($"WildFarm.Animals.Creators.{args[0]}Creator");
            if (anType != null)
            {
                var animalCreator = (IAnimalCreator)Activator.CreateInstance(anType);
                return animalCreator.Create(args);
            }
            throw new ArgumentException($"Animal {args[0]} doesn't exists!");
        }
    }
}
