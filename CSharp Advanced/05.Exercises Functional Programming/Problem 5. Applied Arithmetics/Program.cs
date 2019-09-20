using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem_5._Applied_Arithmetics
{
    class Program
    {
        static void Main()
        {
            Func<int [] , int[]> addOne = n => n.Select(x => x +1).ToArray();
            Func<int[], int[]> multiplyTwo = n => n.Select(x => x * 2).ToArray();
            Func<int[], int[]> substractOne = n => n.Select(x => x - 1).ToArray();
            Action<int[]> print = col => Console.WriteLine(string.Join(" ",col)); 
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input;
            while((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "add":
                         nums = addOne(nums);
                        break;
                    case "multiply":
                        nums = multiplyTwo(nums);
                        break;
                    case "subtract":
                        nums = substractOne(nums);
                        break;
                    case "print":
                        print(nums);
                        break;
                }
            }
        }
    }
}
