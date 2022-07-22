namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Mouse : Mammal
    {
        public Mouse(string livingRegion, string name, double weight) 
            : base(livingRegion, name, weight)
        {

        }

        protected override IReadOnlyCollection<Type> PreferredFood => new List<Type> { typeof(Vegetable), typeof(Fruit) }.AsReadOnly();
        protected override double WeightModifier => 0.10;
        public override string AskForFood() => "Squeak";
        public override string ToString() => this.GetType().Name + base.ToString();
    }
}
