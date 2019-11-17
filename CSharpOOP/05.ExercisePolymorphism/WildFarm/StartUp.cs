using System;
using System.Collections.Generic;
using System.Linq;
using WildFarm.Animals;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Mamals;
using WildFarm.Animals.Mamals.Felines;
using WildFarm.Foods;

namespace WildFarm
{
    class StartUp
    {
        static List<Animal> list = new List<Animal>();
        static void Main()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();
                Animal currentAnimal = null;
                switch (tokens[0])
                {
                    case "Cat":
                        currentAnimal = new Cat(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);                                              
                        break;
                    case "Tiger":
                        currentAnimal = new Tiger(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);
                        break;
                    case "Dog":
                        currentAnimal = new Dog(tokens[1], double.Parse(tokens[2]), tokens[3]);
                        break;
                    case "Mouse":
                        currentAnimal = new Mouse(tokens[1], double.Parse(tokens[2]), tokens[3]);
                        break;
                    case "Hen":
                        currentAnimal = new Hen(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
                        break;
                    case "Owl":
                        currentAnimal = new Owl(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
                        break;
                }
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
