using System;
using ProjectEulerLibrary;
using System.IO;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem67 : Problem
    {
        public override void Run()
        {
            List<List<int>> triangle = Problem18.ReadTriangle("./Resources/p067_triangle.txt");

            for (int i = triangle.Count - 2; i >= 0; i--) //Start at second last line, then go up, first line will be result
            {
                for(int j = 0; j < triangle[i].Count; j++) //For each element in line, calculate which is max path from below
                {
                    triangle[i][j] += Math.Max(triangle[i+1][j], triangle[i+1][j+1]);
                }
            }

            Console.WriteLine("Result is: {0}", triangle[0][0]);
        }
    }
}
