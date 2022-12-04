using System.Diagnostics;

namespace _4.Camp_Cleanup
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
					var pair = line.Split(',');
					var firstElf = new Tuple<int, int>(Int32.Parse(pair[0].Split('-')[0]), Int32.Parse(pair[0].Split('-')[1]));
					var secondElf = new Tuple<int, int>(Int32.Parse(pair[1].Split('-')[0]), Int32.Parse(pair[1].Split('-')[1]));

					if (firstElf.Item1 <= secondElf.Item1 && firstElf.Item2 >= secondElf.Item2 ||
						firstElf.Item1 >= secondElf.Item1 && firstElf.Item2 <= secondElf.Item2)
						output++;
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
					var pair = line.Split(',');
					var firstElf = new Tuple<int, int>(Int32.Parse(pair[0].Split('-')[0]), Int32.Parse(pair[0].Split('-')[1]));
					var secondElf = new Tuple<int, int>(Int32.Parse(pair[1].Split('-')[0]), Int32.Parse(pair[1].Split('-')[1]));

					if (firstElf.Item1 <= secondElf.Item2 && firstElf.Item2 >= secondElf.Item1)
						output++;
				}
			}

			return output;
		}
	}
}