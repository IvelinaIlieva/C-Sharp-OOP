namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int InitialEnergy = 50;
        private const int EnergyDecreaseValue = 15;

        public SleepyBunny(string name) 
            : base(name, InitialEnergy)
        {
        }

        public override void Work()
        {
            Energy -= EnergyDecreaseValue;
        }
    }
}
