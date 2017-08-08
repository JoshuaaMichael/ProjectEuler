using ProjectEulerLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class BenchMarking
    {
        private static void BenchmarkPrimeSieve(Action<int> act, int iterations, int maxNumber)
        {
            GC.Collect();
            act.Invoke(maxNumber); // run once outside of loop to avoid initialization costs
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                act.Invoke(maxNumber);
            }
            sw.Stop();
            Console.WriteLine("Avg time over {0} iterations: {1}ms", iterations, (sw.ElapsedMilliseconds / iterations));
        }

        public static void SUT(int maxNumber)
        {
            PrimeHelper.ArrayOfPrimeNumbersToMax(maxNumber);
        }

        static void Main2()
        {
            Action<int> a = SUT;
            BenchmarkPrimeSieve(a, 50, 100000000); //action, iterations, maxNumber
            Console.ReadLine();
        }
    }
}
