using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProjectEuler.Problems
{
    class Problem40 : Problem
    {
        public override void Run()
        {
            StringBuilder str = new StringBuilder();

            for(int i = 1; i <= 1000000; i++)
            {
                str.Append(i.ToString());
            }

            string outputStr = str.ToString();
            int total = 1;
            for(int i = 1; i <= 1000000; i*=10) {
            {
                total *= int.Parse(outputStr[i - 1] + "");
            }

            Console.WriteLine("Result is: {0}", total);
        }
    }
}
