using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics.Contracts;

namespace PVA_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameZoneInitiation();
            MoverInitiation();
            MoverMove();
            Console.ReadKey();
            
        }

        public static char[,] gameZone = new char[10, 11];
        public static int MoverHeight = 0;

        public static void MoverInitiation()
        {
            MoverHeight = 8;
            int MoverStage = 0;
            MoverHeight = MoverHeight - MoverStage;
            
            for (int x = 1; x <= 3 ; x++)
            {
                gameZone[x, MoverHeight] = 'O';
                Console.SetCursorPosition(x, MoverHeight);
                Console.Write(gameZone[x, MoverHeight]);
            }

        }
        public static bool isSpacePressed = false;
        public static void checkSpacePressed()
        {
            isSpacePressed = false;
            while (true)
            {
                isSpacePressed = false;
                if (Console.KeyAvailable)
                {

                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Spacebar)
                    {
                        isSpacePressed = true;
                    }
                }
            }
        }
        static void MoverMove()
        {

            
            while (isSpacePressed != true)
            {
                for (int i = 1; i < gameZone.GetLength(0) - 1; i++)
                {

                    Console.SetCursorPosition(i, MoverHeight);
                    bool was1stdeleted = false;
                    int howmanywasreplaced = 0;

                    if (gameZone[i, MoverHeight] == 'O' && was1stdeleted == false)
                    {
                        gameZone[i, MoverHeight] = ' ';
                        Console.Write(gameZone[i, MoverHeight]);
                        was1stdeleted = true;
                    }
                    else if (howmanywasreplaced < 3)
                    {
                        gameZone[i, MoverHeight] = 'O';
                        Console.Write(gameZone[i, MoverHeight]);
                        howmanywasreplaced++;
                    }
                    
                    
                    




                    Thread.Sleep(1000);
                    
                }
            }
        }

        
        
        
        public static void GameZoneInitiation()
        {
            
            for (int i = 0; i < gameZone.GetLength(0); i++)
            {
                for (int j = 0; j < gameZone.GetLength(1); j++)
                {
                    gameZone[i, j] = ' ';
                    if (i == 0 || i == 9)
                    {
                        gameZone[i, j] = '#';
                        Console.Write(gameZone[i,j]);
                    }
                    else
                    {
                        gameZone[i, 0] = '#';
                        gameZone[i, 10] = '#';
                        Console.Write(gameZone[i,j]);
                    }
                }
                Console.WriteLine();
                
            }
        }
    }
}
