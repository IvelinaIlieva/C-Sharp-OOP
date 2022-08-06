namespace Heroes.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Contracts;

    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models => this.heroes.AsReadOnly();
        public void Add(IHero model) => this.heroes.Add(model);

        public bool Remove(IHero model) => this.heroes.Remove(model);
        
        public IHero FindByName(string name) => this.heroes.FirstOrDefault(h => h.Name == name);
    }
}
