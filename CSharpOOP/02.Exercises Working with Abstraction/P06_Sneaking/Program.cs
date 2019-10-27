using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_Sneaking
{
    class Sneaking
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            GameBoard.InitializeContetnt(n);
            var moves = Console.ReadLine().ToCharArray();          
            bool samDead = false;
            foreach (var move in moves)
            {
                GameBoard.MoveEnemies();                
                if (GameBoard.ChekForEnemiesSeenSam())
                {
                    samDead = true;
                    break;
                }
                GameBoard.MoveSam(move);
                GameBoard.CheckForSamKillsAnEnemy();
                if (GameBoard.CheckForSamKillsNikoladze()) break;                
            }
            Console.WriteLine(GameBoard.GetGameResult(samDead));
            Console.WriteLine(GameBoard.PrintBoard(samDead));    
        }
    }
}
