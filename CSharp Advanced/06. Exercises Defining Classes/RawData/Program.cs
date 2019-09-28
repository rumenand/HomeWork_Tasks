using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main()
        {
            var carList = new List<Car>();
            int linesCars = int.Parse(Console.ReadLine());
            for (int i=0; i<linesCars; i++)
            {
                var input = Console.ReadLine().Split();
                carList.Add(new Car(input));
            }
            var command = Console.ReadLine();
            if (command == "fragile")
            carList.Where(x => x.Cargo.CargoType == command).Where(x => x.Tires.Any(y => y.TirePressure < 1)).ToList().ForEach(x => Console.WriteLine(x.Model));
            else if (command == "flamable")
            carList.Where(x => x.Cargo.CargoType == command).Where(x => x.Engine.EnginePower>250).ToList().ForEach(x => Console.WriteLine(x.Model));
        }
    }
}
