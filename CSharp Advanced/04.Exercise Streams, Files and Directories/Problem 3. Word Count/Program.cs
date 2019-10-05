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
            var words = File.ReadAllLines(@"..\..\..\..\Resources\words.txt").ToDictionary(x=>x,y=>0);
            var text = File.ReadAllText(@"..\..\..\..\Resources\text.txt").ToLower()
                .Split("\t\r\n\"'`/\\?!@#$%^&*+-_<>[]{}().,;: ".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var item in text)
            {
                if (words.ContainsKey(item)) words[item]++;
            }
            //WriteTextFile(@"..\..\..\Output\output.txt", words);
           WriteTextFile(@"..\..\..\Output\actualResult.txt", words.OrderByDescending(x => x.Value));            
        }

        static void WriteTextFile(string fileName, IOrderedEnumerable<KeyValuePair<string, int>> words)
        {
         File.WriteAllLines(fileName,words.Select(x => x.Key + "-" + x.Value).ToArray());           
        }
    }
}
