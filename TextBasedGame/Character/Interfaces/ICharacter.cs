using System.Collections.Generic;
using TextBasedGame.Character.Models;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Character.Interfaces
{
    public interface ICharacter
    {
        CharacterModel CreateCharacter(CharacterAttributeModel attributes, string name = null,
            List<InventoryItemModel> items = null, WeaponItemModel weapon = null, int baseHP = 100, int baseCarryingCapacity = 4);

        CharacterModel UpdateCharacter(CharacterModel character, string name = null, CharacterAttributeModel attributes = null,
            InventoryItemModel itemToAdd = null, InventoryItemModel itemToRemove = null, WeaponItemModel weapon = null, 
            int increaseMaximumHealth = 0, int addToHealth = 0, int increaseMaxCarryingCapacity = 0, int addToCarriedCount = 0);
    }
}