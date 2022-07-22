namespace WildFarm.Models.Foods
{
    using Contracts;

    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }
        public int Quantity { get; }
    }
}
