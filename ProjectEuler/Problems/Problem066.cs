using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
// ReSharper disable CompareOfFloatsByEqualityOperator

namespace ProjectEuler.Problems
{
    internal class Problem66 : Problem
    {
        public override void Run()
        {
            List<int> dList = Enumerable.Range(1, 100).ToList();
            dList.RemoveAll(u => Math.Sqrt(u) % 1 == 0.0);  //    Removes square numbers

            List<long> xList = new List<long>();

            foreach (int d in dList)
            {
                xList.Add(FindMinimalSolutionX(d));
            }

            long maxX = long.MinValue;
            int maxXi = 0;

            for (int i = 0; i < xList.Count; i++)
            {
                if (xList[i] <= maxX) continue;
                maxX = xList[i];
                maxXi = i;
            }

            Console.WriteLine("Result: {0}", dList[maxXi]);

        }

        private static long FindMinimalSolutionX(int d)
        {
            for (long x = 2; ; x++)
            {
                //y^2 = (x*x - 1) / D
                double value = (x * x - 1) / (double)d;
                if (value != Math.Truncate(value)) continue;
                if (Math.Sqrt(value) % 1 == 0.0) return x;
            }
        }
    }
}
