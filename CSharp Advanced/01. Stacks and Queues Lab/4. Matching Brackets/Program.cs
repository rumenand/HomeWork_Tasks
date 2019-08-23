using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var stack = new Stack<int>();
            for (int i=0;i<input.Length;i++)
            {
                if (input[i] == '(') stack.Push(i);
                if (input[i] == ')')
                {
                    for (int j = stack.Pop(); j<=i; j++)
                    {
                        Console.Write(input[j]);                        
                    }
                    Console.WriteLine();
                }

            }
            
        }
    }
}
