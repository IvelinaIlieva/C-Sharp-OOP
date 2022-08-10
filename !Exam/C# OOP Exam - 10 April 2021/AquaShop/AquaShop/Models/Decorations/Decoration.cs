namespace AquaShop.Models.Decorations
{
    using Contracts;

    public class Decoration : IDecoration
    {
        public Decoration(int comfort, decimal price)
        {
            Comfort = comfort;
            Price = price;
        }
        public int Comfort { get; }
        public decimal Price { get; }
    }
}
