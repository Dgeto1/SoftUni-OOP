using System;
namespace _04.WildFarm
{
	public abstract class Animal
	{
		public string Name { get; set; }
		public double Weight { get; set; }
		public int FoodEaten { get; set; }

		public abstract string AskForFood();
	}
}

