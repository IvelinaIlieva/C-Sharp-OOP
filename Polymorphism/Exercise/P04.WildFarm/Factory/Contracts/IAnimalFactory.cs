namespace WildFarm.Factory.Contracts
{
    using Models.Animals;

    public interface IAnimalFactory
    {
        Animal CreateAnimal(string[] input);
    }
}
