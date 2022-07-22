namespace WildFarm.Factory
{
    using System;
    using Contracts;
    using Models.Foods;

    public class FoodFactory : IFoodFactory
    {
        public Food CreateFood(string[] input)
        {
            string type = input[0];
            int quantity = int.Parse(input[1]);

            Food food;

            switch (type)
            {
                case "Vegetable":
                    food = new Vegetable(quantity);
                    break;

                case "Fruit":
                    food = new Fruit(quantity);
                    break;

                case "Meat":
                    food = new Meat(quantity);
                    break;

                case "Seeds":
                    food = new Seeds(quantity);
                    break;
                default: throw new InvalidOperationException("Invalid Food!");
            }
            return food;
        }
    }
}
