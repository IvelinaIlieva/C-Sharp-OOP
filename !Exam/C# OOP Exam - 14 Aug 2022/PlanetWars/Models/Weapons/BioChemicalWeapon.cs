﻿namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon : Weapon
    {
        private const double InitialPrice = 3.2;
        public BioChemicalWeapon(int destructionLevel)
            : base(InitialPrice, destructionLevel)
        {
            //TODO: Check the destructionLevel
        }
    }
}
