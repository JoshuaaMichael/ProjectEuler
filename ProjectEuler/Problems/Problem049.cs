using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Problems
{
	class Problem49 : Problem
	{
		public override void Run()
		{
            int[] primes = PrimeHelper.ArrayOfPrimeNumbersToMax(9999);
            HashSet<int> primeHashset = new HashSet<int>(primes);

            HashSet<string> tested = new HashSet<string>();

            foreach(int prime in primes)
            {
                if(prime.ToString().Length < 4)
                {
                    continue;
                }

                if(tested.Contains(prime.ToString()))
                {
                    continue;
                }
                
                //Now we have a four digit prime we haven't tested before

                List<string> permutations = new List<string>();
                string str = prime.ToString();
                char[] arr = str.ToCharArray();
                Permute(permutations, arr, 0, arr.Length - 1);

                List<int> primePermutations = new List<int>();
                foreach (string permute in permutations)
                {
                    if(MathHelper.IsPrime(int.Parse(permute)))
                    {
                        if(!primePermutations.Contains(int.Parse(permute)))
                        {
                            primePermutations.Add(int.Parse(permute));
                            tested.Add(permute);
                        }
                    }
                }

                primePermutations.Sort();

                List<int> arrSeqence = FindArithmeticSequence(primePermutations);

                if(arrSeqence != null)
                {
                    Console.WriteLine("Result:");
                    foreach (int num in arrSeqence)
                    {
                        Console.Write(" {0}", num);
                    }
                    Console.WriteLine();
                }
            }

		}

        private static void Permute(List<string> results, char[] elements, int recursionDepth, int maxDepth)
        {
            if (recursionDepth == maxDepth)
            {
                results.Add(new string(elements));
                return;
            }

            for (int i = recursionDepth; i <= maxDepth; i++)
            {
                Swap(ref elements[recursionDepth], ref elements[i]);
                Permute(results, elements, recursionDepth + 1, maxDepth);
                // backtrack
                Swap(ref elements[recursionDepth], ref elements[i]);
            }
        }

        private static void Swap(ref char a, ref char b)
        {
            char tmp = a;
            a = b;
            b = tmp;
        }

        private static List<int> FindArithmeticSequence(List<int> values)
        {
            for(int i = 0; i < values.Count - 1; i++)
            {
                for (int j = i + 1; j < values.Count; j++)
                {
                    if(values.Contains(2*values[j] - values[i]))
                    {
                        List<int> result = new List<int>();
                        result.Add(values[i]);
                        result.Add(values[j]);
                        result.Add(2 * values[j] - values[i]);
                        return result;
                    }
                }
            }
            return null;
        }
    }
}
