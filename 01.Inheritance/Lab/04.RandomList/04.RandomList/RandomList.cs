using System;
using System.Collections.Generic;
namespace CustomRandomList
{
	public class RandomList : List<string>
	{
		public Random R { get; set; }

		public RandomList()
		{
			R = new Random();
		}
		public string RandomString()
		{
			string removedElement = this[R.Next(0, Count)];

			this.Remove(removedElement);

			return removedElement;
		}
	}
}

