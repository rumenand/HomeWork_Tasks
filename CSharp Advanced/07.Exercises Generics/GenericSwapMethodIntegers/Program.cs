using System;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    class Program
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var list = new Box<int>();
            for (int i = 0; i < lines; i++)
            {
                var input = int.Parse(Console.ReadLine());
                list.list.Add(input);
            }
            var swapIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            list.SwapElelments(swapIndexes[0], swapIndexes[1]);
        }
    }
}
