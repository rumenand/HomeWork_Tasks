using System;
using System.Collections.Generic;

namespace Problem_6._Speed_Racing
{
    class Program
    {
        static void Main()
        {
            var carsList = new Dictionary<string,Car>();
            var lines = int.Parse(Console.ReadLine());
            for (int i= 0; i<lines;i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var newCar = new Car();
                newCar.Model = input[0];
                newCar.FuelAmount = double.Parse(input[1]);
                newCar.FuelConsumptionPerKilometer = double.Parse(input[2]);
                carsList.Add(newCar.Model,newCar);
            }
            string line;
            while((line = Console.ReadLine()) != "End")
            {
                var commands = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (!carsList[commands[1]].Drive(int.Parse(commands[2]))) Console.WriteLine("Insufficient fuel for the drive");
            }
            foreach (var car in carsList)
            {
                Console.WriteLine($"{car.Key} {car.Value.FuelAmount:F2} {car.Value.TravelledDistance}");
            }
        }
    }
}
