using System;
using System.Collections.Generic;

namespace Problem_4._Even_Times
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            var numbers = new Dictionary<int, int>();
            for (int i=0;i<N;i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(currentNum)) numbers.Add(currentNum, 1);
                else numbers[currentNum]++;                
            }
            foreach (var num in numbers)
            {
                if (num.Value % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                    break;
                }
            }
        }
    }
}
