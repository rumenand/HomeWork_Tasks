using System;

namespace DateModifier
{
    class StatUp
    {
        static void Main()
        {
            var input1 = Console.ReadLine();
            var input2 = Console.ReadLine();
            Console.WriteLine(DateModifier.CalculateDifference(input1, input2));
        }
    }
}
