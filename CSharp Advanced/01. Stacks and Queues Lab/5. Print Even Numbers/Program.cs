using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse);            
            Queue<int> queue = new Queue<int>(numbers);
            Queue<int> evens = new Queue<int>();
            while (queue.Count != 0)
            {                
                int current = queue.Dequeue();
                if (current %2 ==0) evens.Enqueue(current);
            }
            Console.WriteLine(string.Join(", ", evens));
        }
    }
}
