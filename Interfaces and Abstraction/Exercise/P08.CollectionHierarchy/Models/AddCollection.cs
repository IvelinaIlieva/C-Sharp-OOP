namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;
    using Contracts;
    public class AddCollection : IAddable
    {
        private readonly List<string> collection;

        public AddCollection()
        {
            this.collection = new List<string>();
        }

        public int Add(string item)
        {
            collection.Add(item);
            return collection.Count - 1;
        }
    }
}
