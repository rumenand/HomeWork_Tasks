using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Basic_Queue_Operations
{
    class Program
    {
        static void Main()
        {
            string[] commands = Console.ReadLine().Split();
            int N = int.Parse(commands[0]);
            int S = int.Parse(commands[1]);
            int X = int.Parse(commands[2]);
            Queue<int> numbers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            for (int i = 0; i < S; i++)
            {
                numbers.Dequeue();
            }
            if (numbers.Count == 0) Console.WriteLine("0");
            else if (numbers.Contains(X)) Console.WriteLine("true");
            else Console.WriteLine(numbers.Min());
        }
    }
}
