namespace AquaShop.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Aquariums;
    using Models.Aquariums.Contracts;
    using Models.Decorations;
    using Models.Decorations.Contracts;
    using Models.Fish;
    using Models.Fish.Contracts;
    using Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = aquariumType switch
            {
                nameof(FreshwaterAquarium) => new FreshwaterAquarium(aquariumName),
                nameof(SaltwaterAquarium) => new SaltwaterAquarium(aquariumName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType)
            };

            this.aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = decorationType switch
            {
                nameof(Ornament) => new Ornament(),
                nameof(Plant) => new Plant(),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType)
            };

            this.decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = this.decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);
            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = fishType switch
            {
                nameof(FreshwaterFish) => new FreshwaterFish(fishName, fishSpecies, price),
                nameof(SaltwaterFish) => new SaltwaterFish(fishName, fishSpecies, price),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidFishType)
            };

            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);

            if (fish.GetType().Name == nameof(FreshwaterFish) && aquarium.GetType().Name == nameof(SaltwaterAquarium)
                || fish.GetType().Name == nameof(SaltwaterFish) && aquarium.GetType().Name == nameof(FreshwaterAquarium)
                 )
            {
                return OutputMessages.UnsuitableWater;
            }

            aquarium.AddFish(fish);
            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);

            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);

            decimal totalPrice = aquarium.Fish.Sum(f => f.Price) + aquarium.Decorations.Sum(d => d.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, totalPrice);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (IAquarium aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
