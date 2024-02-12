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
        //TODO: make when space is pressed the mover stops moving



        static public char[,] displayArray = new char[10, 11];
        static public char[,] systemArray = new char[10, 11];
        static public int moverPos = 2;
        static public int moverPosBefore = 0;
        static public int spacebarPressedTimes = 0;
        static public int levelChanged = 0;
        static public int freezeMoverPos = 0;
        static public int freezeMoverPosBefore = 0;
        static public int hashtagIndexX = 0;
        static public int hashtagIndexY = 0;
        static public int levelBefore = 0;
        static public bool alreadypassed = false;
        static public bool stackAproved = false;
        static public int[] freezedLevelPoses = {0, 0, 0, 0, 0, 0, 0, 0, 0};
        static public bool stackingChecked = false;
        static public int moverState = 0;
        static public int[] levelsPrintType = {0, 0, 0, 0, 0, 0, 0, 0, 0};


        //Mover states 0 = normal, 1 = 2x on right, 2 = 1x on right, -1 = 2x on left, -2 = 1x on left

        static void Main(string[] args)
        {

            
            while (true)
            {
                SpaceCounter();
                Console.WriteLine($"Variables {spacebarPressedTimes} {levelBefore}");
                if (spacebarPressedTimes == 0)
                {
                    Console.WriteLine("space = 0");
                    SetBordersInArray();
                    MoverMove();
                    Thread.Sleep(100);
                    Console.Clear();
                }
                else
                {
                    SetBordersInArray();
                    if (spacebarPressedTimes > levelBefore)
                    {

                        
                        Console.WriteLine($"LEVEL CHANGE TRIGERED {spacebarPressedTimes} {levelChanged}");
                        if (spacebarPressedTimes > 8) { spacebarPressedTimes = 8; }
                        else { levelChanged++; freezeMoverPos = moverPos; }
                        stackingChecked = false;

                        //Thread.Sleep(1000);




                    }
                    MoverMove();
                    stackChecker();

                    Thread.Sleep(100);
                    Console.Clear();

                }
            }
        }

        static void stackChecker()
        {
            for (int i = 0; i < displayArray.GetLength(1); i++)
            {
                if (displayArray[ displayArray.GetLength(0) - (spacebarPressedTimes + 1), i] == '#' && displayArray[displayArray.GetLength(0) -(spacebarPressedTimes + 1), i - 1] == '#' && spacebarPressedTimes -1 >= 2)
                {
                    stackAproved = true;
                    Console.WriteLine("approved");
                }
                else if (displayArray[displayArray.GetLength(0) - (spacebarPressedTimes + 1), i] == '#' && displayArray[displayArray.GetLength(0) - (spacebarPressedTimes + 1), i - 1] != '#')
                {
                    Console.Write(displayArray.GetLength(0) - spacebarPressedTimes); Console.WriteLine(i);
                    Console.WriteLine("failed");
                }
                else
                {
                    
                }
            }
        }

        static void SpaceCounter()
        {

            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Spacebar)
            {
                spacebarPressedTimes++;
            }


        }

        static void MoverMove()
        {
            if (spacebarPressedTimes <= 7)
            {
                displayArray[displayArray.GetLength(0) - 2 - spacebarPressedTimes, moverPos] = 'O';
            }
            

            
            switch (levelChanged)
            {
                case 1:
                    freezedLevelPoses[1] = freezeMoverPos; 
                    for (int i = 1; i <= 1; i++)
                    {
                        print(freezedLevelPoses[i], levelChanged - (1 - i), levelsPrintType[i]);
                    }
                    levelBefore = 1;
                    break;
                case 2:
                    freezedLevelPoses[2] = freezeMoverPos; freezeMoverPosBefore = freezedLevelPoses[1];
                    for (int i = 1; i <= 2; i++)
                    {
                        print(freezedLevelPoses[i], levelChanged - (2 - i), levelsPrintType[i]);
                    }
                    levelBefore = 2;
                    break;
                case 3:
                    freezedLevelPoses[3] = freezeMoverPos; freezeMoverPosBefore = freezedLevelPoses[2];
                    for (int i = 1; i <= 3; i++)
                    {
                        print(freezedLevelPoses[i], levelChanged - (3 - i), levelsPrintType[i]);
                    }
                    levelBefore = 3;
                    break;
                case 4:
                    freezedLevelPoses[4] = freezeMoverPos; freezeMoverPosBefore = freezedLevelPoses[3];
                    for (int i = 1; i <= 4; i++)
                    {
                        print(freezedLevelPoses[i], levelChanged - (4 - i), levelsPrintType[i]);
                    }
                    levelBefore = 4;
                    break;
                case 5:
                    freezedLevelPoses[5] = freezeMoverPos; freezeMoverPosBefore = freezedLevelPoses[3];
                    for (int i = 1; i <= 5; i++)
                    {
                        print(freezedLevelPoses[i], levelChanged - (5 - i), levelsPrintType[i]);
                    }
                    levelBefore = 5;
                    break;
                case 6:
                    freezedLevelPoses[6] = freezeMoverPos; freezeMoverPosBefore = freezedLevelPoses[4];
                    for (int i = 1; i <= 6; i++)
                    {
                        print(freezedLevelPoses[i], levelChanged - (6 - i), levelsPrintType[i]);
                    }
                    levelBefore = 6;
                    break;
                case 7:
                    freezedLevelPoses[7] = freezeMoverPos; freezeMoverPosBefore = freezedLevelPoses[5];
                    for (int i = 1; i <= 7; i++)
                    {
                        print(freezedLevelPoses[i], levelChanged - (7 - i), levelsPrintType[i]);
                    }
                    levelBefore = 7;
                    break;
                case 8:
                    freezedLevelPoses[8] = freezeMoverPos;
                    for (int i = 1; i <= 8; i++)
                    {
                        print(freezedLevelPoses[i], levelChanged - (8 - i), levelsPrintType[i]);
                    }
                    levelBefore = 8;
                    break;

            }
            
            foreach (var item in displayArray)
            {
                if (item == 'O')
                {
                    displayArray[displayArray.GetLength(0) - 2 - spacebarPressedTimes, moverPos - 1] = 'O';
                    displayArray[displayArray.GetLength(0) - 2 - spacebarPressedTimes, moverPos + 1] = 'O';
                }
                else if (item == '#')
                {
                    
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
                    Console.WriteLine("else triggerd");


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
                        displayArray[i, j] = '─';
                    }
                    else if (j == 0 || j == displayArray.GetLength(1) - 1)
                    {
                        displayArray[i, j] = '|';
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

        static void print(int x, int y, int printtype)
        {

            switch (printtype)
            {
                case 0:
                    displayArray[displayArray.GetLength(0) - (1 + y), x] = '#';
                    displayArray[displayArray.GetLength(0) - (1 + y), x - 1] = '#';
                    displayArray[displayArray.GetLength(0) - (1 + y), x + 1] = '#';
                    break;
                case 1:
                    displayArray[displayArray.GetLength(0) - (1 + y), x] = '#';
                    displayArray[displayArray.GetLength(0) - (1 + y), x + 1] = '#';
                    break;
                case 2:
                    displayArray[displayArray.GetLength(0) - (1 + y), x + 1] = '#';
                    break;
                case -1:
                    displayArray[displayArray.GetLength(0) - (1 + y), x] = '#';
                    displayArray[displayArray.GetLength(0) - (1 + y), x - 1] = '#';
                    break;
                case -2:
                    displayArray[displayArray.GetLength(0) - (1 + y), x - 1] = '#';
                    break;
            }
            //if (printType == 0)
            //{
            //    displayArray[displayArray.GetLength(0) - (1 + y), x] = '#';
            //    displayArray[displayArray.GetLength(0) - (1 + y), x - 1] = '#';
            //    displayArray[displayArray.GetLength(0) - (1 + y), x + 1] = '#';
            //}


        }

    }
}
