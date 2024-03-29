﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.PizzaCalories
{
    public class Pizza
    {
        private string name;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.Toppings = new List<Topping>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough { get; }

        public List<Topping> Toppings { get; }

        public void AddTopping(Topping topping)
        {
            if (Toppings.Count < 10)
            {
                Toppings.Add(topping);
            }
            else
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            
        }

        public double GetTotalCalories()
        {
            return Dough.GetTotalCalories() + Toppings.Sum(t => t.GetTotalCalories());
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.GetTotalCalories():f2} Calories.";
        }
    }
}
