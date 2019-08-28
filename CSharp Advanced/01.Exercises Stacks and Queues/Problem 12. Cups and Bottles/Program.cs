using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_12._Cups_and_Bottles
{
    class Program
    {
        static void Main()
        {
            var cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int wastedWater = 0;
            while (bottles.Count > 0 && cups.Count>0)
            {
                int currentCup = cups.Dequeue();
                bool filled = false;
                while(!filled && bottles.Count >0)
                {
                    int currentBottle = bottles.Pop();
                    currentCup -= currentBottle;
                    if (currentCup<=0)
                    {
                        filled = true;
                        wastedWater += currentCup * -1;
                    }
                }
            }
            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ",bottles)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
