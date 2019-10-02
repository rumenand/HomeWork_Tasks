using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _3._Word_Count
{
    class Program
    {
        static void Main()
        {
            var wordsToCount = GetListFromFile("words.txt").ToDictionary(x=>x,y=>0);
            var compareList = GetListFromFile("input.txt");
           
                foreach (var compWord in compareList)
           {
                    if (wordsToCount.ContainsKey(compWord)) wordsToCount[compWord]++;
            }
            foreach (var kvp in wordsToCount.OrderByDescending(x=>x.Value))
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");

        }
       
        static List<string> GetListFromFile(string fileName)
        {
            var list = new List<string>();
            var lines = File.ReadAllText(fileName).ToLower()
                 .Split("\t\r\n\"'`/\\?!@#$%^&*+-_<>[]{}().,;: ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in lines)
            {
                list.Add(word);
            }
            return list;
        }
    }
}