namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Dog : Mammal
    {
        public Dog(string livingRegion, string name, double weight) 
            : base(livingRegion, name, weight)
        {
        }

        protected override IReadOnlyCollection<Type> PreferredFood => new List<Type> { typeof(Meat) }.AsReadOnly();
        protected override double WeightModifier => 0.40;
        public override string AskForFood() => "Woof!";
        public override string ToString() => this.GetType().Name + base.ToString();
    }
}
