using System;
using System.Collections.Generic;
namespace _03.ShoppingSpree
{
	public class Person
	{
		private string name;
		private decimal money;
		private List<Product> bag;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bag = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Name cannot be empty");
                else
                {
                    name = value;
                }
            }
        }

        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0) throw new ArgumentException("Money cannot be negative");
                else
                {
                    money = value;
                }
            }
        }

        public List<Product> Bag
        {
            get { return bag; }
            set { bag = value; }
        }

        public void Buying(Product product)
        {
            if(money>=product.Cost)
            {
                bag.Add(product);
                money -= product.Cost;
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }
        public override string ToString()
        {
            return $"{Name} - {String.Join(',', bag)}";
        }
    }
}

