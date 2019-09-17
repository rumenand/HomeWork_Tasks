using System;
using System.Linq;

namespace _1._Sort_Even_Numbers
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
            .Split(new string[] { ", " },
            StringSplitOptions.RemoveEmptyEntries)
            .Select(n => int.Parse(n))
            .Where(n => n % 2 == 0)
            .OrderBy(n => n)
            .ToArray();
            string result = string.Join(", ", numbers);
            Console.WriteLine(result);
        }
    }
}
