﻿namespace Easter.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Eggs.Contracts;

    public class EggRepository : IRepository<IEgg>
    {
        private readonly List<IEgg> eggs;

        public EggRepository()
        {
            this.eggs = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models 
            => this.eggs.AsReadOnly();
        public void Add(IEgg model) 
            => this.eggs.Add(model);

        public bool Remove(IEgg model) 
            => this.eggs.Remove(model);

        public IEgg FindByName(string name) 
            => this.eggs.FirstOrDefault(e => e.Name == name);
    }
}
