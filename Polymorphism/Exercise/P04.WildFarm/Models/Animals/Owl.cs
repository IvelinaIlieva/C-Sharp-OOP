namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Owl : Bird
    {
        public Owl(double wingSize, string name, double weight) 
            : base(wingSize, name, weight)
        {

        }

        protected override IReadOnlyCollection<Type> PreferredFood => new List<Type> { typeof(Meat) }.AsReadOnly();
        protected override double WeightModifier => 0.25;

        public override string AskForFood() => "Hoot Hoot";

        public override string ToString() => this.GetType().Name + base.ToString();
    }
}
