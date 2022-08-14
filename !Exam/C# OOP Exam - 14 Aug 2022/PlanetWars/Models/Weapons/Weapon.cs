namespace PlanetWars.Models.Weapons
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public abstract class Weapon : IWeapon
    {
        private const int MinDestructionLevel = 1;
        private const int MaxDestructionLevel = 10;

        private int destructionLevel;

        protected Weapon(double price, int destructionLevel)
        {
            Price = price;
            DestructionLevel = destructionLevel;
        }
        public double Price { get; }

        public virtual int DestructionLevel
        {
            get => this.destructionLevel;
            private set
            {
                if (value < MinDestructionLevel)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }
                else if (value > MaxDestructionLevel)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }
                else
                {
                    this.destructionLevel = value;
                }
            }
        }
    }
}
