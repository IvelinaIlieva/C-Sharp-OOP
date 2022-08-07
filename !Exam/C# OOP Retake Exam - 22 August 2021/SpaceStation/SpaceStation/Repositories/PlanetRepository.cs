namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Planets.Contracts;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models
            => this.planets.AsReadOnly();
        public void Add(IPlanet model)
            => this.planets.Add(model);

        public bool Remove(IPlanet model)
            => this.planets.Remove(model);

        public IPlanet FindByName(string name) 
            => this.planets.FirstOrDefault(p => p.Name == name);
    }
}
