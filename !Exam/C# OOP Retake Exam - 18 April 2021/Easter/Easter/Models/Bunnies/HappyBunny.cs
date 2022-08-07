namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int InitialEnergy = 100;
        private const int EnergyDecreaseValue = 10;

        public HappyBunny(string name) 
            : base(name, InitialEnergy)
        {
        }

        public override void Work()
        {
            Energy -= EnergyDecreaseValue;
        }
    }
}
