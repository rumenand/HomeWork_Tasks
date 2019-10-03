using System;
using System.IO;
using System.Linq;

namespace Problem_1._Even_Lines
{
    class Program
    {
        static void Main()
        {
            char[] separators = new char[] { '-', ',', '.', '!', '?' };
            Func<string, string> replacer = x => separators.Aggregate(x, (c1, c2) => c1.Replace(c2, '@'));
            StreamReader reader = new StreamReader("text.txt");
            using (reader)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();                
                while (line != null)
                {
                    if (lineNumber % 2 == 0)
                    {
                        line = String.Join(" ", line.Split(' ').Reverse());
                        Console.WriteLine(replacer(line));                        
                    }
                    line = reader.ReadLine();
                    lineNumber++;
                }                
            }
        }        
    }
}
