using System;
using System.IO;
using System.Linq;

namespace Problem_2._Line_Numbers
{
    class Program
    {
        static void Main()
        {
            var lines = File.ReadAllLines(@"..\..\..\..\Resources\text.txt");
            using (StreamWriter outputFile = new StreamWriter(@"..\..\..\Output\output.txt"))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    var letters = lines[i].Count(char.IsLetter);
                    var punctuations = lines[i].Count(char.IsPunctuation);
                    outputFile.WriteLine($"Lines {i+1}: {lines[i]} ({letters})({punctuations})");
                }
                
            }
        }
    }
}
