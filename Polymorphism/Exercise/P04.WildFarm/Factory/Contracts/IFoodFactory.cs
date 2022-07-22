namespace WildFarm.Factory.Contracts
{
    using Models.Foods;

    public interface IFoodFactory
    {
        Food CreateFood(string[] input);
    }
}
