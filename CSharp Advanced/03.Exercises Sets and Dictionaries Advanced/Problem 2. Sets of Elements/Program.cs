using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Sets_of_Elements
{
    class Program
    {
        static void Main()
        {
            int[] lengths = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var setN = new HashSet<int>();
            var setM = new HashSet<int>();
            for (int i=0; i<lengths[0]; i++)
            {
                setN.Add(int.Parse(Console.ReadLine()));
            }
            for (int i=0;i<lengths[1];i++)
            {
                setM.Add(int.Parse(Console.ReadLine()));
            }
            foreach (var num in setN)
            {
                if (setM.Contains(num)) Console.Write($"{num} ");
            }
        }
    }
}
