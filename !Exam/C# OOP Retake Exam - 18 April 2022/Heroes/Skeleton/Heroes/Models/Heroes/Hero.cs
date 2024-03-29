﻿namespace Heroes.Models.Heroes
{
    using System;
    using System.Text;
    using Contracts;

    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Health
        {
            get => this.health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                this.health = value;
            }
        }

        public int Armour
        {
            get => this.armour;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                this.armour = value;
            }
        }
        public IWeapon Weapon
        {
            get => this.weapon;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
                this.weapon = value;
            }
        }

        public bool IsAlive => this.health > 0;

        public void TakeDamage(int points)
        {
            if (Armour - points >= 0)
            {
                Armour -= points;
            }
            else
            {
                int healthDamage = points - Armour;
                Armour = 0;

                if (Health - healthDamage <= 0)
                {
                    Health = 0;
                }
                else
                {
                    Health -= healthDamage;
                }
            }
        }

        public void AddWeapon(IWeapon weapon) => Weapon = weapon;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"{this.GetType().Name}: {Name}")
                .AppendLine($"--Health: {Health}")
                .AppendLine($"--Armour: {Armour}")
                .AppendLine($"--Weapon: {(Weapon == null ? "Unarmed" : Weapon.Name)}");

            return sb.ToString().TrimEnd();
        }
    }
}
