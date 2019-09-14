using System;
using System.Collections.Generic;

namespace _6._Parking_Lot
{
    class Program
    {
        static void Main()
        {            
            var parking = new HashSet<string>();
            string input;
            while ((input = Console.ReadLine()) !="END")
            {
                string[] commands = input.Split(", ");
                if (commands[0] == "IN") parking.Add(commands[1]);
                else parking.Remove(commands[1]);
            }
            if (parking.Count>0)
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
            else Console.WriteLine("Parking Lot is Empty");
        }
    }
}
