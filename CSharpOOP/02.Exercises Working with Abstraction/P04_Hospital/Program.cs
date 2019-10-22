using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<Room>> departments = new Dictionary<string, List<Room>>();

            string command;
            while ((command= Console.ReadLine())!= "Output")
            {
                string[] tokens = command.Split();
                var departament = tokens[0];
                var firstName = tokens[1];
                var secondName = tokens[2];
                var patient = tokens[3];
                var fullName = firstName + secondName;

                if (!doctors.ContainsKey(fullName))
                {
                    doctors[fullName] = new List<string>();
                }
                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<Room>();
                    for (int rooms = 0; rooms < 20; rooms++)
                    {
                        departments[departament].Add(new Room());
                    }
                }

                var availableBeds = departments[departament].Where(x => x.Patients.Count<3);
                if (availableBeds.Count() >0)
                {
                    doctors[fullName].Add(patient);
                    availableBeds.FirstOrDefault().Patients.Add(patient);
                }
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Patients.Count>0).SelectMany(x => x.Patients)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]][room - 1].Patients.OrderBy(x=>x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
                }                
            }
        }
    }
}
