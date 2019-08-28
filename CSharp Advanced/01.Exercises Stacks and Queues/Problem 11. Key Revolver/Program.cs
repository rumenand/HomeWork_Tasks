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
            int shot = 0;
            while (bullets.Count>0 && locks.Count >0)
            {
                int currentBullet= bullets.Pop();               
                int currentLock = locks.Peek();
                if (currentBullet<=currentLock)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else Console.WriteLine("Ping!");
                shot++;
                if (shot == barrelSize && bullets.Count>0)
                {
                    Console.WriteLine("Reloading!");
                    shot = 0;
                }
            }        
            int bulletsPrice = (initialBullets - bullets.Count) * bulletPrice;
            if (locks.Count == 0) Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence-bulletsPrice}");
            else Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
    }
}
