using System;
using System.Collections.Generic;

namespace Problem_10._Crossroads
{
    class Program
    {
        static void Main()
        {
            int greenLDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            var carsTail = new Queue<string>();
            string input;
            int totalPassed = 0;
            bool crashHappened = false;
            while((input = Console.ReadLine()) != "END")
            {
                if (input == "green")
                {
                    int greenLight = greenLDuration;
                    string nextCar = "";
                    while (greenLight>0 && carsTail.Count > 0)
                    {
                        nextCar = carsTail.Dequeue();
                        totalPassed++;
                        greenLight -= nextCar.Length;
                    }
                    if (greenLight < 0)
                    {
                        greenLight += nextCar.Length;
                        int crashIndex = nextCar.Length - (greenLight + freeWindow);
                        if (crashIndex > 0)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{nextCar} was hit at { nextCar[greenLight + freeWindow]}.");
                            crashHappened = true;
                            break;
                        }                        
                    }
                }
                else carsTail.Enqueue(input);
            }
            if (!crashHappened)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalPassed} total cars passed the crossroads.");
            }
        }
    }
}
