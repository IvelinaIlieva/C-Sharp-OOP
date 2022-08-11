namespace WarCroft.Entities.Characters
{
    using System;
    using Constants;
    using Inventory;
    using Items;

    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double baseHealth, double baseArmor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = baseHealth;
            Health = BaseHealth;
            BaseArmor = baseArmor;
            Armor = BaseArmor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                this.name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health
        {
            get => this.health;
            protected internal set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > BaseHealth)
                {
                    value = BaseHealth;
                }
                this.health = value;
            }
        }

        public double BaseArmor { get; }

        public double Armor
        {
            get => this.armor;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.armor = value;
            }
        }

        public double AbilityPoints { get; }
        public Bag Bag { get; }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            double damage = hitPoints - Armor;
            Armor -= hitPoints;

            if (damage > 0)
            {
                Health -= damage;

                if (Health <= 0)
                {
                    IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();

            item.AffectCharacter(this);
        }

        public override string ToString()
            => string.Format(SuccessMessages.CharacterStats, Name, Health, BaseHealth, Armor, BaseArmor, (this.IsAlive ? "Alive" : "Dead"));
    }
}