namespace WarCroft.Entities.Inventory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Constants;
    using Items;

    public abstract class Bag : IBag
    {
        private readonly List<Item> items;

        protected Bag(int capacity)
        {
            this.items = new List<Item>();
            Capacity = capacity;
        }
        public int Capacity { get; set; }
        public int Load
            => this.items.Sum(i => i.Weight);
        public IReadOnlyCollection<Item> Items
            => this.items.AsReadOnly();
        public void AddItem(Item item)
        {
            if (item.Weight + Load > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item item = this.items.FirstOrDefault(i => i.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.items.Remove(item);

            return item;
        }
    }
}
