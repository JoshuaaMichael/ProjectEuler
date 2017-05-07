using System;
using ProjectEulerLibrary;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
	class Problem9 : Problem
	{
		public override void Run()
		{
			int value = 0;
			bool quit = false;

			//Brute force is fine since the number is low
			for(int a = 0; a < 1000 && !quit; a++)
			{
				for (int b = 0; b < 1000 && !quit; b++)
				{
					for (int c = 0; c < 1000 && !quit; c++)
					{
						if(a < b && b < c)
						{
							if(a * a + b * b == c * c) //Pythag
							{
								if(a + b + c == 1000)
								{
									value = a * b * c;
									break;
								}
							}
						}
					}
				}
			}

			Console.WriteLine("Result is: {0}", value);
		}
	}
}
