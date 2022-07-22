namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Tiger : Feline
    {
        public Tiger(string breed, string livingRegion, string name, double weight)
            : base(breed, livingRegion, name, weight)
        {

        }

        protected override IReadOnlyCollection<Type> PreferredFood => new List<Type> {typeof(Meat)}.AsReadOnly();
        protected override double WeightModifier => 1.00;
        public override string AskForFood() => "ROAR!!!";
        public override string ToString() => this.GetType().Name + base.ToString();
    }
}
