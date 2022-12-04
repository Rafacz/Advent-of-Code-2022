using System.Diagnostics;

namespace _3.Rucksack_Reorganization
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
			int output = 0;
			using (StreamReader sr = new StreamReader(input))
			{
				string line = String.Empty;
				while ((line = sr.ReadLine()!) is not null)
				{
					var first = line.Substring(0, line.Length / 2).ToCharArray();
					var second = line.Substring(line.Length / 2, line.Length / 2).ToCharArray();

					var commonLetter = first.Intersect(second).First();
					var commonNumber = (int)commonLetter;

					if (commonNumber < 96)
						output += commonNumber - 64 + 26;
					else
						output += commonNumber - 96;
				}
			}

			return output;
		}

		private static int Part2(string input)
		{
			int output = 0;
			using (StreamReader sr = new StreamReader(input))
			{
				string line = String.Empty;
				while ((line = sr.ReadLine()!) is not null)
				{
					var first = line;
					var second = sr.ReadLine();
					var third = sr.ReadLine();

					var commonLetter = first.Intersect(second!).Intersect(third!).First();
					var commonNumber = (int)commonLetter;

					if (commonNumber < 96)
						output += commonNumber - 64 + 26;
					else
						output += commonNumber - 96;
				}
			}

			return output;
		}
	}
}