namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;
    using Contracts;
    using System.Linq;
    public class AddRemoveCollection : IAddRemovable
    {
        private readonly List<string> collection;

        public AddRemoveCollection()
        {
            this.collection = new List<string>();
        }
        public int Add(string item)
        {
            collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string itemToRemove = collection.Last();
            collection.RemoveAt(collection.Count - 1);
            return itemToRemove;
        }
    }
}
