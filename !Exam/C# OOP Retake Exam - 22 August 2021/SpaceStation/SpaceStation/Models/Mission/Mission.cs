namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;
    using System.Linq;
    using Astronauts.Contracts;
    using Contracts;
    using Planets.Contracts;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (IAstronaut astronaut in astronauts)
            {
                while (planet.Items.Count > 0)
                {
                    string item = planet.Items.ElementAt(0);
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);

                    if (!astronaut.CanBreath)
                    {
                        break;
                    }
                }

                if (planet.Items.Count == 0)
                {
                    break;
                }
            }
        }
    }
}