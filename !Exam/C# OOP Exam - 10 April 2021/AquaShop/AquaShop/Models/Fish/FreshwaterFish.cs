namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int InitialSize = 3;
        private const int SizeIncreaseValue = 3;

        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
        }

        public override int Size
            => InitialSize;

        public override void Eat()
            => Size += SizeIncreaseValue;
    }
}
