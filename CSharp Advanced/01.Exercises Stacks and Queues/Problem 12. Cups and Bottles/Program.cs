using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_12._Cups_and_Bottles
{
    class Program
    {
        static void Main()
        {
            var cups = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var bottles = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int wastedWater = 0;
            while (bottles.Count > 0)
            {
                int currentBottle = bottles.Dequeue();

            }
        }
    }
}
