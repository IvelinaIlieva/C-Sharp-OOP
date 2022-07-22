namespace Raiding.Models
{
    using Contracts;

    public class Druid : BaseHero, IBaseHero
    {
        public override int Power => 80;
        public override string CastAbility() => $"{this.GetType().Name} - {this.Name} healed for {this.Power}";

        public Druid(string name)
            : base(name)
        {

        }
    }
}
