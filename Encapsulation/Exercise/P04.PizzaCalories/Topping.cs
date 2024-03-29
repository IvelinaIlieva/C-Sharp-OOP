﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P04.PizzaCalories
{
    public class Topping
    {
        private const double StartCalories = 2;
        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }
        public string ToppingType
        {
            get => this.toppingType;
            private set
            {
                if (value.ToLower() == "meat" || value.ToLower() == "veggies" || value.ToLower() == "cheese" || value.ToLower() == "sauce")
                {
                    this.toppingType = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        public double GetTotalCalories()
            => StartCalories * Weight * Modifiers.GetCalsByTopping(ToppingType);

    }
}
