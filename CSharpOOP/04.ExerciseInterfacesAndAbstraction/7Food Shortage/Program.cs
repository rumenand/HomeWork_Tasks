using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FoodShortage
{
    class Program
    {
        static void Main()
        {
            var list = new List<IBuyer>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();
                if (input.Length == 4) list.Add(new Citizen(
                    input[0], int.Parse(input[1]),
                    input[2], DateParser(input[3])));
                else if (input.Length == 3) list.Add(new Rebel(
                     input[0], int.Parse(input[1]), input[2]));
            }
            string name;
            while((name = Console.ReadLine()) != "End")
            {
                var currentBuyer = list.Where(x => x.Name == name).FirstOrDefault();
                if (currentBuyer != null) currentBuyer.BuyFood();
            }
            Console.WriteLine(list.Sum(x=>x.Food));
          
        }
        static DateTime DateParser(string date)
        {
            return DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        }
    }
}
