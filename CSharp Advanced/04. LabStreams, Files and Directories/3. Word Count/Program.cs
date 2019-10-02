using System;
using System.IO;
using System.Collections.Generic;

namespace _3._Word_Count
{
    class Program
    {
        static void Main()
        {
            
            var lines = File.ReadAllLines("words.txt");
            for (var i = 0; i < lines.Length; i += 1) {
             var line = lines[i];
            // Process line
            }
            
        }
    }
}
