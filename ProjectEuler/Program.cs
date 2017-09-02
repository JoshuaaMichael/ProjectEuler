using System;
using ProjectEuler.Problems;
using System.Diagnostics;
using ProjectEulerLibrary;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Problem problem = new Problem18();
            problem.Setup();
            problem.PreRun();
            problem.Run();
            problem.PostRun();
            problem.Cleanup();
        }        
    }
}
