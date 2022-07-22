namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Foods;

    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        protected abstract double WeightModifier { get; }
        protected abstract IReadOnlyCollection<Type> PreferredFood { get; }
        public string Name { get; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        public abstract string AskForFood();

        public void Feed(Food food)
        {
            if (!this.PreferredFood.Contains(food.GetType()))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            FoodEaten += food.Quantity;
            Weight += food.Quantity * WeightModifier;
        }
    }
}
