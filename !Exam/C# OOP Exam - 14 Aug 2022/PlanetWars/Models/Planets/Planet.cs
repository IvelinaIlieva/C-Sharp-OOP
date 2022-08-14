namespace PlanetWars.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using MilitaryUnits;
    using MilitaryUnits.Contracts;
    using Repositories.Contracts;
    using Utilities.Messages;
    using Weapons;
    using Weapons.Contracts;

    public class Planet : IPlanet
    {
        private const double AnonymousImpactUnitCoefficientOfIncrease = 1.3;
        private const double NuclearWeaponCoefficientOfIncrease = 1.45;

        private string name;
        private double budget;
        private readonly UnitRepository army;
        private readonly WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            this.army = new UnitRepository();
            this.weapons = new WeaponRepository();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }
        public double Budget
        {
            get => this.budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                this.budget = value;
            }
        }

        public double MilitaryPower
            => CalculateMilitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army
            => this.army.Models;

        public IReadOnlyCollection<IWeapon> Weapons
            => this.weapons.Models;

        //TODO: Check If you should to check id unit already exist
        public void AddUnit(IMilitaryUnit unit)
            => this.army.AddItem(unit);

        public void AddWeapon(IWeapon weapon)
            => this.weapons.AddItem(weapon);

        public void TrainArmy()
            => this.army.Models.ToList().ForEach(a => a.IncreaseEndurance());

        public void Spend(double amount)
        {
            if (Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            Budget -= amount;
        }

        public void Profit(double amount)
            => Budget += amount;

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Planet: {Name}")
                .AppendLine($"--Budget: {Budget} billion QUID")
                .AppendLine(
                    $"--Forces: {(Army.Count == 0 ? "No units" : string.Join(", ", Army.Select(a => a.GetType().Name)))}")
                .AppendLine(
                    $"--Combat equipment: {(Weapons.Count == 0 ? "No weapons" : string.Join(", ", Weapons.Select(w => w.GetType().Name)))}")
                .AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        private double CalculateMilitaryPower()
        {
            double totalAmount = (Army.Sum(a => a.EnduranceLevel) + Weapons.Sum(w => w.DestructionLevel));

            if (Army.Any(a => a.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                totalAmount *= AnonymousImpactUnitCoefficientOfIncrease;
            }

            if (Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
            {
                totalAmount *= NuclearWeaponCoefficientOfIncrease;
            }

            return Math.Round(totalAmount, 3);
        }
    }
}
