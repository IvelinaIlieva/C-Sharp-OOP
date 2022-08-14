namespace PlanetWars.Models.MilitaryUnits
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private const int InitialEndurance = 1;
        private const int MaxEndurance = 20;

        private int enduranceLevel;

        protected MilitaryUnit(double cost)
        {
            Cost = cost;
            EnduranceLevel = InitialEndurance;
        }
        public double Cost { get; }

        public int EnduranceLevel
        {
            get => this.enduranceLevel;
            private set
            {
                if (value >= MaxEndurance)
                {
                    value = MaxEndurance;
                    throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
                }
                this.enduranceLevel = value;
            }
        }

        public void IncreaseEndurance() 
            => EnduranceLevel++;
    }
}
