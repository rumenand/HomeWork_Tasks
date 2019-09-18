using System;
using System.Collections.Generic;

namespace Problem_6.__Songs_Queue
{
    class Program
    {
        static void Main()
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", "));
            while (songs.Count>0)
            {
                string [] command = Console.ReadLine().Split();
                switch (command[0])
                {
                    case "Play":
                        songs.Dequeue();
                        break;
                    case "Add":
                        List<string> songWords = new List<string>();
                        for (int i=1; i<command.Length; i++)
                        {
                            songWords.Add(command[i]);
                        }
                        string song = string.Join(" ", songWords);
                        if (!songs.Contains(song))  songs.Enqueue(song);
                        else Console.WriteLine($"{song} is already contained!");
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songs));
                        break;                       
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
