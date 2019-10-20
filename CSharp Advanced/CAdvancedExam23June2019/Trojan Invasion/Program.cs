using System;
using System.Collections.Generic;
using System.Linq;

namespace Trojan_Invasion
{
    class Program
    {
        static void Main()
        {
            var waves = int.Parse(Console.ReadLine());
            var defencePlates = new Queue<int>(GetIntegerInput());
            bool winTrojans = false;
            for (int i = 0; i < waves; i++)
            {               
                var currentWave = new Stack<int>(GetIntegerInput());               
                if ((i+1) % 3 == 0) defencePlates.Enqueue(int.Parse(Console.ReadLine().Trim()));
                AttackWave(ref defencePlates, currentWave);
                if (defencePlates.Count == 0)
                {
                    Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                    Console.WriteLine($"Warriors left: {string.Join(", ",currentWave)}");
                    winTrojans = true;
                    break;
                }
            }
            if (!winTrojans)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ",defencePlates)}");
            }           
        }

        private static void AttackWave(ref Queue<int> defencePlates, Stack<int> currentWave)
        {
            var currentPlate = -1;
            while (currentWave.Count>0)
            {
                if ((currentPlate < 0) && (defencePlates.Count > 0)) currentPlate = defencePlates.Dequeue();
                else if (currentPlate<0 && defencePlates.Count ==0) break;
                currentPlate -= currentWave.Pop();
                if (currentPlate < 0)  currentWave.Push(currentPlate * -1);                
            }
            if (currentPlate>0)
            {
                defencePlates = new Queue<int>(defencePlates.Reverse());
                defencePlates.Enqueue(currentPlate);
                defencePlates = new Queue<int>(defencePlates.Reverse());
            }
        }

        private static IEnumerable<int> GetIntegerInput()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
        }
    }
}