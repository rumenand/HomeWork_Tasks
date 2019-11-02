using System;

namespace _4PizzaCalories
{
    class Program
    {
        static void Main()
        {
            string input;
            Pizza pizza =  null;
            try 
            {
                while ((input = Console.ReadLine()) != "END")
                {
                    var commands = input.Split();
                    switch (commands[0])
                    {
                        case "Pizza":
                            var doughArgs = Console.ReadLine().Split();
                                pizza = new Pizza(commands[1], new Dough(doughArgs[1],doughArgs[2],int.Parse(doughArgs[3])));
                            
                            break; 
                        case "Topping":                           
                                var topping = new Topping(commands[1], int.Parse(commands[2]));                            
                                pizza.AddTopping(topping);                             
                            break;
                    }
                }
                Console.WriteLine(pizza);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
