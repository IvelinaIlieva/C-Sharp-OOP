namespace WarCroft.Entities.Items
{
    using Characters;

    public class FirePotion : Item
    {
        private const int InitialWeight = 5;
        private const int HealthDecreaseValue = 20;

        public FirePotion()
            : base(InitialWeight)
        {

        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= HealthDecreaseValue;

            if (character.Health <= 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
