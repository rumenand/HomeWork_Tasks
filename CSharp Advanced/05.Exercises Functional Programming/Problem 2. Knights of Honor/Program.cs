using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem_2._Knights_of_Honor
{
    class Program
    {
        static void Main()
        {
            Action<IEnumerable<string>> printSir = collection => Console.WriteLine(string.Join(Environment.NewLine, collection.Select(name => $"Sir {name}")));
            string[] input = Console.ReadLine().Split();
            printSir(input);
        }
    }
}
