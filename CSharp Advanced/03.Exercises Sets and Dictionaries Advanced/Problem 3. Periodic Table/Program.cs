using System;
using System.Collections.Generic;

namespace Problem_3._Periodic_Table
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            var elements = new SortedSet<string>();
            for (int i = 0; i < N; i++)
            {
                var names = Console.ReadLine().Split();
                foreach (var name in names)
                    elements.Add(name);
            }
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
