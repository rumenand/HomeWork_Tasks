using System;
using System.IO;

namespace Problem_4._Copy_Binary_File
{
    class Program
    {
        static void Main()
        {
            string inputFile = @"..\..\..\..\Resources\copyMe.png";
            string outputPath = @"..\..\..\Output";
            Directory.CreateDirectory(outputPath);
            string outputFile = outputPath+@"\output.png";
            long length = new FileInfo(inputFile).Length;
            using (FileStream stream = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[(int)length];
                stream.Read(bytes, 0, (int)length);
                using (FileStream fsNew = new FileStream(outputFile,FileMode.Create, FileAccess.Write))
                {
                    fsNew.Write(bytes, 0, (int)length);
                }
            }
        }
    }
}
