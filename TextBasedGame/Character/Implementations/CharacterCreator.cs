using TextBasedGame.Character.Interfaces;
using TextBasedGame.Character.Models;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Character.Implementations
{
    public class CharacterCreator : ICharacterCreator
    {
        // Declare all getters for any Characters you will use here
        public Models.Character Player { get; }
        public Models.Character Ghoul { get; }

        // Constructor: Add the reference to all the Attribute Objects here
        public CharacterCreator()
        {
            Player = GameCharacters.Player;
            Ghoul = GameCharacters.Ghoul;
        }

        // Handles overwriting specific properties of a Character Object 
        public Models.Character UpdateCharacter(Models.Character character, string name = null, CharacterAttribute attributes = null,
            InventoryItem itemToAdd = null, InventoryItem itemToRemove = null, WeaponItem weapon = null, 
            int increaseMaxHealth = 0, int addToHealth = 0)
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

            if (weapon != null)
            {
                character.WeaponItem = weapon;
            }
            
            return character;
        }
    }
}