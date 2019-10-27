using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P06_Sneaking
{
    public static class GameBoard
    {
        private static Player playerSam;
        private static Player playerNikoladze;
        private static List<Enemy> enemies;
        private static int sizeX;
        private static int sizeY;

        public static void InitializeContetnt(int rows)
        {
            playerSam = new Player();
            playerNikoladze = new Player();
            enemies = new List<Enemy>();
            sizeX = rows;            
            for (int i = 0; i < sizeX; i++)
            {
                var row = Console.ReadLine();
                sizeY = row.Length;
                for (int j = 0; j < sizeY; j++)
                {
                    if (row[j] == 'N')
                    {
                        playerNikoladze.XPos = i;
                        playerNikoladze.YPos = j;
                    }
                    else if (row[j] == 'S')
                    {
                        playerSam.XPos = i;
                        playerSam.YPos = j;
                    }                    
                    else if (row[j] == 'b') enemies.Add(new Enemy(i, j, false));
                    else if (row[j] == 'd') enemies.Add(new Enemy(i, j, true));
                }
            }
        }

        internal static string PrintBoard(bool samDead)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    var enemy = enemies.Where(x => x.XPos == i && x.YPos == j).FirstOrDefault();
                    if (playerSam.XPos == i && playerSam.YPos == j)
                    {
                        if (samDead) sb.Append("X");
                        else sb.Append("S");
                        continue;
                    }
                    else if (playerNikoladze.XPos == i && playerNikoladze.YPos == j)
                    {
                        if (samDead) sb.Append("N");
                        else sb.Append("X");
                    }
                    else if (enemy != null)
                    {
                        if (enemy.GetDiection) sb.Append("d");
                        else sb.Append("b");
                    }
                    else sb.Append(".");
                }
                if (i != sizeX-1 )sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        internal static void CheckForSamKillsAnEnemy()
        {
            var result = enemies.Where(x => x.XPos == playerSam.XPos && x.YPos == playerSam.YPos).FirstOrDefault();
            if (result != null) enemies.Remove(result);
        }

        internal static bool CheckForSamKillsNikoladze()
        {
            if (playerSam.XPos == playerNikoladze.XPos) return true;
            else return false;
        }

        internal static void MoveSam(char move)
        {
            switch (move)
            {
                case 'U': playerSam.XPos--; break;
                case 'D': playerSam.XPos++; break;
                case 'L': playerSam.YPos--; break;
                case 'R': playerSam.YPos++; break;
            }
        }

        internal static bool ChekForEnemiesSeenSam()
        {
            foreach (var enemy in enemies)
            {
                if (enemy.XPos == playerSam.XPos)
                {
                    if (enemy.GetDiection && enemy.YPos > playerSam.YPos) return true;
                    if (!enemy.GetDiection && enemy.YPos < playerSam.YPos) return true;
                }
            }
            return false;
        }

        internal static string GetGameResult(bool samDead)
        {
            if (samDead) return $"Sam died at {playerSam.XPos}, {playerSam.YPos}";
            return $"Nikoladze killed!";
        }        

        public static void MoveEnemies()
        {
            foreach (var enemy in enemies)
            {
                if (enemy.GetDiection) // Left
                {
                    if (enemy.YPos > 0) enemy.YPos--;
                    else enemy.ChangeDirection();
                }
                else // Right
                {
                    if (enemy.YPos < sizeY-1) enemy.YPos++;
                    else enemy.ChangeDirection();
                }
            }
        }
    }
}
