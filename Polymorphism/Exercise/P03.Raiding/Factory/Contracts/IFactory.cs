namespace Raiding.Factory.Contracts
{
    using Raiding.Models.Contracts;
    public interface IFactory
    {
        IBaseHero CreateHero(string name, string type);
    }
}
