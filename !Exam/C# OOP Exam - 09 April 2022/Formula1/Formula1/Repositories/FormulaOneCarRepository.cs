namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Contracts;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> cars;

        public FormulaOneCarRepository()
        {
            this.cars = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models
            => this.cars.AsReadOnly();

        public void Add(IFormulaOneCar model)
            => this.cars.Add(model);

        public bool Remove(IFormulaOneCar model)
            => this.cars.Remove(model);

        public IFormulaOneCar FindByName(string name) 
            => this.cars.FirstOrDefault(c => c.Model == name);
    }
}
