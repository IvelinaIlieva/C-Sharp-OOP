namespace EasterRaces.Repositories.Entities
{
    using System.Linq;
    using Models.Races.Contracts;

    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name) 
            => this.GetAll().FirstOrDefault(r => r.Name == name);
    }
}
