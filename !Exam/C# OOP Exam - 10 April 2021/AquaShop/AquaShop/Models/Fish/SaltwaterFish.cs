namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int InitialSize = 5;
        private const int SizeIncreaseValue = 2;
        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {

        }
        public override int Size
            => InitialSize;

        public override void Eat()
            => Size += SizeIncreaseValue;
    }
}
