namespace Heroes.Models.Map
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Heroes;

    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<Knight> knightList = new List<Knight>();
            List<Barbarian> barbarianList = new List<Barbarian>();

            foreach (IHero hero in players)
            {
                if (hero.GetType().Name == nameof(Knight))
                {
                    knightList.Add((Knight)hero);
                }
                else
                {
                    barbarianList.Add((Barbarian)hero);
                }
            }

            while (knightList.Count(k => k.IsAlive) > 0 && barbarianList.Count(b => b.IsAlive) > 0)
            {
                foreach (var knight in knightList.Where(k => k.IsAlive && k.Weapon.Durability>0))
                {
                    foreach (var barbarian in barbarianList.Where(b => b.IsAlive))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                }

                foreach (var barbarian in barbarianList.Where(b => b.IsAlive && b.Weapon.Durability > 0))
                {
                    foreach (var knight in knightList.Where(k => k.IsAlive))
                    {
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                    }
                }
            }

            return knightList.Count(k => k.IsAlive) == 0 
                ? $"The barbarians took {barbarianList.Count(b => !b.IsAlive)} casualties but won the battle." 
                : $"The knights took {knightList.Count(k => !k.IsAlive)} casualties but won the battle.";
        }
    }
}
