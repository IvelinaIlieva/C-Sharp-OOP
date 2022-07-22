namespace Raiding.Models
{
    using Contracts;

    public class Rogue : BaseHero, IBaseHero
    {
        public override int Power => 80;
        public override string CastAbility() => $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";

        public Rogue(string name) 
            : base(name)
        {

        }
    }
}
