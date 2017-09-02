using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem61 : Problem
    {
        public override void Run()
        {
            //Calculate arrays
            int[] squareNumbers =       ListOfSquareNumbers(1000, 9999);
            int[] triangleNumbers =     ListOfTriangleNumbers(1000, 9999);
            int[] pentagonalNumbers =   ListOfPentagonalNumbers(1000, 9999);
            int[] hexagonalNumbers =    ListOfHexagonalNumbers(1000, 9999);
            int[] heptagonalNumbers =   ListOfHeptagonalNumbers(1000, 9999);
            int[] octagonalNumbers =    ListOfOctagonalNumbers(1000, 9999);

            //Remove unrequired values
            squareNumbers =         RemoveNumbersEndingInZero(squareNumbers);
            triangleNumbers =       RemoveNumbersEndingInZero(triangleNumbers);
            pentagonalNumbers =     RemoveNumbersEndingInZero(pentagonalNumbers);
            hexagonalNumbers =      RemoveNumbersEndingInZero(hexagonalNumbers);
            heptagonalNumbers =     RemoveNumbersEndingInZero(heptagonalNumbers);
            octagonalNumbers =      RemoveNumbersEndingInZero(octagonalNumbers);

            //Prepare lists for work
            Dictionary<string, int[]> polygonalTypes = new Dictionary<string, int[]>();

            polygonalTypes.Add("Square", squareNumbers);
            polygonalTypes.Add("Triangle", triangleNumbers);
            polygonalTypes.Add("Pentagonal", pentagonalNumbers);
            polygonalTypes.Add("Hexagonal", hexagonalNumbers);
            polygonalTypes.Add("Heptagonal", heptagonalNumbers);
            polygonalTypes.Add("Octagonal", octagonalNumbers);

            Console.WriteLine("Result is: {0}", 0);
        }

        private void Recursion(Dictionary<string, int[]> polygonalTypes)
        {
            foreach (KeyValuePair<string, int[]> polygonalType in polygonalTypes)
            {
                Dictionary<string, int[]> temp = new Dictionary<string, int[]>(polygonalTypes);
                temp.Remove(polygonalType.Key);

                int[] temp2 = polygonalType.Value;

                for (int i = 0; i < temp2.Length; i++)
                {

                }

                //int lastDigits = polygonalType % 100;

                //Recursion(temp);
            }
        }

        private static int[] ListOfSquareNumbers(int min, int max)
        {
            List<int> squareNumbers = new List<int>();

            for (int i = min; i <= max; i++)
            {
                if (MathHelper.IsTriangle(i))
                {
                    squareNumbers.Add(i);
                }
            }

            return squareNumbers.ToArray();
        }

        private static int[] ListOfTriangleNumbers(int min, int max)
        {
            List<int> triangleNumbers = new List<int>();

            for (int i = min; i <= max; i++)
            {
                if(MathHelper.IsTriangle(i))
                {
                    triangleNumbers.Add(i);
                }
            }

            return triangleNumbers.ToArray();
        }

        private static int[] ListOfPentagonalNumbers(int min, int max)
        {
            List<int> pentagonalNumbers = new List<int>();

            for (int i = min; i <= max; i++)
            {
                if (MathHelper.IsPentagonal(i))
                {
                    pentagonalNumbers.Add(i);
                }
            }

            return pentagonalNumbers.ToArray();
        }

        private static int[] ListOfHexagonalNumbers(int min, int max)
        {
            List<int> hexagonalNumbers = new List<int>();

            for (int i = min; i <= max; i++)
            {
                if (MathHelper.IsHexagonal(i))
                {
                    hexagonalNumbers.Add(i);
                }
            }

            return hexagonalNumbers.ToArray();
        }

        private static int[] ListOfHeptagonalNumbers(int min, int max)
        {
            List<int> heptagonalNumbers = new List<int>();

            for (int i = min; i <= max; i++)
            {
                if (MathHelper.IsHeptagonal(i))
                {
                    heptagonalNumbers.Add(i);
                }
            }

            return heptagonalNumbers.ToArray();
        }

        private static int[] ListOfOctagonalNumbers(int min, int max)
        {
            List<int> octagonalNumbers = new List<int>();

            for (int i = min; i <= max; i++)
            {
                if (MathHelper.IsOctagonal(i))
                {
                    octagonalNumbers.Add(i);
                }
            }

            return octagonalNumbers.ToArray();
        }

        private int[] RemoveNumbersEndingInZero(int[] numbers)
        {
            List<int> returnValue = new List<int>();
            for(int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] % 10 != 0)
                {
                    returnValue.Add(numbers[i]);
                }
            }
            return returnValue.ToArray();
        }
    }
}
