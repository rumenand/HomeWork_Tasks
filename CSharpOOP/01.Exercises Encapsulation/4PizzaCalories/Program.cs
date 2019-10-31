using System;

namespace _4PizzaCalories
{
    class Program
    {
        static void Main()
        {
            string input;
            Pizza pizza = null;
            bool endCycle = false;         
            while ((input = Console.ReadLine()) != "END")
            {               
                var commands = input.Split();
                switch (commands[0])
                {
                    case "Pizza":                       
                        try
                        {
                            pizza = new Pizza(commands[1]);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            endCycle = true;
                        }                        
                        break;
                    case "Dough":
                        Dough dough = null;
                        try
                        {
                            dough = new Dough(commands[1], commands[2], int.Parse(commands[3]));
                        }
                        catch (Exception e)
                        {
                          Console.WriteLine(e.Message);
                            endCycle = true;                
                        }
                        if (dough != null) pizza.Dough = dough ;
                        break;
                    case "Topping":
                        Topping topping = null;
                        try
                        {
                            topping = new Topping(commands[1], int.Parse(commands[2]));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            endCycle = true;
                        }
                        if (topping != null)
                            try
                            {
                                pizza.AddTopping(topping);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                endCycle = true;
                            }
                        break;
                }
                if (endCycle) break;
            }
            if (!endCycle) Console.WriteLine(pizza);
        }
    }
}
