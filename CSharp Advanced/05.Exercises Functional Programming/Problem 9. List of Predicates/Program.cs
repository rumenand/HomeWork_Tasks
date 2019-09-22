using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem_9._List_of_Predicates
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            var numbers = new int[N];
            var dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var predicates = dividers.Select(div => (Func<int, bool>)(n => n % div == 0)).ToArray();
            var lisPossibleNums = new List<int>();
            for (int i=1;i<=N;i++)
            {
                if (checkValid(predicates,i)) lisPossibleNums.Add(i);               
            }            
            Console.WriteLine(string.Join(" ", lisPossibleNums));
        }

        static bool checkValid (Func<int, bool> [] predicates, int num)
        {
            foreach (var predicate in predicates)
            {
                if (!predicate(num))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
