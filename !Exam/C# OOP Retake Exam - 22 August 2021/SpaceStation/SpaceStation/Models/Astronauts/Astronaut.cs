namespace SpaceStation.Models.Astronauts
{
    using System;
    using System.Text;
    using Bags;
    using Bags.Contracts;
    using Contracts;
    using Utilities.Messages;

    public abstract class Astronaut : IAstronaut
    {
        private const double OxygenDecreasement = 10;

        private string name;
        private double oxygen;

        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
           this.Bag = new Backpack();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                this.oxygen = value;
            }
        }

        public bool CanBreath 
            => Oxygen > 0;
        public IBag Bag { get; }

        public virtual void Breath()
        {
            Oxygen -= OxygenDecreasement;
            if (Oxygen < 0)
            {
                Oxygen = 0;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Name: {Name}")
                .AppendLine($"Oxygen: {Oxygen}")
                .AppendLine($"Bag items: {(Bag.Items.Count == 0 ? "none" : string.Join(", ", Bag.Items))}");
            return sb.ToString().TrimEnd();
        }
    }
}
