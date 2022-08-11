namespace WarCroft.Entities.Characters
{
    using System;
    using Constants;
    using Contracts;
    using Inventory;

    public class Warrior : Character, IAttacker
    {
        private const double InitialBaseHealth = 100;
        private const double InitialBaseArmor = 50;
        private const double InitialAbilityPoints = 40;
        
        public Warrior(string name) 
            : base(name, InitialBaseHealth, InitialBaseArmor, InitialAbilityPoints, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();

            if (this.Name == character.Name)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
