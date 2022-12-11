using System;
using System.Text;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        protected Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                name = value;
            }
        }

        public string Size { get; private set; }

        public double Price
        {
            get { return price; }
            private set
            {
                if(this.Size=="Large")
                {
                    price = value;
                }
                else if(this.Size == "Middle")
                {
                    price = (2 * value) / 3;
                }
                else
                {
                    price = value / 3;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} ({Size}) - {Price:f2} lv");

            return sb.ToString().Trim();
        }
    }
}

