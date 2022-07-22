namespace WildFarm.Factory
{
    using System;
    using Contracts;
    using Models.Animals;

    public class AnimalFactory : IAnimalFactory
    {
        public Animal CreateAnimal(string[] input)
        {
            string type = input[0];
            string name = input[1];
            double weight = double.Parse(input[2]);

            Animal animal;

            switch (type)
            {
                case "Owl":
                    double wingSizeOwl = double.Parse(input[3]);
                    animal = new Owl(wingSizeOwl, name, weight);
                    break;

                case "Hen":
                    double wingSizeHen = double.Parse(input[3]);
                    animal = new Hen(wingSizeHen, name, weight);
                    break;

                case "Mouse":
                    string livingRegionMouse = input[3];
                    animal = new Mouse(livingRegionMouse, name, weight);
                    break;

                case "Dog":
                    string livingRegionDog = input[3];
                    animal =new Dog(livingRegionDog, name, weight);
                    break;

                case "Cat":
                    string livingRegionCat = input[3];
                    string breedCat = input[4];
                    animal = new Cat(breedCat, livingRegionCat, name, weight);
                    break;

                case "Tiger":
                    string livingRegionTiger = input[3];
                    string breedTiger = input[4];
                    animal = new Tiger(breedTiger, livingRegionTiger, name, weight);
                    break;
                default: throw new InvalidOperationException("Invalid Animal!");
            }

            return animal;
        }
    }
}
