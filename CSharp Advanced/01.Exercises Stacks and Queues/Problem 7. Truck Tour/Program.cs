using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7._Truck_Tour
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            var circle = new Queue<string>();
            for (int i=0; i<N; i++)
            {
                circle.Enqueue(i+" "+Console.ReadLine());               
            }
            
            while (circle.Count > 0)
            {
                bool found = true;
                int[] first = circle.Dequeue().Split().Select(int.Parse).ToArray();
                int fuel = first[1];
                int distance = first[2];
                if (fuel > distance)
                {
                    foreach (var station in circle)
                    {
                        fuel -= distance;
                        int[] next = station.Split().Select(int.Parse).ToArray();
                        distance = next[2];
                        fuel += next[1];
                        if (fuel < distance)
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)
                    {
                        Console.WriteLine(first[0]);
                        break;
                    }

                }
            }
        }
    }
}
