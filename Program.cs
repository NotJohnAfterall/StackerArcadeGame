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
        static public int level1moverPos = 0;
        static public int level2moverPos = 0;
        static public int level3moverPos = 0;
        static public int level4moverPos = 0;
        static public int level5moverPos = 0;
        static public int level6moverPos = 0;
        static public int level7moverPos = 0;
        static public int level8moverPos = 0;
        static public int freezeMoverPos = 0;
        static public int freezeMoverPosBefore = 0;
        static public int hashtagIndexX = 0;
        static public int hashtagIndexY = 0;
        static public bool didlevelChanged = false;
        static public int levelBefore = 0;
        static public bool alreadypassed = false;
        static public bool stackAproved = false;
        static public int[] freezedLevelPoses = {level1moverPos, level2moverPos, level3moverPos, level4moverPos, level5moverPos, level6moverPos, level7moverPos, level8moverPos };



        static void Main(string[] args)
        {
            didlevelChanged = true;

            while (true)
            {
                Console.WriteLine(didlevelChanged);
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


                        //Thread.Sleep(1000);
                        didlevelChanged = false;




                    }
                    else
                    {
                        Console.WriteLine("else");
                    }

                    MoverMove();

                    Thread.Sleep(100);
                    Console.Clear();

                    

                }


            }




        }

        static void stackChecker()
        {
            if (freezeMoverPos > freezeMoverPosBefore)
            {
                if (freezeMoverPos == freezeMoverPosBefore - 1)
                {
                    //displayArray
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
                    level1moverPos = freezeMoverPos;
                    print(level1moverPos, levelChanged);
                    levelBefore = 1;
                    break;
                case 2:
                    level2moverPos = freezeMoverPos; freezeMoverPosBefore = level1moverPos;
                    print(level1moverPos, levelChanged-1);
                    print(level2moverPos, levelChanged);
                    levelBefore =2;
                    break;
                case 3:
                    level3moverPos = freezeMoverPos; freezeMoverPosBefore = level2moverPos;
                    print(level1moverPos, levelChanged - 2);
                    print(level2moverPos, levelChanged - 1);
                    print(level3moverPos, levelChanged);
                    levelBefore = 3;
                    break;
                case 4:
                    level4moverPos = freezeMoverPos; freezeMoverPosBefore = level3moverPos;
                    print(level1moverPos, levelChanged - 3);
                    print(level2moverPos, levelChanged - 2);
                    print(level3moverPos, levelChanged - 1);
                    print(level4moverPos, levelChanged);
                    levelBefore = 4;
                    break;
                case 5:
                    level5moverPos = freezeMoverPos; freezeMoverPosBefore = level3moverPos;
                    print(level1moverPos, levelChanged - 4);
                    print(level2moverPos, levelChanged - 3);
                    print(level3moverPos, levelChanged - 2);
                    print(level4moverPos, levelChanged - 1);
                    print(level5moverPos, levelChanged);
                    levelBefore = 5;
                    break;
                case 6:
                    level6moverPos = freezeMoverPos; freezeMoverPosBefore = level4moverPos;
                    print(level1moverPos, levelChanged - 5);
                    print(level2moverPos, levelChanged - 4);
                    print(level3moverPos, levelChanged - 3);
                    print(level4moverPos, levelChanged - 2);
                    print(level5moverPos, levelChanged - 1);
                    print(level6moverPos, levelChanged);
                    levelBefore = 6;
                    break;
                case 7:
                    level7moverPos = freezeMoverPos; freezeMoverPosBefore = level5moverPos;
                    print(level1moverPos, levelChanged - 6);
                    print(level2moverPos, levelChanged - 5);
                    print(level3moverPos, levelChanged - 4);
                    print(level4moverPos, levelChanged - 3);
                    print(level5moverPos, levelChanged - 2);
                    print(level6moverPos, levelChanged - 1);
                    print(level7moverPos, levelChanged);
                    levelBefore = 7;
                    break;
                case 8:
                    level8moverPos = freezeMoverPos;
                    print(level1moverPos, levelChanged - 7);
                    print(level2moverPos, levelChanged - 6);
                    print(level3moverPos, levelChanged - 5);
                    print(level4moverPos, levelChanged - 4);
                    print(level5moverPos, levelChanged - 3);
                    print(level6moverPos, levelChanged - 2);
                    print(level7moverPos, levelChanged - 1);
                    print(level8moverPos, levelChanged);
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
