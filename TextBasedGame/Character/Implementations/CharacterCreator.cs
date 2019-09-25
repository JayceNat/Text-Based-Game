using TextBasedGame.Character.Interfaces;
using TextBasedGame.Character.Models;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Character.Implementations
{
    public class CharacterCreator : ICharacterCreator
    {
        public Models.Character Player { get; }
        public Models.Character Ghoul { get; }

        public CharacterCreator()
        {
            Player = Characters.Player;
            Ghoul = Characters.Ghoul;
        }

        public Models.Character UpdateCharacter(Models.Character character, string name = null, CharacterAttribute attributes = null,
            InventoryItem itemToAdd = null, InventoryItem itemToRemove = null, WeaponItem weapon = null, 
            int increaseMaxHealth = 0, int addToHealth = 0, int increaseMaxCarryingCapacity = 0, int addToCarriedCount = 0)
        {
            if (name != null)
            {
                character.Name = name;
            }

            if (increaseMaxHealth != 0)
            {
                character.MaximumHealthPoints += increaseMaxHealth;
                character.HealthPoints += increaseMaxHealth;
            }

            if (addToHealth != 0)
            {
                character.HealthPoints += addToHealth;
            }

            if (attributes != null)
            {
                character.Attributes = attributes;
            }

            if (itemToAdd != null)
            {
                character.CarriedItems.Add(itemToAdd);
            }

            if (itemToRemove != null)
            {
                character.CarriedItems.Remove(itemToRemove);
            }

            if (increaseMaxCarryingCapacity != 0)
            {
                character.MaximumCarryingCapacity += increaseMaxCarryingCapacity;
            }

            if (addToCarriedCount != 0)
            {
                character.CarriedItemsCount += addToCarriedCount;
            }

            if (weapon != null)
            {
                character.WeaponItem = weapon;
            }
            
            return character;
        }
    }
}