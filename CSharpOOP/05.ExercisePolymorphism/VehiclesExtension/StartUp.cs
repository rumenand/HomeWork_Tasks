using System;
using System.Collections.Generic;
using System.Linq;

namespace VehiclesExtension
{
    class StartUp
    {
        private static List<Vehicle> vehicleList = new List<Vehicle>();
        static void Main()
        {
            
            for (int i = 0; i < 3; i++)
            {
                var input = Console.ReadLine().Split();
                switch (input[0])
                {
                    case "Car":
                        vehicleList.Add(new Car(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3])));
                        break;
                    case "Truck":
                        vehicleList.Add(new Truck(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3])));
                        break;
                    case "Bus":
                        vehicleList.Add(new Bus(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3])));
                        break;
                }
            }

            var count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();
                try
                {
                    switch (input[0])
                    {
                        case "Drive":
                            var driveVehicle = GetVehicle(input[1]);
                            if (driveVehicle != null) Console.WriteLine(driveVehicle.Drive(double.Parse(input[2])));
                            break;
                        case "Refuel":
                            var refillVehicle = GetVehicle(input[1]);
                            if (refillVehicle != null) refillVehicle.RefuelTank(double.Parse(input[2]));
                            break;
                        case "DriveEmpty":
                            var emptyBus = GetVehicle(input[1]) as Bus;
                            if (emptyBus != null) Console.WriteLine(emptyBus.DriveEmpty(double.Parse(input[2])));
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            foreach (var vehicle in vehicleList)
            {
                Console.WriteLine($"{vehicle.Name}: {vehicle.FuelQuantity:F2}");
            }
        }

        private static Vehicle GetVehicle(string v)
        {
            return vehicleList.Where(x => x.Name == v).FirstOrDefault();
        }
    }
}
