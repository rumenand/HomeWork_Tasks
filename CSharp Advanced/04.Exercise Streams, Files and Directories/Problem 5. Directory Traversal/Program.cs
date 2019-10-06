using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5._Directory_Traversal
{
    class Program
    {
        static void Main()
        {
            var filesData = new Dictionary<string, Dictionary<string, long>>();
            Console.WriteLine("Enter Folder path to traverse");
            string path = Console.ReadLine();
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string outputFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\report.txt";
            DirectoryInfo di = new DirectoryInfo(path);
            var files = di.GetFiles();
            foreach (var file in files)
            {
                var extension = file.Extension;
                if (!filesData.ContainsKey(extension)) filesData.Add(extension, new Dictionary<string, long>());
                filesData[extension].Add(file.Name, file.Length);
            }
            var sortedFiles = filesData.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);

            using (StreamWriter output = new StreamWriter(outputFile))
            {
                foreach (var ext in sortedFiles)
                {
                    output.WriteLine($"{ext.Key}");
                    foreach (var file in ext.Value.OrderByDescending(x=>x.Value))
                    {
                        output.WriteLine($"--{file.Key} - {(file.Value / 1000.0):F3}kb");
                    }
                }
            }
        }
    }
}
