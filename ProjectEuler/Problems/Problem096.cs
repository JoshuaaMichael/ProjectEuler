using ProjectEuler.Problems.Classes;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectEuler.Problems
{
    class Problem96 : Problem
    {
        public override void Run()
        {
            List<SuDokuPuzzle> puzzles = ReadPuzzles("./Resources/p096_sudoku.txt");

            int sum = 0;

            foreach(SuDokuPuzzle puzzle in puzzles)
            {
                int[][] solution = puzzle.Solve();
                //sum += solution[0][0] + solution[1][0] + solution[2][0];
            }

            Console.WriteLine("Result is: {0}", sum);
        }

        public List<SuDokuPuzzle> ReadPuzzles(string filename)
        {
            List<string> strList = new List<string>(File.ReadAllLines(filename));
            strList.RemoveAll(u => u.Contains("Grid"));

            List<SuDokuPuzzle> puzzles = new List<SuDokuPuzzle>();

            for (int i = 0; i < strList.Count; i+=9) //Go through each puzzle in file
            {
                int[][] puzzleData = new int[9][];
                for(int j = 0; j < 9; j++) //Go through each row in puzzle
                {
                    int[] row = new int[9];
                    for (int k = 0; k < 9; k++) //Go through each digit in row
                    {
                        row[k] = strList[i + j][k] - '0';
                    }
                    puzzleData[j] = row;
                }
                puzzles.Add(new SuDokuPuzzle(puzzleData));
            }

            return puzzles;
        }
    }
}
