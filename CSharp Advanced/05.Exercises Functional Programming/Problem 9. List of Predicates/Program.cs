using System;
using System.Linq;

namespace Problem_9._List_of_Predicates
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            var numbers = new int[N];
            var dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int, bool> checker = n => dividers.All(x=>n%x ==0);
            for (int i=0;i<N;i++)
            {
                numbers[i] = i + 1;
            }
            var result = numbers.Where(checker);
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
