using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem206 : Problem
    {
        public override void Run()
        {
            for (BigInteger i = 100000000; i < 140000000; i++)
            {
                BigInteger temp = i * i * 100;

                if (IsSolution(temp))
                {
                    Console.WriteLine("Result is: {0}", i * 10);
                    return;
                }
            }
        }

        private bool IsSolution(BigInteger value)
        {
            string str = value.ToString();
            
            for(int i = 0; i < 9; i++)
            {
                if(str[i + i] != 49 + i)
                {
                    return false;
                }
            }

            return (str[18] == 48);
        }
    }
}
