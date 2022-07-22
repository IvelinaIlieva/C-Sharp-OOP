namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Factory;
    using Factory.Contracts;
    using IO;
    using IO.Contracts;
    using Models.Animals;
    using Models.Foods;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine()
        {
            reader = new Reader();
            writer = new Writer();
        }

        public void Start()
        {
            IFoodFactory foodFactory = new FoodFactory();
            IAnimalFactory animalFactory = new AnimalFactory();

            List<Animal> animals = new List<Animal>();

            string cmd;
            while ((cmd = reader.ReadLine()) != "End")
            {
                string[] animalInfo = cmd.Split(' ');
                string[] foodInfo = reader.ReadLine().Split(' ');

                try
                {
                    Food food = foodFactory.CreateFood(foodInfo);
                    Animal animal = animalFactory.CreateAnimal(animalInfo);

                    writer.WriteLine(animal.AskForFood());
                    animals.Add(animal);

                    animal.Feed(food);
                    
                }
                catch (InvalidOperationException ioe)
                {
                    writer.WriteLine(ioe.Message);
                }
            }

            foreach (var animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }
        }
    }
}
