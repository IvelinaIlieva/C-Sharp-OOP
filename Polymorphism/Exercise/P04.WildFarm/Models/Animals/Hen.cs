namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Hen : Bird
    {
        public Hen(double wingSize, string name, double weight) 
            : base(wingSize, name, weight)
        {

        }

        protected override IReadOnlyCollection<Type> PreferredFood => new List<Type> { typeof(Meat), typeof(Vegetable), typeof(Fruit), typeof(Seeds) }.AsReadOnly();
        protected override double WeightModifier => 0.35;
        public override string AskForFood() => "Cluck";
        public override string ToString() => this.GetType().Name + base.ToString();
    }
}
