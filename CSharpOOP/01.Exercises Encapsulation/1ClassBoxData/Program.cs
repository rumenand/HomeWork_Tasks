using System;

namespace _1ClassBoxData
{
    class Program
    {
        static void Main()
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            Box newBox = null;
            try
            {
                newBox = new Box(length, width, height);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"{e.Message}");
                return;
            }            
                Console.WriteLine(newBox.SurfaceArea());
                Console.WriteLine(newBox.LateralSurface());
                Console.WriteLine(newBox.Volume());            
        }
    }
}
