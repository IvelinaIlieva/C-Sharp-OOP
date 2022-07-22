namespace Raiding.Models
{
    using Contracts;

    public abstract class BaseHero : IBaseHero
    {
        public string Name { get; }
        public virtual int Power => 0;

        protected BaseHero(string name)
        {
            Name = name;
        }
        public abstract string CastAbility();
    }
}
