using System;
using System.Collections.Generic;

namespace Tuples
{
    class Program
    {
        static void Main()
        {
            var listTuples = new List<IWritable>();
            var input = Console.ReadLine().Split();
            listTuples.Add(new Tuple<string, string>(input[0] + " " + input[1], input[2]));
            input = Console.ReadLine().Split();
            listTuples.Add(new Tuple<string, int>(input[0], int.Parse(input[1])));
            input = Console.ReadLine().Split();
            listTuples.Add(new Tuple<int, double>(int.Parse(input[0]), double.Parse(input[1])));
            listTuples.ForEach(x => Console.WriteLine(x.WriteMe()));
        }
    }
}
