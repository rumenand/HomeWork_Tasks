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
            var words = File.ReadAllLines(@"words.txt").ToDictionary(x=>x,y=>0);
            var text = File.ReadAllText("text.txt").ToLower()
                .Split("\t\r\n\"'`/\\?!@#$%^&*+-_<>[]{}().,;: ".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var item in text)
            {
                if (words.ContainsKey(item)) words[item]++;
            }
            WriteTextFile("actualResult.txt", words);
            WriteTextFile("expectedResult.txt", words.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value));
            
        }

        static void WriteTextFile(string fileName, Dictionary<string,int> words)
        {
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                foreach (var item in words)
                {
                    outputFile.WriteLine($"{item.Key} - {item.Value}");
                }
            }

        }
    }
}
