namespace WildFarm.Models.Animals
{
    using Contracts;

    public abstract class Feline : Mammal, IFeline
    {
       protected Feline(string breed, string livingRegion, string name, double weight) : base (livingRegion, name, weight)
        {
            Breed = breed;
        }
        public string Breed { get; }

        public override string ToString() => $" [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
