namespace WildFarm.Models.Animals
{
    using Contracts;

    public abstract class Bird : Animal, IBird
    {
        protected Bird(double wingSize, string name, double weight) 
            : base(name, weight)
        {
            WingSize = wingSize;
        }
        public double WingSize { get; }

        public override string ToString()
            => $" [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
    }
}
