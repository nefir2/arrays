using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smart_getter_of_arrays
{
	class Program
	{
		private static void Main()
		{
			var array = Arrays.GetArray(x => Console.Write($"введите #{x} элемент массива: "), () => int.Parse(Console.ReadLine()), GetInt("введите размер массива: "), sorted: true);
			//Array.Sort(array);
			Arrays.ShowArray(array, true); //(x)th  => Console.Write(x + " ")
			Console.ReadKey(true);
		}
		/// <summary>
		/// получение значение типа <see cref="int"/> с консоли.
		/// </summary>
		/// <param name="message">сообщение перед вводом числа.</param>
		/// <returns>число введённое с консоли.</returns>
		public static int GetInt(string message)
		{
			Console.Write(message);
			return int.Parse(Console.ReadLine());
		}
	}
}