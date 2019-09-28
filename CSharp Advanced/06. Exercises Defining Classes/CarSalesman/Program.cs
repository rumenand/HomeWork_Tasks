using System;
using System.Collections.Generic;

namespace CarSalesman
{
    class Program
    {
        static void Main()
        {
            var enginesList = new List<Engine>();
            var carList = new List<Car>(); 
            int enginesLines = int.Parse(Console.ReadLine());
            populateEngines(enginesLines, enginesList);
            int carLines = int.Parse(Console.ReadLine());
            populateCars(carLines, carList, enginesList);
            printAllCars(carList);
        }

        static void populateEngines (int lines, List<Engine> engines)
        {
            for(int i=0; i<lines; i++)
            {
                var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                engines.Add(new Engine(input));
            }
        }

        static void populateCars(int lines, List<Car> cars, List<Engine> engines)
        {
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                cars.Add(new Car(input, engines));
            }
        }

        static void printAllCars(List<Car> list)
        {
            foreach (var car in list)
            {
                Console.WriteLine(car);
            }
        }
    }
}
