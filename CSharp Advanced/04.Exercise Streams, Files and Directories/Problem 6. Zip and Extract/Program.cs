using System;
using System.IO;
using System.IO.Compression;

namespace Problem_6._Zip_and_Extract
{
    class Program
    {
        static void Main()
        {
            string outputFile = @"..\..\..\..\Resources\copyMe.png";
            Console.WriteLine("Choose existing folder to create zip file:");
            string zipFolder = Console.ReadLine() + @"\test.zip";
            //string zipFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+@"\test.zip";
            Console.WriteLine("Choose existing folder for unziping file:");
            string unzipFolder = Console.ReadLine();
            //string unzipFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (var archive = ZipFile.Open(zipFolder, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(outputFile, Path.GetFileName(outputFile));
            }
            using (var archive = ZipFile.Open(zipFolder, ZipArchiveMode.Read))
            {
                archive.ExtractToDirectory(unzipFolder);
            }
        }
    }
}
