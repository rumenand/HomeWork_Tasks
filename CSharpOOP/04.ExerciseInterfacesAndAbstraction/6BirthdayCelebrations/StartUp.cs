using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _6BirthdayCelebrations
{
    class StartUp
    {
        static void Main()
        {
            var list = new List<IBirthtable>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var commands = input.Split();
                switch (commands[0])
                {
                    case "Citizen":
                        list.Add(new Citizen(commands[1], 
                            int.Parse(commands[2]),
                            commands[3],
                            DateParser(commands[4])));
                        break;
                    case "Pet":
                        list.Add(new Pet(commands[1], DateParser(commands[2])));
                        break;
                }
            }
            var searchYear = int.Parse(Console.ReadLine());
            var result = list.Where(x => x.BirthDay.Year == searchYear);
            foreach (var birthable in result)
            {
                Console.WriteLine(birthable.BirthDay.ToString("dd/MM/yyyy"));
            }
        }
        static DateTime DateParser(string date)
        {
            return DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        }
    }
}
