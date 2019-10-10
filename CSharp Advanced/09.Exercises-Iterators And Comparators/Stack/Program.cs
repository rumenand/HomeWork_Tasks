using System;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main()
        {
            var stack = new Stack<int>();
            string input;
            while((input = Console.ReadLine()) != "END")
            {
                var commands = input.Split(" ");
                switch(commands[0])
                {
                    case "Push":
                        var items = string.Join("",commands.Skip(1).ToList());
                        stack.Push(items.Split(",").Select(int.Parse).ToArray());
                        break;
                    case "Pop":
                        stack.Pop();
                        break;
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine,stack));
            Console.WriteLine(string.Join(Environment.NewLine, stack));
        }
    }
}
