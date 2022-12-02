using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> characters;
        private Stack<Item> items;
        public WarController()
        {
            characters = new List<Character>();
            items = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Character character;
            if (characterType == "Priest") character = new Priest(name);

            else if (characterType == "Warrior") character = new Warrior(name);

            else throw new ArgumentException(String.Format(ExceptionMessages.InvalidCharacterType, characterType));

            characters.Add(character);

            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item;

            if (itemName == "FirePotion") item = new FirePotion();
            else if (itemName == "HealthPotion") item = new HealthPotion();
            else throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));

            items.Push(item);

            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = characters.Find(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (!items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item item = items.Pop();
            character.Bag.AddItem(item);

            string itemType = item.GetType().Name;
            return string.Format(SuccessMessages.PickUpItem, characterName, itemType);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = characters.Find(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            character.UseItem(character.Bag.GetItem(itemName));

            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            Func<Character, string> printChar = (Character x) =>
            {
                string status = x.IsAlive ? "Alive" : "Dead";
                return $"{x.Name} - HP: {x.Health}/{x.BaseHealth}, AP: {x.Armor}/{x.BaseArmor}, Status: {status}";
            };
            return
                string.Join(Environment.NewLine, characters.OrderByDescending(x => x.Health).Select(printChar));
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attackCharacter = characters.Find(x => x.Name == attackerName);
            Character defendingCharacter = characters.Find(x => x.Name == receiverName);

            if (attackCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            if (defendingCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (attackCharacter.GetType() != typeof(Warrior))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AttackFail, attackerName));
            }

            (attackCharacter as Warrior).Attack(defendingCharacter);

            string output = string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName,
                attackCharacter.AbilityPoints, receiverName, defendingCharacter.Health, defendingCharacter.BaseHealth,
                defendingCharacter.Armor, defendingCharacter.BaseArmor);

            if (!defendingCharacter.IsAlive)
            {
                output += Environment.NewLine + string.Format(SuccessMessages.AttackKillsCharacter, receiverName);
            }

            return output;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healerCharacter = characters.Find(x => x.Name == healerName);
            Character receiverHealingCharacter = characters.Find(x => x.Name == healingReceiverName);

            if (healerCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            if (receiverHealingCharacter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            if (healerCharacter.GetType()!=typeof(Priest))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            (healerCharacter as Priest).Heal(receiverHealingCharacter);

            return string.Format(SuccessMessages.HealCharacter, healerName, receiverHealingCharacter.Name,
                healerCharacter.AbilityPoints, receiverHealingCharacter.Name, receiverHealingCharacter.Health);
        }
    }
}