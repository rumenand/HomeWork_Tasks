using System;

namespace CustomStack
{
    class Program
    {
        static void Main()
        {
            var stack = new CustomStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            Console.WriteLine(stack.Count);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            stack.ForEach(x=>Console.WriteLine(x));
        }
    }
}
