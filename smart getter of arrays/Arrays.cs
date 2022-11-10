using System;
namespace smart_getter_of_arrays
{
	public class Arrays : IComparable<Arrays>, ICloneable, IEquatable<Arrays>
	{
		#region Arrays' object
		private string tostring;
		public string Name { get => tostring; set => tostring = value ?? "Arrays"; }
		public Arrays() { tostring = "Arrays"; }
		public Arrays(string idk) { tostring = idk; }
		public static explicit operator Arrays(string v) => new Arrays(v);
		public override string ToString() => tostring;
		#endregion
		#region implementations
		public int CompareTo(Arrays other) => this.tostring.CompareTo(other.tostring); //this.tostring.Length - other.tostring.Length + 
		public object Clone() => new Arrays(tostring);
		public bool Equals(Arrays other) => this.tostring == other.tostring;
		#endregion
		#region statics
		/// <summary>
		/// получение массива элементов типа <typeparamref name="T"/>.
		/// </summary>
		/// <typeparam name="T">тип элементов возвращаемого массива.</typeparam>
		/// <param name="elementMessage">метод выводящий сообщение для ввода элемента массива.</param>
		/// <param name="elementGetter">метод получения элемента массива.</param>
		/// <param name="length">длина массива.</param>
		/// <param name="message">сообщение ввода всего массива перед началом цикла ввода элементов.</param>
		/// <param name="sorted">
		/// логическая переменная определяющая:<br/>
		/// возвращать сортированный массив, или нет.<br/><br/>
		/// если <see langword="true"/> массив после ввода сортируется,<br/>
		/// иначе возвращается так, как был введён.
		/// </param>
		/// <returns>массив элементов типа <typeparamref name="T"/>.</returns>
		public static T[] GetArray<T>(Action<int> elementMessage, Func<T> elementGetter, int length = 10, string message = "введите массив.", bool sorted = false)
		{
			T[] array = new T[length];
			Console.WriteLine(message);
			for (int i = 0; i < array.Length; i++)
			{
				elementMessage.Invoke(i);
				array[i] = elementGetter.Invoke();
			}
			if (sorted) Array.Sort(array);
			return array;
		}
		/// <summary>
		/// вывод массива элементов типа <typeparamref name="T"/>.
		/// </summary>
		/// <typeparam name="T">тип элементов массива.</typeparam>
		/// <param name="array">массив, который надо вывести.</param>
		/// <param name="EndLine">
		/// логическая переменная обозначающая:<br/>
		/// заканчивать вывод элемента массива переносом курсора, или пробелом.<br/><br/>
		/// если <see langword="true"/> используется перенос курсора, <br/>
		/// иначе используется пробел.
		/// </param>
		public static void ShowArray<T>(T[] array, bool EndLine)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (EndLine) Console.WriteLine(array[i]);
				else Console.Write(array[i] + " ");
			}
		}
		/// <summary>
		/// вывод массива элементов типа <typeparamref name="T"/>.
		/// </summary>
		/// <typeparam name="T">тип элементов массива.</typeparam>
		/// <param name="array">массив, который надо вывести.</param>
		/// <param name="FormatOutput">метод вывода элементов массива.</param>
		public static void ShowArray<T>(T[] array, Action<T> FormatOutput)
		{
			for (int i = 0; i < array.Length; i++) FormatOutput.Invoke(array[i]);
		}
		#endregion
	}
}