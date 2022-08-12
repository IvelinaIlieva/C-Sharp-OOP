namespace Bakery.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BakedFoods.Contracts;
    using Contracts;
    using Drinks.Contracts;
    using Utilities.Messages;

    public abstract class Table : ITable
    {
        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders;
        private int capacity;
        private int _numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            PricePerPerson = pricePerPerson;
            Capacity = capacity;
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }
        public int TableNumber { get; }
        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }
        public int NumberOfPeople
        {
            get => this._numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this._numberOfPeople = value;
            }
        }
        public decimal PricePerPerson { get; }
        public bool IsReserved { get; private set; }
        public decimal Price 
            => PricePerPerson * NumberOfPeople;
        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
            IsReserved = true;
        }

        public void OrderFood(IBakedFood food)
            => this.foodOrders.Add(food);

        public void OrderDrink(IDrink drink)
            => this.drinkOrders.Add(drink);

        public decimal GetBill() 
            => this.foodOrders.Sum(f => f.Price) + this.drinkOrders.Sum(d => d.Price) + Price;

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            IsReserved = false;
            this._numberOfPeople = 0;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Table: {TableNumber}")
                .AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Capacity: {Capacity}")
                .AppendLine($"Price per Person: {PricePerPerson:f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
