using System.Diagnostics;

namespace _5.Supply_Stacks
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

		private static string Part2(string input)
		{
			string output = "";
			var stacks = GetStacks(input);

			using (StreamReader sr = new StreamReader(input))
			{
				string line = String.Empty;
				while ((line = sr.ReadLine()!) is not null)
				{
					if (line.StartsWith("move"))
					{
						PerformInstructionExtended(line, ref stacks);
					}
				}
			}

			foreach (var c in stacks)
			{
				output += c.Peek();
			}

			return output;
		}
		static void PerformInstructionExtended(string instruction, ref List<Stack<char>> stacks)
		{
			var instructions = instruction.Split(' ');

			int move = int.Parse(instructions[1]);
			int from = int.Parse(instructions[3]) - 1;
			int to = int.Parse(instructions[5]) - 1;

			var buffer = new List<char>();

			for (int x = 0; x < move; x++)
			{
				buffer.Add(stacks[from].Pop());
			}

			buffer.Reverse();

			foreach (var b in buffer)
			{
				stacks[to].Push(b);
			}
		}

		private static string Part1(string input)
		{
			string output = "";
			var stacks = GetStacks(input);

			using (StreamReader sr = new StreamReader(input))
			{
				string line = String.Empty;
				while ((line = sr.ReadLine()!) is not null)
				{
					if (line.StartsWith("move"))
					{
						PerformInstruction(line, ref stacks);
					}
				}
			}

			foreach (var c in stacks)
			{
				output += c.Peek();
			}

			return output;
		}

		private static void PerformInstruction(string instruction, ref List<Stack<char>> stacks)
		{
			var instructions = instruction.Split(' ');

			int move = int.Parse(instructions[1]);
			int from = int.Parse(instructions[3]) - 1;
			int to = int.Parse(instructions[5]) - 1;

			for (int x = 0; x < move; x++)
			{
				var buffer = stacks[from].Pop();
				stacks[to].Push(buffer);
			}
		}

		private static List<Stack<char>> GetStacks(string input)
		{
			var stacks = new List<Stack<char>>();
			var stackLines = new List<string>();
			using (StreamReader sr = new StreamReader(input))
			{
				string line = String.Empty;
				while ((line = sr.ReadLine()!) is not null)
				{
					if (line == "")
					{
						stackLines.Reverse();
						break;
					}
					stackLines.Add(line);
				}
			}

			foreach (var stackLine in stackLines.Skip(1))
			{
				int counter = 0;
				for (int x = 1; x < stackLine.Length; x += 4)
				{
					if (stacks.Count == counter)
					{
						stacks.Add(new Stack<char>());
					}
					if (stackLine[x] != ' ')
					{
						stacks[counter].Push(stackLine[x]);
					}
					counter++;
				}
			}

			return stacks;
		}
	}
}