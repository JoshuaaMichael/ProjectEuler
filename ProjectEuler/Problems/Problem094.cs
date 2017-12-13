using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem94 : Problem
    {
        #region notes
        /*
            1. h^2 + ((b + 1)/2)^2 = b^2
            or
            2. h^2 + ((b - 1)/2)^2 = b^2

            case 1.

            https://www.wolframalpha.com/input/?i=solve(h%5E2+%2B+((b+%2B+1)%2F2)%5E2+%3D+b%5E2,+h)

            h = (1/2 sqrt(3 b^2 - 2 b - 1))

            case 2.
            h = (1/2 sqrt(3 b^2 + 2 b - 1))

            Area = 1/8 * (b ± 1) * sqrt(3 b^2 ± 2 b - 1)

            IsSquare(3 b^2 ± 2 b - 1)

            and 

            1/8 * (b ± 1) * sqrt(3 b^2 ± 2 b - 1) t
        */
        #endregion

        public override void Run()
        {

            Tuple<List<BigInteger>, HashSet<string>> result = ListOfSquares(1000000000);

            //for(int b = 1; b < 333333333; b++)
            //{
            //}

            Console.WriteLine("Result is: {0}", 0);
        }

        private Tuple<bool, bool> CheckMeetsInitialRequirements(int b)
        {
            long plusCaseNum = 3 * (b * b) + 2 * (b - 1);
            long minusCaseNum = 3 * (b * b) - 2 * (b - 1);

            bool plusCase = Math.Sqrt(plusCaseNum) % 1 == 0;
            bool minusCase = Math.Sqrt(minusCaseNum) % 1 == 0;

            return new Tuple<bool, bool>(plusCase, minusCase);
        }

        //base
        
        private Tuple<List<BigInteger>, HashSet<string>> ListOfSquares(int maxBase)
        {
            List<BigInteger> squares = new List<BigInteger>();

            BigInteger min = 0;
            BigInteger max = new BigInteger(maxBase) * new BigInteger(maxBase); //max=1b^2

            // (n+1)^2 = n^2 + 2*n + 1
            for (BigInteger n = 0; min < max; n++)
            {
                squares.Add(min);
                min = min + 2 * n + 1;
            }

            //Convert bases into the squares hashset
            HashSet<string> squaresHashset = new HashSet<string>(); //Can't contains on squares since reference

            foreach(BigInteger bi in squares)
            {
                squaresHashset.Add(bi.ToString());
            }

            Tuple<List<BigInteger>, HashSet<string>> result = new Tuple<List<BigInteger>, HashSet<string>>(squares, squaresHashset);

            return result;
        }

        private List<int> FindSquaresOfFixedDigits(int d)
        {
            List<int> square = new List<int>();

            int min = (int)Math.Pow(Math.Ceiling(Math.Sqrt(Math.Pow(10, d - 1))), 2);
            int max = (int)Math.Pow(10, d);

            // (n+1)^2 = n^2 + 2*n + 1
            for (int n = (int)Math.Sqrt(min); min < max; n++)
            {
                square.Add(min);
                min = min + 2 * n + 1;
            }

            return square;
        }
    }
}
