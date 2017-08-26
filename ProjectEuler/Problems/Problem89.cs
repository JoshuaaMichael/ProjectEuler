using System;
using System.Numerics;
using ProjectEulerLibrary;
using System.IO;

namespace ProjectEuler.Problems
{
	class Problem89 : Problem
	{
        public override void Run()
        {
            string str = File.ReadAllText(@".\Resources\p089_roman.txt").Trim();

            int totalCharacters = str.Length - CountOccurance(str, "\n"); //Disregard carriage returns

            int difference = 0;

            difference += CountOccurance(str, "DCCCC") * 3; //DCCCC -> CM
            str = str.Replace("DCCCC", "");

            difference += CountOccurance(str, "CCCC") * 2; //CCCC -> CD
            str = str.Replace("CCCC", "");

            difference += CountOccurance(str, "LXXXX") * 3; //LXXXX -> XC
            str = str.Replace("LXXXX", "");

            difference += CountOccurance(str, "XXXX") * 2; //XXXX -> XL
            str = str.Replace("XXXX", "");

            difference += CountOccurance(str, "VIIII") * 3; //VIIII -> IX
            str = str.Replace("VIIII", "");

            difference += CountOccurance(str, "IIII") * 2; //IIII -> IV
            str = str.Replace("IIII", "");

            Console.WriteLine("Result is: {0}", difference);
        }

        public static int CountOccurance(string haystack, string needle)
        {
            return haystack.Split(new string[] { needle }, StringSplitOptions.None).Length - 1;
        }
    }
}
