using System;
using System.Collections.Generic;

namespace Tuples
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split();
            var tuple1 = new Tuple<string, string>(input[0] + " " + input[1], input[2]);
            input = Console.ReadLine().Split();
            var tuple2 = new Tuple<string, int>(input[0], int.Parse(input[1]));
            input = Console.ReadLine().Split();
            var tuple3 = new Tuple<int, double>(int.Parse(input[0]), double.Parse(input[1]));
            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}
