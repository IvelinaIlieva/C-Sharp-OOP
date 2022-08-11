namespace WarCroft.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Constants;
    using Entities.Characters;
    using Entities.Items;
    using IO;

    public class WarController
    {
        private readonly List<Character> characters;
        private readonly List<Item> items;
        public WarController()
        {
            this.characters = new List<Character>();
            this.items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string type = args[0];
            string name = args[1];

            Character character = type switch
            {
                nameof(Warrior) => new Warrior(name),
                nameof(Priest) => new Priest(name),
                _ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, type))
            };

            this.characters.Add(character);
            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string name = args[0];

            Item item = name switch
            {
                nameof(FirePotion) => new FirePotion(),
                nameof(HealthPotion) => new HealthPotion(),
                _ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, name))
            };

            this.items.Add(item);
            return string.Format(SuccessMessages.AddItemToPool, name);
        }

        public string PickUpItem(string[] args)
        {
            string name = args[0];

            Character character = this.characters.FirstOrDefault(c => c.Name == name);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, name));
            }

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item item = this.items.Last();
            this.items.RemoveAt(this.items.Count - 1);

            character.Bag.AddItem(item);

            return string.Format(SuccessMessages.PickUpItem, name, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = this.characters.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }


            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            StringBuilderWriter writer = new StringBuilderWriter();

            foreach (Character character in characters.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                writer.WriteLine(character.ToString());
            }

            return writer.sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = this.characters.FirstOrDefault(c => c.Name == attackerName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            Character defender = this.characters.FirstOrDefault(c => c.Name == receiverName);

            if (defender == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (attacker.GetType().Name != nameof(Warrior))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            Warrior warrior = attacker as Warrior;
            warrior!.Attack(defender);

            if (defender.IsAlive)
            {
                return string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName, attacker.AbilityPoints,
                    receiverName, defender.Health, defender.BaseHealth, defender.Armor, defender.BaseArmor);
            }

            StringBuilderWriter writer = new StringBuilderWriter();
            writer.WriteLine(string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName, attacker.AbilityPoints,
                receiverName, defender.Health, defender.BaseHealth, defender.Armor, defender.BaseArmor));
            writer.WriteLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverName));

            return writer.sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = this.characters.FirstOrDefault(c => c.Name == healerName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

            Character healingReceiver = this.characters.FirstOrDefault(c => c.Name == healingReceiverName);

            if (healingReceiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            if (healer.GetType().Name != nameof(Priest))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            Priest priest = healer as Priest;

            priest!.Heal(healingReceiver);

            return string.Format(SuccessMessages.HealCharacter, healerName, healingReceiverName, priest.AbilityPoints,
                healingReceiverName, healingReceiver.Health);
        }
    }
}
