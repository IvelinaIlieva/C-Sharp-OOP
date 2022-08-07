namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Dyes.Contracts;
    using Utilities.Messages;

    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private readonly List<IDye> dyes;

        protected Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            this.dyes = new List<IDye>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                this.name = value;
            }
        }
        public int Energy
        {
            get => this.energy;
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.energy = value;
            }
        }
        public ICollection<IDye> Dyes
            => this.dyes;
        public abstract void Work();

        public void AddDye(IDye dye)
            => Dyes.Add(dye);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb
                .AppendLine($"Name: {Name}")
                .AppendLine($"Energy: {Energy}")
                .AppendLine($"Dyes: {Dyes.Count(d => !d.IsFinished())} not finished");

            return sb.ToString().TrimEnd();
        }
    }
}
