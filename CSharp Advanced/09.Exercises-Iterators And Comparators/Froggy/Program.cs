using System;
using System.Linq;

namespace Froggy
{
    class Program
    {
        static void Main()
        {
            var stonesList = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var frogLake = new Lake(stonesList);
            Console.WriteLine(string.Join(", ", frogLake));
        }
    }
}
