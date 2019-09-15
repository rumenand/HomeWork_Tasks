using System;
using System.Collections.Generic;

namespace Problem_1._Unique_Usernames
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            var names = new HashSet<string>();
            for (int i =0; i<N;i++)
            {
                names.Add(Console.ReadLine());
            }
            foreach (var name in names)
                Console.WriteLine(name);
        }
    }
}
