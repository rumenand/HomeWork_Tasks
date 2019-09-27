using System;

namespace Problem5DateModifier
{
    public class StartUp
    {
        public static void Main()
        {
            var input1 = Console.ReadLine();
            var input2 = Console.ReadLine();
            Console.WriteLine(DateModifier.CalculateDifference(input1, input2));
        }
    }
}
