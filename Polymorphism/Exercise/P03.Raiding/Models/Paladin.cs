namespace Raiding.Models
{
    using Contracts;

    public class Paladin : BaseHero, IBaseHero
    {
        public override int Power => 100;
        public override string CastAbility() => $"{this.GetType().Name} - {this.Name} healed for {this.Power}";

        public Paladin(string name)
            : base(name)
        {

        }
    }
}
