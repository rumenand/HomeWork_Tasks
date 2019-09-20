using System;
using System.Linq;

namespace Problem_6._Reverse_and_Exclude
{
    class Program
    {
        static void Main()
        {
            var nums = Console.ReadLine();
            int divider = int.Parse(Console.ReadLine());          
            Func<int, bool> checker = n => n % divider != 0;
            var sortedNums = nums.Split().Select(int.Parse).Reverse().Where(checker);
            Console.WriteLine(string.Join(" ", sortedNums));   
        }
    }
}