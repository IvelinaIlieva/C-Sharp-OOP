namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models
            => this.races.AsReadOnly();
        public void Add(IRace model) 
            => this.races.Add(model);

        public bool Remove(IRace model) 
            => this.races.Remove(model);

        public IRace FindByName(string name) 
            => this.races.FirstOrDefault(r => r.RaceName == name);
    }
}
