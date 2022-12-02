using System.Diagnostics;

namespace _2.Rock_Paper_Scissor
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
			int score = 0;
			using (StreamReader sr = new StreamReader(input))
			{
				string line = String.Empty;
				while ((line = sr.ReadLine()!) is not null)
				{
					switch (line)
					{
						case "A X":
							score += 4;
							break;
						case "A Y":
							score += 8;
							break;
						case "A Z":
							score += 3;
							break;
						case "B X":
							score += 1;
							break;
						case "B Y":
							score += 5;
							break;
						case "B Z":
							score += 9;
							break;
						case "C X":
							score += 7;
							break;
						case "C Y":
							score += 2;
							break;
						case "C Z":
							score += 6;
							break;
					}
				}
			}

			return score;
		}

		private static int Part2(string input)
		{
			int score = 0;
			using (StreamReader sr = new StreamReader(input))
			{
				string line = String.Empty;
				while ((line = sr.ReadLine()!) is not null)
				{
					switch (line)
					{
						case "A X":
							score += 3;
							break;
						case "A Y":
							score += 4;
							break;
						case "A Z":
							score += 8;
							break;
						case "B X":
							score += 1;
							break;
						case "B Y":
							score += 5;
							break;
						case "B Z":
							score += 9;
							break;
						case "C X":
							score += 2;
							break;
						case "C Y":
							score += 6;
							break;
						case "C Z":
							score += 7;
							break;
					}
				}
			}

			return score;
		}
	}
}