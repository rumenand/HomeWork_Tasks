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
            var words = File.ReadAllLines(@"..\..\..\..\Resources\words.txt")
                        .ToDictionary(x=>x,y=>0);
            var text = File.ReadAllText(@"..\..\..\..\Resources\text.txt")
                        .ToLower()
                        .Split("\t\r\n\"'`/\\?!@#$%^&*+-_<>[]{}().,;: ".ToCharArray(),
                        StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var item in text)
            {
                if (words.ContainsKey(item)) words[item]++;
            }
            
           File.WriteAllLines(@"..\..\..\Output\actualResult.txt",
               words.OrderByDescending(x => x.Value)
               .Select(x => x.Key + " - " + x.Value)
               .ToArray());

            var areEquals = File.ReadLines(@"..\..\..\Output\actualResult.txt")
                            .SequenceEqual
                            (File.ReadLines(@"..\..\..\..\Resources\expectedResult.txt"));
            Console.WriteLine(areEquals);
        }        
    }
}