using System;
using System.Linq;

namespace Problem_3._Custom_Min_Function
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Func<string [], int> GetMin = CalcMinNumber;
            Console.WriteLine(GetMin(numbers));
        }

        static int CalcMinNumber(string[] numbers)
        {
            return 0;
        }
    }
}
