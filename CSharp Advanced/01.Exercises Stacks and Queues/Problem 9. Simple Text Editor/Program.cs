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
            for (int i=0; i<lines;i++)
            {
                string[] commands = Console.ReadLine().Split();
                switch (commands[0])
                {
                    case "1":
                        sb.Append(commands[1]);
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
