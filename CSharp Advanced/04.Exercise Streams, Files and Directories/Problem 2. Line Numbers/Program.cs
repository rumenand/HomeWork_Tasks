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
            string outputPath = @"..\..\..\Output";
            Directory.CreateDirectory(outputPath);
            string outputFile = outputPath + @"\output.txt";
            using (StreamWriter output = new StreamWriter(outputFile))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    var letters = lines[i].Count(char.IsLetter);
                    var punctuations = lines[i].Count(char.IsPunctuation);
                    output.WriteLine($"Lines {i+1}: {lines[i]} ({letters})({punctuations})");
                }
                
            }
        }
    }
}
