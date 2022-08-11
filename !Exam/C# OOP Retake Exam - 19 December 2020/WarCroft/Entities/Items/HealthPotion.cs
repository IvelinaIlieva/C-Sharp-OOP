namespace WarCroft.Entities.Items
{
    using Characters;

    public class HealthPotion : Item
    {
        private const int InitialWeight = 5;
        private const int HealthIncreaseValue = 20;

        public HealthPotion()
            : base(InitialWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += HealthIncreaseValue;
        }
    }
}
