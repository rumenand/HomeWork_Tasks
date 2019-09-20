using System;
using System.Linq;

namespace Problem_4._Find_Evens_or_Odds
{
    class Program
    {
        static void Main()
        {
            Func<int, bool> CheckEven = n => n%2 == 0;            
            int[] borders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            bool even = false;
            if (command == "even") even = true;
            for (int i=borders[0];i<=borders[1];i++)
            {
                if (even && CheckEven(i)) Console.Write($"{i} ");
                else if (!even && !CheckEven(i)) Console.Write($"{i} ");
            }
        }
    }
}
