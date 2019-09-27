using System;

namespace Problem_5._Date_Modifier___Core
{
    public class Program
    {
        public static void Main()
        {
            var input1 = Console.ReadLine();
            var input2 = Console.ReadLine();
            Console.WriteLine(DateModifier.CalculateDifference(input1, input2));
        }
    }
}
