﻿using PlayersAndMonsters.IO.Contracts;
using System;

namespace PlayersAndMonsters.IO
{
    class Writer : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
