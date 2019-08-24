using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1._Basic_Stack_Operations
{
    class Program
    {
        static void Main()
        {
            string[] commands = Console.ReadLine().Split();
            int N = int.Parse(commands[0]);
            int S = int.Parse(commands[1]);
            int X = int.Parse(commands[2]);
            Stack<int> numbers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            for (int i=0; i<S;i++)
            {
                numbers.Pop();
            }
            if (numbers.Count == 0) Console.WriteLine("0");
            else if (numbers.Contains(X)) Console.WriteLine("true");
            else Console.WriteLine(numbers.Min());
        }
    }
}