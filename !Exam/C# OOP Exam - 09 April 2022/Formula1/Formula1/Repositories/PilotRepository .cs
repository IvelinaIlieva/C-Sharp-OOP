namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Contracts;

    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> pilots;

        public PilotRepository()
        {
            this.pilots = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models
            => this.pilots.AsReadOnly();

        public void Add(IPilot model)
            => this.pilots.Add(model);

        public bool Remove(IPilot model)
            => this.pilots.Remove(model);

        public IPilot FindByName(string name)
            => this.pilots.FirstOrDefault(p=>p.FullName == name);
    }
}
