using System;
using System.Collections.Generic;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Mamals;
using WildFarm.Animals.Mamals.Felines;

namespace WildFarm.Animals
{
    public class AnimalFactory
    {
        Dictionary<string, IAnimalCreator> createMap;
        public AnimalFactory()
        {
            createMap = new Dictionary<string, IAnimalCreator>();
            createMap.Add("Hen", new HenCreator());
            createMap.Add("Owl", new OwlCreator());
            createMap.Add("Dod", new DogCreator());
            createMap.Add("Mouse", new MouseCreator());
            createMap.Add("Cat", new CatCreator());
            createMap.Add("Tiger", new TigerCreator());
        }
        public Animal CreateAnimal (string [] args)
        {
            if (createMap.ContainsKey(args[0]))
                return createMap[args[0]].Create(args);
            return null;
        }
    }
}
