using TextBasedGame.Character.Models;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Character.Interfaces
{
    public interface ICharacterCreator
    {
        // Declare all getters for any Characters you will use here
        Models.Character Player { get; }
        Models.Character Ghoul { get; }

        // Will handle overwriting specific properties of a Character Object 
        Models.Character UpdateCharacter(Models.Character character, string name = null, CharacterAttribute attributes = null,
            InventoryItem itemToAdd = null, InventoryItem itemToRemove = null, WeaponItem weapon = null, 
            int increaseMaximumHealth = 0, int addToHealth = 0, int increaseMaxCarryingCapacity = 0, int addToCarriedCount = 0);
    }
}