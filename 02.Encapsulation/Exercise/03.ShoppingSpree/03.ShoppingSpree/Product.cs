using System;
namespace _03.ShoppingSpree
{
	public class Product
	{
		private string name;
		private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
		{
			get { return name; }
			private set
			{
				if (string.IsNullOrEmpty(value)) throw new ArgumentException("Name cannot be empty");
				else
				{
					name = value;
				}
			}
		}
		public decimal Cost
		{
			get { return cost; }
			private set { cost = value; }
		}
	}
}

