using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.Numerics;
using System.IO;

namespace ProjectEuler.Problems
{
	class Problem45 : Problem
	{
        public override void Run()
        {
            for(int i = 144; ; i++)
            {
                long num = i * (2 * i - 1);
                if(MathHelper.IsPentagonal(num))
                {
                    Console.WriteLine("Result is: {0}", num);
                    break;
                }
            }
        }
    }
}
