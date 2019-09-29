using System;
using System.Linq;

namespace GenericSwapMethodStrings
{
    class Program
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var list = new Box<string>();
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine();
                list.list.Add(input);
            }
            var swapIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            list.SwapElelments(swapIndexes[0],swapIndexes[1]);
        }
    }
}
