using System.Diagnostics;

namespace _6.Tuning_Trouble
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
			using (StreamReader sr = new StreamReader(input))
			{
				string line = sr.ReadLine()!;
				var buffer = new char[4];
				var chars = line.ToCharArray();

				for (int i = 0; i < chars.Length; i++)
				{
					buffer[0] = chars[i];
					buffer[1] = chars[i + 1];
					buffer[2] = chars[i + 2];
					buffer[3] = chars[i + 3];

					if (buffer.Distinct().Count() == buffer.Length)
					{
						return i + 4;
					}
				}
			}

			return 0;
		}

		private static int Part2(string input)
		{
			using (StreamReader sr = new StreamReader(input))
			{
				string line = sr.ReadLine()!;
				var buffer = new char[14];
				var chars = line.ToCharArray();

				for (int i = 0; i < chars.Length; i++)
				{
					for (int x = 0; x < 14; x++)
					{
						buffer[x] = chars[i + x];
					}

					if (buffer.Distinct().Count() == buffer.Length)
					{
						return i + 14;
					}
				}
			}

			return 0;
		}

	}
}