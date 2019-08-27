using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_11._Key_Revolver
{
    class Program
    {
        static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int initialBullets = bullets.Count;
            int intelligence = int.Parse(Console.ReadLine());
            while (bullets.Count>0 && locks.Count >0)
            {
                int p= bullets.Pop();
                locks.Dequeue();
            }        
            int bulletsPrice = (initialBullets - bullets.Count) * bulletPrice;
            if (locks.Count > 0) Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence-bulletsPrice}");
            else Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
    }
}
