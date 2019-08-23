using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            int count = 0;           
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    int upperLim = Math.Min(n, queue.Count);
                    for (int i = 0; i< upperLim; i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        count++;
                    }
                }

              else  queue.Enqueue(command);
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
