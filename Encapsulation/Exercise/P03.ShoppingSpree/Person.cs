using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public double Money
        {
            get => this.money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public List<Product> BagOfProducts { get; set; }
        public override string ToString()
        {
            return this.BagOfProducts.Any()
                ? $"{this.Name} - {string.Join(", ", this.BagOfProducts.Select(p => p.Name).ToArray())}"
                : $"{this.Name} - Nothing bought";
        }
    }
}
