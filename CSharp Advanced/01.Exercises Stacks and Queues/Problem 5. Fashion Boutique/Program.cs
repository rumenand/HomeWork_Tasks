using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5._Fashion_Boutique
{
    class Program
    {
        static void Main()
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int RackCapacity = int.Parse(Console.ReadLine());
            int rackCount = 1;
            int currentRackCapacity = 0;
            while (clothes.Count >0)
            {
                int next = clothes.Pop();
                if ((currentRackCapacity + next) <= RackCapacity) currentRackCapacity += next;
                else
                {
                    rackCount++;
                    currentRackCapacity = next;
                }
            }
            Console.WriteLine(rackCount);
        }
    }
}
