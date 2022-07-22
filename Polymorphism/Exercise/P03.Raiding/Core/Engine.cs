namespace Raiding.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Raiding.Factory.Contracts;
    using IO;
    using Raiding.IO.Contracts;
    using Raiding.Models.Contracts;

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
            int count = int.Parse(reader.ReadLine());

            List<IBaseHero> heroes = new List<IBaseHero>();

            IFactory factory = new Factory.Factory();

            int counter = 0;

            while (counter < count)
            {
                string name = reader.ReadLine();
                string type = reader.ReadLine();

                try
                {
                    IBaseHero hero = factory.CreateHero(name, type);

                    if (hero != null)
                    {
                        heroes.Add(hero);
                        counter++;
                    }
                }
                catch (Exception ae)
                {
                    writer.WriteLine(ae.Message);
                }
            }

            int bossPower = int.Parse(reader.ReadLine());

            int heroesPower = heroes.Sum(h => h.Power);

            heroes.ForEach(h => writer.WriteLine(h.CastAbility()));

            writer.WriteLine(heroesPower >= bossPower
                ? "Victory!"
                : "Defeat...");
        }
    }
}
