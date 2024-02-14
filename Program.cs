using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics.Contracts;
using System.Diagnostics;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace PVA_Game
{
    internal class Program
    {
        static public char[,] displayArray = new char[10, 11];
        static public int moverPos = 2;
        static public int moverPosBefore = 0;
        static public int spacebarPressedTimes = 0;
        static public int levelChanged = 0;
        static public int freezeMoverPos = 0;
        static public int freezeMoverPosBefore = 0;
        static public int levelBefore = 0;
        static public bool stackAproved = false;
        static public int[] freezedLevelPoses = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        static public bool stackingChecked = false;
        static public int randomNumber = 100;

        static void Main(string[] args)
        {
            while (true)
            {
                SpaceCounter();
                if (spacebarPressedTimes == 0)
                {
                    SetBordersInArray();
                    MoverMove();
                    Console.WriteLine($"LEVEL: {levelChanged}");
                    Console.WriteLine($"SPEED: {randomNumber}");
                    Thread.Sleep(randomNumber);
                    Console.Clear();
                }
                else
                {
                    SetBordersInArray();
                    if (spacebarPressedTimes > levelBefore)
                    {
                        if (spacebarPressedTimes > 8) { spacebarPressedTimes = 8; }
                        else { levelChanged++; freezeMoverPos = moverPos; }
                        stackingChecked = false;
                        Pojebavac();
                    }
                    MoverMove();
                    stackChecker();
                    Console.WriteLine($"LEVEL: {levelChanged}");
                    Console.WriteLine($"SPEED: {randomNumber}");
                    Thread.Sleep(randomNumber);
                    Console.Clear();
                }
            }
        }

        static void Pojebavac()
        {
            if (spacebarPressedTimes > 2)
            {
                Random random = new Random();
                int chance = random.Next(1, 10);
                if (chance <= 2 +  spacebarPressedTimes - 2) { GenerateRandomSpeedHigh(); }
                else { GenerateRandomSpeed(); }
            }
         }

        static void GenerateRandomSpeed()
        {
            Random random = new Random();
            randomNumber = random.Next(50, 250);
        }

        static void GenerateRandomSpeedHigh()
        {
            Random random = new Random();
            randomNumber = random.Next(35, 100);
        }

        static void WinScreen()
        {
            Thread.Sleep(1000);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Clear();
            for (int i = 0; i < 10; i++) {
                Console.Clear();
                for (int a = 0; a < 16; a++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write("YOU WIN !!!\t");
                    }
                    Console.WriteLine();
                }
                Thread.Sleep(500);
                Console.Clear();
                for (int b = 0; b < 16; b++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write("Congratulations !!!\t");
                    }
                    Console.WriteLine();
                }
                Thread.Sleep(500);
            }
            Console.ReadKey();
            Environment.Exit(0);
        }

        static void LoseScreen()
        {
            Thread.Sleep(1000);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("YOU LOSE\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
            Environment.Exit(0);
        }

        static void stackChecker()
        {
            if ((freezedLevelPoses[levelChanged] == freezedLevelPoses[levelChanged -1]) || levelChanged < 2 )
            {
                if (levelChanged == 8 ) {WinScreen();}
                stackAproved = true;
                stackingChecked = true;
            }
            else {LoseScreen();}
        }

        static void SpaceCounter()
        {
            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar) { spacebarPressedTimes++; }
        }

        static void MoverMove()
        {
            if (spacebarPressedTimes <= 7)
            {
                displayArray[displayArray.GetLength(0) - 2 - spacebarPressedTimes, moverPos] = 'O';
            }

            freezedLevelPoses[levelChanged] = freezeMoverPos;
            for (int i = 1; i <= levelChanged; i++)
            {
                print(freezedLevelPoses[i], levelChanged - (levelChanged - i));   
            }
            levelBefore = levelChanged;

            foreach (var item in displayArray)
            {
                if (item == 'O')
                {
                    displayArray[displayArray.GetLength(0) - 2 - spacebarPressedTimes, moverPos - 1] = 'O';
                    displayArray[displayArray.GetLength(0) - 2 - spacebarPressedTimes, moverPos + 1] = 'O';
                }
            }

            while (true)
            {
                if (moverPos == displayArray.GetLength(1) - 3 || (moverPos < moverPosBefore && moverPosBefore != 3))
                {
                    moverPosBefore = moverPos;
                    moverPos--;
                    Display();
                    break;
                }
                else if (moverPos == 2 || moverPos > moverPosBefore)
                {
                    moverPosBefore = moverPos;
                    moverPos++;
                    Display();
                    break;
                }
                else
                {
                    Console.WriteLine("else triggerd - Exeption occured");
                }
            }
        }
        static void SetBordersInArray()
        {
            for (int i = 0; i < displayArray.GetLength(0); i++)
            {
                for (int j = 0; j < displayArray.GetLength(1); j++)
                {
                    if (i == 0 || i == displayArray.GetLength(0) - 1)
                    {
                        if ((i == 0 && j == displayArray.GetLength(1) - 1) )
                        {
                            displayArray[i, j] = '┐';
                        }
                        else if ((i == 0 && j == 0) )
                        {
                            displayArray[i, j] = '┌';
                        }
                        else if ((i == 0 && j == displayArray.GetLength(1) - 1) || (i == displayArray.GetLength(0) - 1 && j == displayArray.GetLength(1) - 1))
                        {
                            displayArray[i, j] = '┘';
                        }
                        else if ((i == 0 && j == 0) || (i == displayArray.GetLength(0) - 1 && j == 0))
                        {
                            displayArray[i, j] = '└';
                        }
                        else { displayArray[i, j] = '─'; }
                    }
                    else if (j == 0 || j == displayArray.GetLength(1) - 1)
                    {
                        displayArray[i, j] = '│';
                    }
                    else
                    {
                        displayArray[i, j] = ' ';
                    }
                }
            }
        }

        static void Display()
        {
            for (int i = 0; i < displayArray.GetLength(0); i++)
            {
                for (int j = 0; j < displayArray.GetLength(1); j++)
                {
                    Console.Write(displayArray[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void print(int x, int y)
        {
            displayArray[displayArray.GetLength(0) - (1 + y), x] = '#';
            displayArray[displayArray.GetLength(0) - (1 + y), x - 1] = '#';
            displayArray[displayArray.GetLength(0) - (1 + y), x + 1] = '#';
        }
    }
}
