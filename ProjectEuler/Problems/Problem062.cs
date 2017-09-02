using System;
using System.Collections.Generic;
using JoshuaaM.PrimeSieve;
using System.Linq;
using System.Numerics;
using ProjectEulerLibrary;

namespace ProjectEuler.Problems
{
	class Problem62 : Problem
	{
        public override void Run()
        {
            List<string> cubes = MakeCubeListOrdered(10000);
            HashSet<string> cubesHashset = new HashSet<string>(cubes);
            
            for (int i = 0; i < cubes.Count; i++)
            {
                int count = 1;
                for (int j = 0; j < cubes.Count; j++)
                {
                    if (i == j)
                        continue;
                    if (cubes[i] == cubes[j])
                        count++;
                    if (count == 5)
                    {
                        BigInteger temp = new BigInteger(i);
                        temp *= i;
                        temp *= i;
                        Console.WriteLine("Result is: {0}", temp);
                        return;
                    }
                }
            }
        }

        private static List<string> MakeCubeListOrdered(int maxBase)
        {
            List<string> cubes = new List<string>();
            for (BigInteger i = 0; i <= maxBase; i++)
            {
                string str = (i * i * i).ToString();
                char[] charStr = str.OrderByDescending(c => c).ToArray();
                cubes.Add(new string(charStr));
            }
            return cubes;
        }

        private List<string> RemoveDoubles(List<string> list)
        {
            HashSet<string> newList = new HashSet<string>();

            for(int i = 0; i < list.Count; i++)
            {
                if(!newList.Contains(list[i]))
                {
                    newList.Add(list[i]);
                }
            }

            return newList.ToList();
        }
    }
}
