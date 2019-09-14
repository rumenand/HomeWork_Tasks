using System;
using System.Collections.Generic;

namespace _7._SoftUni_Party
{
    class Program
    {
        static void Main()
        {

            var regGuests = new HashSet<string>();
            var vipGuests = new HashSet<string>();
            string input;
            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (input.Length == 8)
                {
                    if (char.IsDigit(input[0])) vipGuests.Add(input);
                    else regGuests.Add(input);
                }
            }
            while ((input = Console.ReadLine()) != "END")
            {
                if (regGuests.Contains(input)) regGuests.Remove(input);
                else if (vipGuests.Contains(input)) vipGuests.Remove(input);
            }
            Console.WriteLine(regGuests.Count+vipGuests.Count);
            foreach (var guest in vipGuests) Console.WriteLine(guest);
            foreach (var guest in regGuests) Console.WriteLine(guest);
        }
    }
}
