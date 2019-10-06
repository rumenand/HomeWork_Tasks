using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Problem_3._Word_Count
{
    class Program
    {
        static void Main()
        {
            string input = @"..\..\..\..\Resources\";
            string outputPath = @"..\..\..\Output";
            Directory.CreateDirectory(outputPath);
            string outputFile = outputPath + @"\actualResult.txt";

            var words = File.ReadAllLines(input + "words.txt")
                        .ToDictionary(x=>x,y=>0);
            var text = File.ReadAllText(input + "text.txt")
                        .ToLower()
                        .Split("\t\r\n\"'`/\\?!@#$%^&*+-_<>[]{}().,;: ".ToCharArray(),
                        StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var item in text)
            {
                if (words.ContainsKey(item)) words[item]++;
            }
            
           File.WriteAllLines(outputFile,
               words.OrderByDescending(x => x.Value)
               .Select(x => x.Key + " - " + x.Value)
               .ToArray());

            var areEquals = File.ReadLines(outputFile).SequenceEqual
                            (File.ReadLines(input +"expectedResult.txt"));
            Console.WriteLine(areEquals);
        }        
    }
}