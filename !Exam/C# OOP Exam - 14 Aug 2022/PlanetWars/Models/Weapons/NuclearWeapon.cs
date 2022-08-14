namespace PlanetWars.Models.Weapons
{
    public class NuclearWeapon : Weapon
    {
        private const double InitialPrice = 15;
        public NuclearWeapon(int destructionLevel) 
            : base(InitialPrice, destructionLevel)
        {
        }
    }
}
