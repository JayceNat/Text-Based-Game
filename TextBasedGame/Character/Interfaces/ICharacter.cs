using System.Collections.Generic;
using TextBasedGame.Character.Models;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Character.Interfaces
{
    public interface ICharacter
    {
        Models.Character CreateCharacter(CharacterAttribute attributes, string name = null,
            List<InventoryItem> items = null, WeaponItem weapon = null, int baseHP = 100, int baseCarryingCapacity = 4);

        Models.Character UpdateCharacter(Models.Character character, string name = null, CharacterAttribute attributes = null,
            InventoryItem itemToAdd = null, InventoryItem itemToRemove = null, WeaponItem weapon = null, 
            int increaseMaximumHealth = 0, int addToHealth = 0, int increaseMaxCarryingCapacity = 0, int addToCarriedCount = 0);
    }
}