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
        static public int hashtagIndex = 0;



        static void Main(string[] args)
        {
            
            
            while (true)
            {
                SpaceCounter();
                if (spacebarPressedTimes == 0)
                {
                    SetBordersInArray();
                    
                    MoverMove();
                    Thread.Sleep(100);
                    Console.Clear();
                }
                else 
                {
                    SetBordersInArray();                    
                    
                    if (levelChanged == 0)
                    {
                        levelChanged++;
                        afterSpacePress();
                        
                        
                        
                    }
                    
                    MoverMove();
                    
                    Thread.Sleep(100);
                    Console.Clear();

                    
                    
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

        static void printPrevious()
        {
            

        }
        static void MoverMove()
        {
            
            displayArray[displayArray.GetLength(0) - 2 - spacebarPressedTimes, moverPos] = 'O';
            
                if (spacebarPressedTimes >= 7)
                {
                    spacebarPressedTimes = 7;
                }
                switch (levelChanged)
                    {
                        case 1:
                            level1moverPos = freezeMoverPos;
                            printFreezed(freezeMoverPos, levelChanged);
                            
                            displayArray[displayArray.GetLength(0) - (1 + levelChanged), level1moverPos] = '#';
                            break;
                        case 2:
                            level2moverPos = freezeMoverPos;
                            displayArray[displayArray.GetLength(0) - (1 + levelChanged), level1moverPos] = '#';
                            break;
                        case 3:
                            level3moverPos = freezeMoverPos;
                            break;
                        case 4:
                            level4moverPos = freezeMoverPos;
                            break;
                        case 5:
                            level5moverPos = freezeMoverPos;
                            break;
                        case 6:
                            level6moverPos = freezeMoverPos;
                            break;
                        case 7:
                            level7moverPos = freezeMoverPos;
                            break;
                        case 8:
                            level8moverPos = freezeMoverPos;
                            break;
                    
                }
            GetHashtagIndex(displayArray);
            foreach (var item in displayArray)
            {
                if (item == 'O')
                {
                    displayArray[displayArray.GetLength(0) - 2 - spacebarPressedTimes, moverPos - 1] = 'O';
                    displayArray[displayArray.GetLength(0) - 2 - spacebarPressedTimes, moverPos + 1] = 'O';
                }
                else if (item == '#')
                {
                    displayArray[displayArray.GetLength(0) - (1 + levelChanged), hashtagIndex - 1] = '#';
                    displayArray[displayArray.GetLength(0) - (1 + levelChanged), hashtagIndex + 1] = '#';
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
          
        static void afterSpacePress()
        {

            freezeMoverPos = moverPos;
            displayArray[displayArray.GetLength(0) - (1 + levelChanged) , freezeMoverPos] = '#';
            printPrevious();
        }

        static void printFreezed(int xypos, int Lvlheight)
        {
            
        }
        static void GetHashtagIndex(char[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == '#')
                    {
                        hashtagIndex = j;
                    }
                }
            }
            
        }
        
    }
}
