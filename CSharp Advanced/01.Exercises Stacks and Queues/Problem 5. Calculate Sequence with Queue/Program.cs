using System;
using System.Collections.Generic;

namespace Problem_5._Calculate_Sequence_with_Queue
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            Queue<int> numbers = new Queue<int>();
            numbers.Enqueue(N);
            Console.Write($"{N} ");
            int count = 1;
            int oper = 1;
            while (count<51)
            {
                int next = numbers.Peek();
                int seqMember = 0;
                switch (oper)
                {
                    case 1:
                        seqMember = next + 1;
                        break;
                    case 2:
                        seqMember = 2*next + 1;
                        break;
                    case 3:
                        seqMember = next + 2;
                        break;
                }
                numbers.Enqueue(seqMember);
                Console.Write($"{seqMember} ");
                count++;
                oper++;
                if (oper >3)
                {
                    oper = 1;
                    numbers.Dequeue();
                }
            }
        }
    }
}
