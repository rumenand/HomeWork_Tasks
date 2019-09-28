using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    class Program
    {
        static void Main()
        {
            var carsList = new Dictionary<string, Car>();
            var lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var newCar = new Car();
                newCar.Model = input[0];
                newCar.FuelAmount = decimal.Parse(input[1]);
                newCar.FuelConsumptionPerKilometer = decimal.Parse(input[2]);
                carsList[input[0]] = newCar;
            }
            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                var commands = line.Split();                
                if (carsList.ContainsKey(commands[1]) && !carsList[commands[1]].Drive(int.Parse(commands[2]))) Console.WriteLine("Insufficient fuel for the drive");
            }
            foreach (var car in carsList)
            {
                Console.WriteLine($"{car.Key} {car.Value.FuelAmount:F2} {car.Value.TravelledDistance}");
            }
        }
    }
}
