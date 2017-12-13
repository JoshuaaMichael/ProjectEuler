using System;
using ProjectEulerLibrary;
using System.Collections.Generic;
using System.IO;

namespace ProjectEuler.Problems
{
    class Problem98 : Problem
    {
        public override void Run()
        {
            int max = 0;

            List<Tuple<string, string>> anagrams = ReadFileIntoAnagrams("./Resources/p098_words.txt");

            for (int i = 0; i < anagrams.Count; i++)
            {
                List<int> squareList = FindSquaresOfFixedDigits(anagrams[i].Item1.Length);

                for (int j = 0; j < squareList.Count; j++)
                {
                    string str1 = anagrams[i].Item1;
                    string str2 = anagrams[i].Item2;

                    if (!AssignDigits(ref str1, ref str2, squareList[j]))
                    {
                        continue;
                    }

                    int num1 = int.Parse(str1);
                    int num2 = int.Parse(str2);

                    if(squareList.Contains(num2) && squareList.Contains(num1))
                    {
                        if (max < num2)
                            max = num2;
                        if (max < num1)
                            max = num1;
                        Console.WriteLine("Result is: {0}, {1}", num1, num2);
                    }
                }
            }
            
            Console.WriteLine("Result is: {0}", max);
        }
        
        private bool AssignDigits(ref string str1, ref string str2, int square)
        {
            int i = 1;
            bool[] digitUsed = new bool[10];

            while (square != 0)
            {
                int digit = square % 10;
                square /= 10;

                
                char replacedChar = str1[str1.Length - i];

                if (replacedChar != (char)(digit + '0'))
                {
                    for (int j = '0'; j <= '9'; j++)
                    {
                        if (replacedChar == j)
                        {
                            return false;
                        }
                    }
                }

                if (digitUsed[digit])
                {
                    return false;
                }

                digitUsed[digit] = true;

                str1 = str1.Replace(replacedChar, (char)(digit + '0'));
                str2 = str2.Replace(replacedChar, (char)(digit + '0'));

                i++;
            }

            return true;
        }

        private List<Tuple<string, string>> ReadFileIntoAnagrams(string filename)
        {
            string text = File.ReadAllText(filename);
            text = text.Replace('"', ' ');
            string[] words = text.Split(',');
            string[] wordsSorted = new string[words.Length];
            for(int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim();
                wordsSorted[i] = MathHelper.SortString(words[i]);
            }

            List<Tuple<string, string>> anagramsTemp = new List<Tuple<string, string>>();

            int maxLength = 0;

            for (int i = 0; i < wordsSorted.Length; i++) //For each sorted word, search through and look for others which match(thus are anagrams)
            {
                for (int j = i; j < wordsSorted.Length; j++)
                {
                    if(i == j)
                    {
                        continue;
                    }
                    if(wordsSorted[i] == wordsSorted[j])
                    {
                        if(wordsSorted[i].Length > maxLength)
                        {
                            maxLength = wordsSorted[i].Length;
                        }
                        Tuple<string, string> anagram = new Tuple<string, string>(words[i], words[j]);
                        anagramsTemp.Add(anagram);
                    }
                }
            }

            //Might be used to shortcut later
            List<Tuple<string, string>> anagrams = new List<Tuple<string, string>>();

            for(int i = maxLength; i > 0; i--)
            {
                for (int j = 0; j < anagramsTemp.Count; j++)
                {
                    if(anagramsTemp[j].Item1.Length == i)
                    {
                        anagrams.Add(anagramsTemp[j]);
                        anagramsTemp.RemoveAt(j);
                        j--;
                    }
                }
            }


            return anagrams;
        }

        private List<int> FindSquaresOfFixedDigits(int d)
        {
            List<int> square = new List<int>();
            
            int min = (int)Math.Pow(Math.Ceiling(Math.Sqrt(Math.Pow(10, d - 1))),2);
            int max = (int)Math.Pow(10, d);
            
            // (n+1)^2 = n^2 + 2*n + 1
            for (int n = (int)Math.Sqrt(min); min < max; n++)
            {
                square.Add(min);
                min = min + 2*n + 1;
            }

            return square;
        }
    }

    

}
