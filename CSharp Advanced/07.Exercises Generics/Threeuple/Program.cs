using System;
using System.Collections.Generic;

namespace Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var listTuples = new List<IWritable>();
            var input = Console.ReadLine().Split();
            listTuples.Add(new Tuple<string, string, string>(input[0] + " " + input[1], input[2], input[3]));
            input = Console.ReadLine().Split();
            listTuples.Add(new Tuple<string, int, bool>(input[0], int.Parse(input[1]), (input[2] == "drunk" ?true:false)));
            input = Console.ReadLine().Split();
            listTuples.Add(new Tuple<string, double, string>(input[0], double.Parse(input[1]), input[2]));
            listTuples.ForEach(x => Console.WriteLine(x.WriteMe()));
        }
    }
}
