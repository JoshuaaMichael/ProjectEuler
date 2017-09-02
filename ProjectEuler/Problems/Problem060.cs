using System;
using System.Collections.Generic;
using JoshuaaM.PrimeSieve;
using System.Linq;

namespace ProjectEuler.Problems
{
	class Problem60 : Problem
	{
        public override void Run()
        {
            int[] primes = PrimeSieve.GeneratePrimesToMax(99999999, true);
            HashSet<int> primeHashset = new HashSet<int>(primes);

            List<List<int>> listOfShortLists = new List<List<int>>();

            for(int i = 1; primes[i].ToString().Length < 5; i++) //3
            {
                List<int> shortList = new List<int>(new int[] { primes[i] });
                for (int j = 1; primes[j].ToString().Length < 5; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    //Is forward and backwards a prime?
                    int forward = int.Parse(primes[i].ToString() + primes[j].ToString());
                    int backward = int.Parse(primes[j].ToString() + primes[i].ToString());
                    if (primeHashset.Contains(forward) && primeHashset.Contains(backward))
                    {
                        shortList.Add(primes[j]);
                    }
                }
                if (shortList.Count >= 5)
                {
                    listOfShortLists.Add(shortList);
                }
            }

            int minimumSum = int.MaxValue;
            List<int> currentList = new List<int>();

            for (int i = 0; i < listOfShortLists.Count; i++)
            {
                Recursive(primeHashset, listOfShortLists[i], ref minimumSum, currentList);
            }

            Console.WriteLine("Result is: {0}", minimumSum);
        }

        private void Recursive(HashSet<int> primeHashset, List<int> shortList, ref int minimumSum, List<int> currentList)
        {
            if(shortList.Count == 0)
            {
                return;
            }
            
            if (currentList.Count == 4) //Depth
            {
                currentList.Add(shortList[0]);
                if (currentList.Sum() < minimumSum)
                {
                    minimumSum = currentList.Sum();
                    //BUG: Finds other sets which have duplicate values in them
                }
            }
           
            while (shortList.Count != 0)
            {
                int currentValue = shortList[0];
                shortList.RemoveAt(0);
                currentList.Add(currentValue);

                List<int> shortList2 = new List<int>();

                for (int j = 0; j < shortList.Count; j++)
                {
                    //Is forward and backwards a prime?
                    int forward = int.Parse(currentValue.ToString() + shortList[j].ToString());
                    int backward = int.Parse(shortList[j].ToString() + currentValue.ToString());
                    if (primeHashset.Contains(forward) && primeHashset.Contains(backward))
                    {
                        shortList2.Add(shortList[j]);
                    }
                }

                Recursive(primeHashset, shortList2, ref minimumSum, currentList);

                currentList.Remove(currentValue);
            }
        }

        private bool IsCorrect(HashSet<int> primes, List<int> underTest)
        {
            List<Tuple<int, int>> nahh = new List<Tuple<int, int>>();
            foreach(int i in underTest)
            {
                foreach(int j in underTest)
                {
                    if(i == j)
                    {
                        continue;
                    }

                    int forward = int.Parse(i.ToString() + j.ToString());
                    int backward = int.Parse(j.ToString() + i.ToString());
                    if (!primes.Contains(forward) || !primes.Contains(backward))
                    {
                        nahh.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            return nahh.Count == 0;
        }
    }
}
