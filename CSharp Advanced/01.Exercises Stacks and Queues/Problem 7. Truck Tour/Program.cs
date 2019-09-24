using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7._Truck_Tour
{
    class FuelStation
    {
        public int fuel;
        public int distanceToNext;

        public FuelStation(int fuel, int distanceToNext)
        {
            this.fuel = fuel;
            this.distanceToNext = distanceToNext;
        }
    }

    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            var circle = new Queue<FuelStation>();
            for (int i=0; i<N; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                circle.Enqueue(new FuelStation(input[0],input[1]));             
            }
            int _firstPossible = -1;
            for (int station = 0; station<circle.Count; station++)
            {
                int fuelTank = 0;
                foreach(var currentStation in circle)
                {
                    fuelTank += currentStation.fuel - currentStation.distanceToNext;                  
                    if (fuelTank < 0) break;
                }
                if (fuelTank > 0)
                {
                    _firstPossible = station;
                    break;
                }
                else circle.Enqueue(circle.Dequeue());
            }
            Console.WriteLine(_firstPossible>-1 ? _firstPossible.ToString() : "");
        }
    }
}
