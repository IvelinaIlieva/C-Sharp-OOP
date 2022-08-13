namespace EasterRaces.Repositories.Entities
{
    using System.Collections.Generic;
    using Contracts;

    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly List<T> models;

        protected Repository()
        {
            this.models = new List<T>();
        }

        public abstract T GetByName(string name);

        public IReadOnlyCollection<T> GetAll() 
            => this.models.AsReadOnly();

        public void Add(T model)
            => this.models.Add(model);

        public bool Remove(T model) 
            => this.models.Remove(model);
    }
}

