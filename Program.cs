using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Lab_4
{
	class Program
	{
		static void Main(string[] args)
		{
			async Task<string> Result()
			{
				return await Task.Run(() => Generate()
			   .ContinueWith(task => Generates(task.Result))
			   .ContinueWith(task => Sum(task.Result.Result))
			   .ContinueWith(task => TransformToString(task.Result.Result))).Result;
			}

			async Task<int> Generate()
			{
				return new Random().Next(1, 25);
			}

			async Task<List<double>> Generates(int count)
			{
				Console.WriteLine(" Первый результат:");
				Console.WriteLine(count);
				var list = new List<double>();
				for (int i = 0; i < count; i++)
					list.Add(new Random().NextDouble());
				return list;
			}

			async Task<double> Sum(List<double> numbers)
			{
				Console.WriteLine("\n Второй результат:");
				foreach (double i in numbers)
				{ 
					Console.WriteLine($"{i:f3}"); 
				}
				return numbers.Sum();
			}

			async Task<string> TransformToString(double number)
			{
				Console.WriteLine("\n Третий результат:");
				Console.WriteLine($"{number:f3}");
				return "Строка " + number.ToString("f3");
			}

			var task = Result();
			Console.WriteLine("\n Четвертый результат:");
			Console.WriteLine($"{task.Result:f3}");
		}
	}
}