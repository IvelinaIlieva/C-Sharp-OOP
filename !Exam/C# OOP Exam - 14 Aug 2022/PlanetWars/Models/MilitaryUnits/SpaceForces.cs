namespace PlanetWars.Models.MilitaryUnits
{
    public class SpaceForces : MilitaryUnit
    {
        private const double InitialCost = 11;
        public SpaceForces() 
            : base(InitialCost)
        {
        }
    }
}
