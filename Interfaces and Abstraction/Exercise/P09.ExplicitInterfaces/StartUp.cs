namespace ExplicitInterfaces
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Contracts;
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> list = new List<Citizen>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] citizenInfo = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = citizenInfo[0];
                string country = citizenInfo[1];
                int age = int.Parse(citizenInfo[2]);

                Citizen citizen = new Citizen(name, country, age);
                list.Add(citizen);
            }

            foreach (var citizen in list)
            {
                Console.WriteLine(citizen.Name);
                IPerson person = citizen;
                IResident resident = citizen;
                Console.WriteLine($"{resident.GetName()}{person.GetName()}");
            }
        }
    }
}
