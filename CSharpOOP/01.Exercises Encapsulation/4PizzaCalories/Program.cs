using System;

namespace _4PizzaCalories
{
    class Program
    {
        static void Main()
        {
            try
            {
                var pizza = Console.ReadLine().Split();
                var dough = Console.ReadLine().Split();            
                var doughArgs = Console.ReadLine().Split();
                var newPizza = new Pizza(pizza[1]);
                newPizza.Dough = new Dough(dough[1], dough[2], int.Parse(dough[2]));
                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    var commands = input.Split();                    
                    var topping = new Topping(commands[1], int.Parse(commands[2]));                            
                    newPizza.AddTopping(topping);  
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
