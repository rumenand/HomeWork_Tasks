using System;
using System.Linq;

namespace _2._Sum_Numbers
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Func<string, int> parser = n => int.Parse(n);
            int[] numbers = input.Split(new string[] { ", " },
            StringSplitOptions.RemoveEmptyEntries)
            .Select(parser).ToArray();
            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}