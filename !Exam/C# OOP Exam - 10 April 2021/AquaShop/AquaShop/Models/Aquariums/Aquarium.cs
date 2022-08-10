namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Decorations.Contracts;
    using Fish.Contracts;
    using Utilities.Messages;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decorations;
        private List<IFish> fishes;

        protected Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fishes = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort
            => this.Decorations.Sum(d => d.Comfort);


        public ICollection<IDecoration> Decorations
            => this.decorations;

        public ICollection<IFish> Fish
            => this.fishes;

        public void AddFish(IFish fish)
        {
            if (Capacity <= Fish.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            Fish.Add(fish);
        }

        public bool RemoveFish(IFish fish)
            => Fish.Remove(fish);

        public void AddDecoration(IDecoration decoration)
            => Decorations.Add(decoration);

        public void Feed()
            => this.fishes.ForEach(f => f.Eat());

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            ;
            sb
                .AppendLine($"{Name} ({this.GetType().Name}):")
                .AppendLine(
                    $"Fish: {(Fish.Count == 0 ? "none" : string.Join(", ", this.fishes.Select(f => f.Name).ToArray()))}")
                .AppendLine($"Decorations: {Decorations.Count}")
                .AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}
