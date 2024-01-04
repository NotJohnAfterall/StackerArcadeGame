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
                else if (spacebarPressedTimes == 1)
                {
                    SetBordersInArray();                    
                    
                    if (levelChanged == 0)
                    {
                        afterSpacePress();
                        levelChanged++;
                        
                        
                    }
                    MoverMove();
                    Thread.Sleep(100);
                    Console.Clear();

                    
                    
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
            displayArray[displayArray.GetLength(0) - 2 - spacebarPressedTimes, moverPos] = 'O';

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

            if (level1moverPos != 0)
            {
                displayArray[displayArray.GetLength(0) - 2, level1moverPos - 1] = '#';
                displayArray[displayArray.GetLength(0) - 2, level1moverPos + 1] = '#';
                displayArray[displayArray.GetLength(0) - 2, level1moverPos] = '#';
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
            level1moverPos = moverPos;
            displayArray[displayArray.GetLength(0) - 2, level1moverPos] = '#';
        }
        
    }
}
