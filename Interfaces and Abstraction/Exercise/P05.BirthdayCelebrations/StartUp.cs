namespace BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Models.Interfaces;
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs[0] == "Citizen")
                {
                    string name = cmdArgs[1];
                    int age = int.Parse(cmdArgs[2]);
                    string id = cmdArgs[3];
                    string birthDate = cmdArgs[4];

                    Citizen citizen = new Citizen(id, name, age, birthDate);
                    birthables.Add(citizen);
                }
                else if(cmdArgs[0] == "Pet")
                {
                    string name = cmdArgs[1];
                    string birthDate = cmdArgs[2];
                    Pet pet = new Pet(name, birthDate);
                    birthables.Add(pet);
                }
            }

            string year = Console.ReadLine();

            foreach (var birthable in birthables)
            {
                if (birthable.BirthDate.Substring(birthable.BirthDate.Length - year.Length, year.Length) == year)
                {
                    Console.WriteLine(birthable.BirthDate);
                }
            }
        }
    }
}