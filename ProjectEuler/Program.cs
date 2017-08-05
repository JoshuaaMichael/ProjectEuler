using System;
using ProjectEuler.Problems;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Problem problem = new Problem36();
            problem.Setup();
            problem.PreRun();
            problem.Run();
            problem.PostRun();
            problem.Cleanup();
        }
    }
}
