namespace WildFarm.Models.Animals
{
    using Contracts;

    public abstract class Mammal : Animal, IMammal
    {
        protected Mammal(string livingRegion, string name, double weight) 
            : base(name, weight)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; }

        public override string ToString() => $" [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
