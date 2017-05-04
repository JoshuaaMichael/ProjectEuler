using System;
using ProjectEuler.Problems;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Problem problem = new Problem1();
            problem.Setup();
            problem.Run();
            problem.Cleanup();

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
