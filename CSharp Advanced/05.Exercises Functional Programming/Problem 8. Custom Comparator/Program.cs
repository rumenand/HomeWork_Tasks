using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem_8._Custom_Comparator
{
    public class CustomComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x % 2 == 0 && y % 2 != 0) return -1;
            else if (x % 2 != 0 && y % 2 == 0) return 1;
            else return x.CompareTo(y);            
        }
    }

    class Program
    {
        static void Main()
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            CustomComparer comp = new CustomComparer();
            Array.Sort(nums, comp);
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}