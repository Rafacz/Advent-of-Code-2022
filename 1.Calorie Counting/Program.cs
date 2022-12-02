using System.Diagnostics;

namespace _1.Calorie_Counting
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var timer = new Stopwatch();
			timer.Start();

			var input = Directory.GetCurrentDirectory() + @"\input.txt";
			Console.WriteLine(Part1(input));
			Console.WriteLine(Part2(input));

			timer.Stop();

			Console.WriteLine("\n\nExecution time " + timer.ElapsedMilliseconds + "ms");
			Console.ReadLine();
		}

		private static int Part1(string input)
		{
			int topResult = 0;

			using (StreamReader sr = new StreamReader(input))
			{
				int buffer = 0;
				string line = String.Empty;
				while ((line = sr.ReadLine()!) is not null)
				{
					if (line != "")
					{
						buffer += Int32.Parse(line);
					}
					else
					{
						if (buffer > topResult)
						{
							topResult = buffer;
						}
						buffer = 0;
					}
				}
			}

			return topResult;
		}
		private static int Part2(string input)
		{
			int first = 0;
			int second = 0;
			int third = 0;

			using (StreamReader sr = new StreamReader(input))
			{
				int buffer = 0;
				string line = String.Empty;
				while ((line = sr.ReadLine()!) is not null)
				{
					if (line != "")
					{
						buffer += Int32.Parse(line);
					}
					else
					{
						if (buffer > first)
						{
							third = second;
							second = first;
							first = buffer;
						}
						else if (buffer > second)
						{
							third = second;
							second = buffer;
						}
						else if (buffer > third)
						{
							third = buffer;
						}
						buffer = 0;
					}
				}
			}

			return first + second + third;
		}


	}
}