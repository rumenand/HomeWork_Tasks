using System;

namespace _3Ferrari
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var car = new Ferrari(Console.ReadLine());
            Console.WriteLine(car);
        }
    }
}
