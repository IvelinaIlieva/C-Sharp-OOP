namespace CollectionHierarchy.Models
{
    using Contracts;
    using System.Collections.Generic;

    public class MyList : IMyList
    {
        private readonly List<string> collection;
        public MyList()
        {
            this.collection = new List<string>();
        }
        public int Used => collection.Count;
        public int Add(string item)
        {
            collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string itemToRemove = collection[0];
            collection.RemoveAt(0);
            return itemToRemove;
        }
    }
}
