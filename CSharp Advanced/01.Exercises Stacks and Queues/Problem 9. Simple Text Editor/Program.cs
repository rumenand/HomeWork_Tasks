using System;
using System.Collections.Generic;

namespace Problem_9._Simple_Text_Editor
{
    class Program
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            for (int i=0; i<lines;i++)
            {
                string[] commands = Console.ReadLine().Split();
                switch (commands[0])
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                }
            }
        }
    }
}
