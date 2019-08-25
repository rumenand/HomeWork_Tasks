using System;
using System.Collections.Generic;

namespace Problem_8._Balanced_Parentheses
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            bool balanced = true;
            var stack = new Stack<char>();
            foreach (char ch in input)
            {
                switch (ch)
                {
                    case '{':
                    case '(':
                    case '[':
                        stack.Push(ch);
                        break;
                    case '}':
                        if (stack.Count != 0 && stack.Pop() == '{') balanced = true;
                        else balanced = false;
                        break;
                    case ')':
                        if (stack.Count != 0 && stack.Pop() == '(') balanced = true;
                        else balanced = false;
                        break;
                    case ']':
                        if (stack.Count != 0 && stack.Pop() == '[') balanced = true;
                        else balanced = false;
                        break;
                }
                if (!balanced) break;
            }
            Console.WriteLine(balanced ? "YES" : "NO");
        }
    }
}