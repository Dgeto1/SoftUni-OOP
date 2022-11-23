using System;
using System.Collections.Generic;
using _03.ShoppingSpree;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        List<Product> products = new List<Product>();

        string[] segments = Console.ReadLine().Split(';');
        string[] seg = Console.ReadLine().Split(';');
        Product product;
        for (int i = 0; i < seg.Length; i++)
        {
            string[] pr = seg[i].Split('=');
            product = new Product(pr[0], decimal.Parse(pr[1]));
            products.Add(product);
        }
        Person person;
        for (int i = 0; i < segments.Length; i++)
        {
            string[] pr = segments[i].Split('=');
            person = new Person(pr[0], decimal.Parse(pr[1]));
            people.Add(person);
        }

        string command;
        
        while ((command = Console.ReadLine()) != "END")
        {
            segments = Console.ReadLine().Split();
            string name = segments[0];
            string prod = segments[1];
            int counter = 0;
            int counter2 = 0;
            foreach(Person x in people)
            {
                if(x.Name==name)
                {
                    break;
                }
                else counter++;
            }
            foreach (Product x in products)
            {
                if (x.Name == prod)
                {
                    break;
                }
                else counter2++;
            }
            people[counter].Buying(products[counter2]);
        }
        Console.Read();
        Console.WriteLine();
    }
}

