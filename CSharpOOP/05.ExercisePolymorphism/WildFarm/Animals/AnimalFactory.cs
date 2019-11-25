using System;
using System.Collections.Generic;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Mamals;
using WildFarm.Animals.Mamals.Felines;
using System.Reflection;
using System.Linq;

namespace WildFarm.Animals
{
    public class AnimalFactory
    {
        public AnimalFactory()
        {
         
        }
        public Animal CreateAnimal (string [] args)
        {
            var currentFactory = Assembly
             .GetExecutingAssembly()
             .GetTypes()
             .Where(x => x.Name == $"{args[0]}Creator")
             .FirstOrDefault();
            var animalCreator = (IAnimalCreator)Activator.CreateInstance(currentFactory);
            return animalCreator.Create(args);
        }
    }
}
