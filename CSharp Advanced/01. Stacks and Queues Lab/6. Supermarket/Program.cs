using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main()
        {
            Queue<string> customers = new Queue<string>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    while (customers.Count != 0)
                    {
                        Console.WriteLine(customers.Dequeue());
                    }
                }
                else customers.Enqueue(input);
            }
            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
