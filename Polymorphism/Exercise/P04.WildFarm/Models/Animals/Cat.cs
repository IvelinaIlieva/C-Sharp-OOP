namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Cat : Feline
    {
        public Cat(string breed, string livingRegion, string name, double weight) 
            : base(breed, livingRegion, name, weight)
        {

        }

        protected override IReadOnlyCollection<Type> PreferredFood => new List<Type> { typeof(Meat), typeof(Vegetable) }.AsReadOnly();
        protected override double WeightModifier => 0.30;
        public override string AskForFood() => "Meow";
        public override string ToString() => this.GetType().Name + base.ToString();
    }
}
