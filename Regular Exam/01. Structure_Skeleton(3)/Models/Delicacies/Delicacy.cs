using System;
using System.Text;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Delicacies
{
	public abstract class Delicacy : IDelicacy
	{
		private string name;
		private double price;

        protected Delicacy(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name
		{
			get { return name; }
			private set
			{
				if(string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));
				}
				name = value;
			}
		}

        public double Price { get; private set; }

        public override string ToString()
        {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{Name} - {Price:f2} lv");

			return sb.ToString().Trim();
        }
    }
}

