namespace Raiding.Models
{
    using Contracts;

    public class Warrior : BaseHero, IBaseHero
    {
        public override int Power => 100;
        public override string CastAbility() => $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";

        public Warrior(string name)
            : base(name)
        {

        }
    }
}
