﻿namespace AquaShop.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Decorations.Contracts;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> decorations;

        public DecorationRepository()
        {
            this.decorations = new List<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models 
            => this.decorations.AsReadOnly();
        public void Add(IDecoration model) 
            => this.decorations.Add(model);

        public bool Remove(IDecoration model) 
            => this.decorations.Remove(model);

        public IDecoration FindByType(string type) 
            => this.decorations.FirstOrDefault(d => d.GetType().Name == type);
    }
}
