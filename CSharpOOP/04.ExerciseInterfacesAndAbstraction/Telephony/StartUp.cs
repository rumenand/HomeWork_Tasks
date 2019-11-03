using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main()
        {
            var smartphone = new Smartphone();
            var numbers = Console.ReadLine().Split();
            var sites = Console.ReadLine().Split();
            Console.WriteLine(smartphone.Dial(numbers));
            Console.WriteLine(smartphone.Browse(sites));
        }
    }
}
