using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProjectEuler.Problems
{
    public abstract class Problem
    {
        Stopwatch timer;
        public virtual void Setup()
        {
            timer = new Stopwatch();
        }
        public virtual void PreRun()
        {
            timer.Start();
        }
        public abstract void Run();
        public virtual void PostRun()
        {
            timer.Stop();
        }
        public virtual void Cleanup()
        {
            Console.WriteLine();
            Console.WriteLine("Solution took: {0} hours, {1} mintes, {2} seconds, {3} milliseconds", timer.Elapsed.Hours, timer.Elapsed.Minutes, timer.Elapsed.Seconds, timer.Elapsed.Milliseconds);
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
