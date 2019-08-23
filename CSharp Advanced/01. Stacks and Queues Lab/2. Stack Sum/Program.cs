using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main()
        {
            var values = Console.ReadLine().Split().Select(int.Parse);
            
            var stack = new Stack<int>(values);

            string input;
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string [] commands = input.Split();
                if (commands[0] == "add")
                {
                    stack.Push(int.Parse(commands[1]));
                    stack.Push(int.Parse(commands[2]));
                }
                if (commands[0] == "remove")
                {
                    int count = int.Parse(commands[1]);
                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < int.Parse(commands[1]); i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
