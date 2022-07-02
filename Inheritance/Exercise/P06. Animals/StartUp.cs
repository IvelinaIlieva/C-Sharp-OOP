using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string type;

            while ((type = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    string[] animalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string name = animalInfo[0];
                    int age = int.Parse(animalInfo[1]);

                    switch (type)
                    {
                        case "Dog":
                            string genderDog = animalInfo[2];
                            Dog dog = new Dog(name, age, genderDog);
                            animals.Add(dog);
                            break;

                        case "Frog":
                            string genderFrog = animalInfo[2];
                            Frog frog = new Frog(name, age, genderFrog);
                            animals.Add(frog);
                            break;

                        case "Cat":
                            string genderCat = animalInfo[2];
                            Cat cat = new Cat(name, age, genderCat);
                            animals.Add(cat);
                            break;

                        case "Kitten":
                            Kitten kitten = new Kitten(name, age);
                            animals.Add(kitten);
                            break;

                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(name, age);
                            animals.Add(tomcat);
                            break;

                        default:
                            throw new ArgumentException();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
