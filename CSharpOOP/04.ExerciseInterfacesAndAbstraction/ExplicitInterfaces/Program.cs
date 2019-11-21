using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    class Program
    {
        static void Main()
        {
            var list = new List<Citizen>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var commands = input.Split();
                var currentCitizen = new Citizen(commands[0], commands[1], int.Parse(commands[2]));
                IResident residentCitizen = currentCitizen;
                IPerson personCitizen = currentCitizen;
                Console.WriteLine(personCitizen.GetName());
                Console.WriteLine(residentCitizen.GetName());
            }
        }
    }
}
