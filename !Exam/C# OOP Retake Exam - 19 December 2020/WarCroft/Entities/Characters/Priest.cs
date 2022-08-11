namespace WarCroft.Entities.Characters
{
    using System;
    using Constants;
    using Contracts;
    using Inventory;

    public class Priest : Character, IHealer
    {
        private const double InitialBaseHealth = 50;
        private const double InitialBaseArmor = 25;
        private const double InitialAbilityPoints = 40;

        public Priest(string name) 
            : base(name, InitialBaseHealth, InitialBaseArmor, InitialAbilityPoints, new Backpack())
        {
        }

        public void Heal(Character character)
        {
           this.EnsureAlive();

           if (!character.IsAlive)
           {
               throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
           }
           
           character.Health += this.AbilityPoints;
        }
    }
}
