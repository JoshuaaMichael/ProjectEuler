using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem66 : Problem
    {
        public override void Run()
        {
            BigInteger largestSquareNumber = new BigInteger(25000000) * new BigInteger(25000000);
            HashSet<BigInteger> squareHashset = new HashSet<BigInteger>();
            for(BigInteger i = 1; i <= 2500000000; i++)
            {
                squareHashset.Add(i * i);
            }

            List<int> D = new List<int>();

            for (int i = 1; i <= 1000; i++)
            {
                if(!IsASquareNumber(i))
                {
                    D.Add(i);
                }
            }

            BigInteger maxX = 0;

            foreach (int d in D)
            {
                BigInteger x = 0;
                BigInteger temp = 0;
                while (!squareHashset.Contains(temp))
                {
                    x++;

                    if ((x * x - 1) % d == 0)
                    {
                        temp = (x * x - 1) / d;
                    }
                    else
                    {
                        temp = 0;
                    }

                    if (temp > largestSquareNumber)
                    {
                        throw new Exception("Precomputed squares hashset isn't large enough");
                    }
                }

                if (x > maxX)
                {
                    maxX = x;
                }
            }


            Console.WriteLine("Result is: {0}", maxX);
        }

        private bool IsASquareNumber(int i)
        {
            return Math.Sqrt(i) % 1 == 0;
        }
    }
}
