using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main()
        {
            Stack<int> numbers = new Stack<int>();
            int N = int.Parse(Console.ReadLine());
            for (int i=0; i<N;i++)
            {
                string [] commands = Console.ReadLine().Split();
                switch (commands[0])
                {
                    case "1":
                        numbers.Push(int.Parse(commands[1]));
                        break;
                    case "2":
                        if (numbers.Count >0) numbers.Pop();
                        break;
                    case "3":
                        if (numbers.Count > 0)  Console.WriteLine(numbers.Max());
                        break;
                    case "4":
                        if (numbers.Count > 0) Console.WriteLine(numbers.Min());
                        break;
                }
            }
            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
