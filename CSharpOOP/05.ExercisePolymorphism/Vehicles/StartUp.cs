using System;

namespace Vehicles
{
    class StartUp
    {
        static void Main()
        {
            var carInput = Console.ReadLine().Split();
            var car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]));
            var truckInput = Console.ReadLine().Split();
            var truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]));

            var comCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < comCount; i++)
            {
                var input = Console.ReadLine().Split();
                switch (input[0])
                {
                    case "Drive":
                        if (input[1] == "Car") Console.WriteLine(car.Drive(double.Parse(input[2])));
                        if (input[1] == "Truck") Console.WriteLine(truck.Drive(double.Parse(input[2])));
                        break;

                    case "Refuel":
                        if (input[1] == "Car") car.RefuelTank(double.Parse(input[2]));
                        if (input[1] == "Truck") truck.RefuelTank(double.Parse(input[2]));
                        break;
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
