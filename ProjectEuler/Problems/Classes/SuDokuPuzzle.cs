using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems.Classes
{
    /*
        Only solves without guessing for now, to implement "guessing" logic, do the following:

        1. Detecting an unsolvable problem
        2. Implement ICloneable
        3. Implement a recursive solution which
    */

    class SuDokuPuzzle
    {
        class Digit
        {
            public int PosX { get; private set; }
            public int PosY { get; private set; }
            public List<int> Options { get; private set; }

            public Digit(int posX, int posY)
            {
                PosX = posX;
                PosY = posY;

                Options = new List<int>();
                for (int i = 1; i <= 9; i++)
                {
                    Options.Add(i);
                }
            }

            public void RemoveOption(int item)
            {
                Options.Remove(item);
            }

            public void RemoveAllOptionsExcept(int item)
            {
                Options.Clear();
                Options.Add(item);
            }

            public int GetDigit()
            {
                if(IsKnownValue())
                {
                    return Options[0];
                }
                throw new Exception("Do not know enough yet to calculate digit");
            }

            public void SetKnownValue(int digit)
            {
                Options.Clear();
                Options.Add(digit);
            }

            public bool IsKnownValue()
            {
                return Options.Count == 1;
            }
        }

        int[][] originalPuzzle;
        List<List<Digit>> workingPuzzle;

        bool[][] checkedDigitAgainstRow;
        bool[][] checkedDigitAgainstColumn;
        bool[][] checkedDigitAgainstBox;

        public SuDokuPuzzle(int[][] puzzle)
        {
            originalPuzzle = puzzle;
            InitialiseDigits();
            InitialiseArrays();
        }

        public int[][] Solve()
        {
            int i = 0;
            while(!IsSolved() && i < 10000)
            {
                for (int x = 0; x < 9; x++)
                {
                    for (int y = 0; y < 9; y++)
                    {
                        if (!checkedDigitAgainstRow[y][x])
                        {
                            CalculateOptionsRow(workingPuzzle[y][x]);
                        }
                        if(!checkedDigitAgainstColumn[y][x])
                        {
                            CalculateOptionsColumn(workingPuzzle[y][x]);
                        }
                        if (!checkedDigitAgainstBox[y][x])
                        {
                            CalculateOptionsBox(workingPuzzle[y][x]);
                        }
                    }
                }
                i++;
            }

            if(i == 10000)
            {
                PrintWorkingPuzzle();
                return null;
            }

            int[][] solution = GenerateSolutionFromOptions();
            return solution;
        }

        public bool IsSolved()
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if(!workingPuzzle[x][y].IsKnownValue())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private int[][] GenerateSolutionFromOptions()
        {
            int[][] solution = new int[9][];

            for (int x = 0; x < 9; x++)
            {
                int[] column = new int[9];
                for (int y = 0; y < 9; y++)
                {
                    column[y] = workingPuzzle[x][y].GetDigit();
                }
                solution[x] = column;
            }

            return solution;
        }

        private void CalculateOptionsRow(Digit digit)
        {
            //If this digits value is known, remove it from the options of other digits in the row
            if (digit.IsKnownValue())
            {
                RemoveDigitOptionFromRow(digit.PosY, digit.GetDigit(), digit.PosX);
                checkedDigitAgainstRow[digit.PosY][digit.PosX] = true;
            }
            else //If digits value isn't known
            {
                //Go through the list of options on the given digit
                //Check if any other digit in row has the same option, if none else do, by elimination this digit must be that value

                for (int i = 0; i < digit.Options.Count(); i++)
                {
                    bool found = false;

                    for (int x = 0; x < 9; x++)
                    {
                        if (x == digit.PosX)
                            continue;

                        if (workingPuzzle[digit.PosY][x].Options.Contains(digit.Options[i]))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        digit.SetKnownValue(digit.Options[i]);
                        break;
                    }
                }
            }
        }

        private void CalculateOptionsColumn(Digit digit)
        {
            //If this digits value is known, remove it from the options of other digits in the column
            if (digit.IsKnownValue())
            {
                RemoveDigitOptionFromColumn(digit.PosX, digit.GetDigit(), digit.PosY);
                checkedDigitAgainstColumn[digit.PosY][digit.PosX] = true;
            }
            else //If digits value isn't known
            {
                //Go through the list of options on the given digit
                //Check if any other digit in column has the same option, if none else do, by elimination this digit must be that value

                for (int i = 0; i < digit.Options.Count(); i++)
                {
                    bool found = false;

                    for (int y = 0; y < 9; y++)
                    {
                        if (y == digit.PosY)
                            continue;

                        if (workingPuzzle[y][digit.PosX].Options.Contains(digit.Options[i]))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        digit.SetKnownValue(digit.Options[i]);
                        break;
                    }
                }
            }
        }

        private void CalculateOptionsBox(Digit digit)
        {
            //Then iterate 0,2 for X&Y in box

            //Get box position in puzzle
            int boxX = digit.PosX / 3;
            int boxY = digit.PosY / 3;

            //If this digits value is known, remove it from the options of other digits in the box
            if (digit.IsKnownValue())
            {
                RemoveDigitOptionFromBox(boxX, boxY, digit.GetDigit(), digit.PosX, digit.PosY);
                checkedDigitAgainstBox[digit.PosY][digit.PosX] = true;
            }
            else //Digits value is not known
            {
                //Go through the list of options on the given digit
                //Check if any other digit in box has the same option, if none else do, by elimination this digit must be that value

                for (int i = 0; i < digit.Options.Count(); i++)
                {
                    bool found = false;

                    for (int x = boxX * 3; x < (boxX * 3) + 3 && !found; x++)
                    {
                        for (int y = boxY * 3; y < (boxY * 3) + 3; y++)
                        {
                            if (x == digit.PosX && y == digit.PosY)
                                continue;

                            if (workingPuzzle[y][x].Options.Contains(digit.Options[i]))
                            {
                                found = true;
                                break;
                            }
                        }
                    }

                    if (!found)
                    {
                        digit.SetKnownValue(digit.Options[i]);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="digit"></param>
        /// <returns>If digit was removed from at least 1 option in column</returns>
        private bool RemoveDigitOptionFromColumn(int row, int digit, int exceptionY)
        {
            bool removedDigit = false;

            for(int y = 0; y < 9; y++)
            {
                if(y == exceptionY)
                {
                    continue;
                }

                bool removed = workingPuzzle[y][row].Options.Remove(digit);

                if (removed)
                {
                    removedDigit = true;
                }
            }

            return removedDigit;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="digit"></param>
        /// <param name="exceptionX"></param>
        /// <returns>If digit was removed from at least 1 option in row</returns>
        private bool RemoveDigitOptionFromRow(int column, int digit, int exceptionX)
        {
            bool removedDigit = false;

            for (int x = 0; x < 9; x++)
            {
                if (x == exceptionX)
                {
                    continue;
                }

                bool removed = workingPuzzle[column][x].Options.Remove(digit);

                if (removed)
                {
                    removedDigit = true;
                }
            }

            return removedDigit;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boxX"></param>
        /// <param name="boxY"></param>
        /// <param name="digit"></param>
        /// <param name="exceptionX"></param>
        /// <param name="exceptionY"></param>
        /// <returns>If digit was removed from at least 1 option in box</returns>
        private bool RemoveDigitOptionFromBox(int boxX, int boxY, int digit, int exceptionX, int exceptionY)
        {
            bool removedDigit = false;

            for (int x = boxX * 3; x < (boxX * 3) + 3; x++)
            {
                for (int y = boxY * 3; y < (boxY * 3) + 3; y++)
                {
                    if (x == exceptionX && y == exceptionY)
                    {
                        continue;
                    }

                    bool removed = workingPuzzle[y][x].Options.Remove(digit);

                    if (removed)
                    {
                        removedDigit = true;
                    }
                }
            }

            return removedDigit;
        }

        private void InitialiseDigits()
        {
            workingPuzzle = new List<List<Digit>>();
            
            for (int y = 0; y < 9; y++)
            {
                workingPuzzle.Add(new List<Digit>());
                for (int x = 0; x < 9; x++)
                {
                    workingPuzzle[y].Add(new Digit(x, y));

                    if (originalPuzzle[y][x] != 0)
                    {
                        workingPuzzle[y][x].RemoveAllOptionsExcept(originalPuzzle[y][x]);
                    }
                }
            }
        }

        private void InitialiseArrays()
        {
            checkedDigitAgainstRow = new bool[9][];
            checkedDigitAgainstColumn = new bool[9][];
            checkedDigitAgainstBox = new bool[9][];

            for (int y = 0; y < 9; y++)
            {
                bool[] temp1 = new bool[9];
                checkedDigitAgainstRow[y] = temp1;
                bool[] temp2 = new bool[9];
                checkedDigitAgainstColumn[y] = temp2;
                bool[] temp3 = new bool[9];
                checkedDigitAgainstBox[y] = temp3;
            }
        }

        private void PrintWorkingPuzzle()
        {
            Console.WriteLine("Outputting puzzle");
            for(int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (workingPuzzle[y][x].IsKnownValue())
                    {
                        Console.Write(workingPuzzle[y][x].GetDigit());
                    }
                    else
                    {
                        Console.Write("0");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
