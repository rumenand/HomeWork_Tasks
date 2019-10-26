using System;
using System.Collections.Generic;
using System.Linq;

namespace DatingApp
{
    class Program
    {
        static void Main()
        {
            var male = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var female = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var matches = 0;
            while (male.Count>0 && female.Count>0)
            {
                var currentMale = male.Pop();
                if (!CheckPerson(currentMale)) continue;
                var currentFemale = female.Dequeue();
                if (!CheckPerson(currentFemale))
                {
                    male.Push(currentMale);
                    continue;
                }
                if (currentMale % 25 == 0)
                {
                    if (male.Count > 0) male.Pop();
                    female = new Queue<int>(female.Reverse());
                    female.Enqueue(currentFemale);
                    female = new Queue<int>(female.Reverse());
                    continue;
                }
                if (currentFemale % 25 == 0)
                {
                    if (female.Count > 0) female.Dequeue();
                    male.Push(currentMale);
                    continue;
                }
                if (currentMale == currentFemale)  matches++;
                else male.Push(currentMale - 2);
            }
            Console.WriteLine($"Matches: {matches}");
            Console.WriteLine($"Males left: {GetResult(male)}");
            Console.WriteLine($"Females left: {GetResult(female)}");
        }

        private static string GetResult(IEnumerable<int> list)
        {
           return (list.Count() > 0) ? string.Join(", ", list) : "none";
        }

        private static bool CheckPerson(int num)
        {
            if (num <= 0) return false;
            return true;            
        }
    }
}