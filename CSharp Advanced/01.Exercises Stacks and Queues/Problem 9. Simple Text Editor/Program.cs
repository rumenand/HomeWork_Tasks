using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_9._Simple_Text_Editor
{
    class Program
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            var undoStack = new Stack<string>();
            for (int i=0; i<lines;i++)
            {
                string[] commands = Console.ReadLine().Split();
                switch (commands[0])
                {
                    case "1":
                        sb.Append(commands[1]);
                        undoStack.Push("2 " + commands[1].Length);
                        break;
                    case "2":
                        int subLength = int.Parse(commands[1]);
                        string substract = sb.ToString().Substring(sb.Length - subLength);
                        sb.Remove(sb.Length - subLength, subLength);
                        undoStack.Push("1 " + substract);
                        break;
                    case "3":
                        Console.WriteLine(sb[int.Parse(commands[1])]);
                        break;
                    case "4":
                        // undo
                        break;
                }
            }
        }
    }
}
