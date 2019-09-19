using System;

namespace Problem_2._Knights_of_Honor
{
    class Program
    {
        static void Main()
        {
            Action<string> printSir = name => Console.WriteLine($"Sir {name}");
            string[] input = Console.ReadLine().Split();
            foreach (var name in input)
                printSir(name);
        }
    }
}
