using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Q2
{

	public class Program
	{
		public static void Main()
		{
			int count = 0;
			string input;
			int err = 0;
			Dictionary<string, int> dict = new Dictionary<string, int>();

			//Reading input string from file and storing it in single string 'input'
			//If you get a system.securit exception for reading the input file in the mentioned path. Change your web config as mentioned here:
			// https://forums.asp.net/t/1422162.aspx
			try
			{
				using (StreamReader streamReader = new StreamReader(@"C:\Users\Sricharan\Desktop\Clevest\question02_input.txt"))
				{
					input = streamReader.ReadToEnd();
				}
				
				//Solution approach: I considered houses in a grid and string house is the "house number" represented by row and column values. The 				//combination of row and column value corresponds to co-ordinates like (row, col) which is unique to each house.

				string house = "";
				int row = 0;
				int col = 0;
				
				
				// Assumption: My initial position would be at the centre of the grid and the respective coordinates or the intial position is (0,0). Adding 		// that house at the start position to the dictionary
				dict.Add(row.ToString() + col.ToString(), 1);
				//iterate through the input string for each direction.
				for (int i = 0; i < input.Length; i++)
				{

					switch (input[i])
					{
						case '^':
							//north-goes up the grid i.e row changes but column stays the same
							row++;
							break;
						case 'v':
							//south-goes down the grid i.e row changes but column stays the same
							row--;
							break;
						case '<':
							//west-goes leftwards the grid i.e column changes but row stays the same
							col--;
							break;
						case '>':
							//east-goes rightwards the grid i.e column changes but row stays the same
							col++;
							break;
						default:
							//if any invalid input is provided other than the above cases.
							Console.WriteLine("Enter valid input");
							err = -1;
							break;
					}
					house = row.ToString() + col.ToString();

					if (dict.ContainsKey(house))
					{
						//Increment the value if key already exists
						dict[house]++;
					}
					else
					{
						//Add the key to the dictionary if it doesn't already exists
						dict.Add(house, 1);
					}

				}
			}
			catch (Exception e)
			{
				Console.WriteLine("{0} Exception caught.", e);
			}
			count = dict.Count();
			if (err != -1)
			{
				Console.WriteLine("Number of houses whose meters are read atleast once are:{0}", count);
			}
		}
	}

}
