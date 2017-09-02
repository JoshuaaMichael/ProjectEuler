using System;
using ProjectEulerLibrary;
using System.IO;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem18 : Problem
    {
        public override void Run()
        {
            /*
               3
              7 4
             2 4 6
            8 5 9 3
            */

            List<List<int>> triangle = ReadTriangle("./Resources/p018_triangle.txt");

            for(int i = triangle.Count - 2; i >= 0; i--) //Start at second last line, then go up, first line will be result
            {
                for(int j = 0; j < triangle[i].Count; j++) //For each element in line, calculate which is max path from below
                {
                    triangle[i][j] += Math.Max(triangle[i+1][j], triangle[i+1][j+1]);
                }
            }

            Console.WriteLine("Result is: {0}", triangle[0][0]);
        }

        public static List<List<int>> ReadTriangle(string filename)
        {
            string[] lines = File.ReadAllLines(filename);

            List<List<int>> triangle = new List<List<int>>();

            foreach (string line in lines)
            {
                List<int> temp = new List<int>();
                string[] numbers = line.Trim().Split(' ');
                foreach (string num in numbers)
                {
                    temp.Add(int.Parse(num));
                }
                triangle.Add(temp);
            }
            return triangle;
        }
    }
}
