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

                }
                else if (commands[0] == "CarInfo")
                {

                }
                else if (commands[0] == "History")
                {

                }
            }
            
        }
    }
}
