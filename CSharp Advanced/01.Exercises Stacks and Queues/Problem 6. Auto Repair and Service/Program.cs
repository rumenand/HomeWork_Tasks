using System;
using System.Collections.Generic;

namespace Problem_6._Auto_Repair_and_Service
{
    class Program
    {
        static void Main()
        {
            Queue<string> vehiclesForService = new Queue<string>(Console.ReadLine().Split());
            Stack<string> servicedVehicles = new Stack<string>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split("-");
                if (commands[0] == "Service")
                {
                    if (vehiclesForService.Count > 0)
                    {
                        string newServicedVehicle = vehiclesForService.Dequeue();
                        Console.WriteLine($"Vehicle {newServicedVehicle} got served.");
                        servicedVehicles.Push(newServicedVehicle);
                    }
                }
                else if (commands[0] == "CarInfo")
                {
                    if (vehiclesForService.Contains(commands[1])) Console.WriteLine("Still waiting for service.");
                    else if (servicedVehicles.Contains(commands[1])) Console.WriteLine("Served.");
                }
                else if (commands[0] == "History")
                {
                    Console.WriteLine(string.Join(", ",servicedVehicles));
                }
            }
            if (vehiclesForService.Count >0) Console.WriteLine($"Vehicles for service: {string.Join(", ",vehiclesForService)}");
            Console.WriteLine($"Served vehicles: {string.Join(", ", servicedVehicles)}");
        }
    }
}
