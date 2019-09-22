using System;
using System.Linq;

namespace Problem_12._TriFunction
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();
            Func<string, int, bool> isBiggerThanN = (str, num) => str.ToCharArray().Select(ch => (int)ch).Sum() >= num;
            var result = names.Where(n => isBiggerThanN(n, N));
            if (result.Any()) Console.WriteLine(result.First());
        }        
    }
}
