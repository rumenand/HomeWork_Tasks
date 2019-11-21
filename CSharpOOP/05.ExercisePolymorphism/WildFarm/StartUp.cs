using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Foods;

namespace WildFarm
{
    class StartUp
    {
        static List<Animal> list = new List<Animal>();
        static void Main()
        {
            var animalsFactory = new AnimalFactory();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();
                Animal currentAnimal = null;
                currentAnimal = animalsFactory.CreateAnimal(tokens);
                if (currentAnimal != null)
                {
                    list.Add(currentAnimal);
                    Console.WriteLine(currentAnimal.MakeSound());
                    var foodTokens = Console.ReadLine().Split();
                    Food currentFood = null;
                    switch (foodTokens[0])
                    {
                        case "Vegetable":
                            currentFood = new Vegetable(int.Parse(foodTokens[1]));
                            break;
                        case "Fruit":
                            currentFood = new Fruit(int.Parse(foodTokens[1]));
                            break;
                        case "Meat":
                            currentFood = new Meat(int.Parse(foodTokens[1]));
                            break;
                        case "Seeds":
                            currentFood = new Seeds(int.Parse(foodTokens[1]));
                            break;
                    }
                    try
                    {
                        currentAnimal.Feed(currentFood);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                
            }
            Console.WriteLine(string.Join(Environment.NewLine,list));
        }
    }
}
