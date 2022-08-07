namespace CarRacing.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Cars.Contracts;
    using Utilities.Messages;

    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> cars;

        public CarRepository()
        {
            this.cars = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models 
            => this.cars.AsReadOnly();
        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }
            this.cars.Add(model);
        }

        public bool Remove(ICar model) 
            => this.cars.Remove(model);

        public ICar FindBy(string property) 
            => this.cars.FirstOrDefault(c => c.VIN == property);
    }
}
