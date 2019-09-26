using System.Collections.Generic;
using TextBasedGame.Item.Models;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Item.Interfaces
{
    public interface IItemCreator
    {
        // Declare all getters for any Items you will use here
        InventoryItem Flashlight { get; }
        InventoryItem RunningShoes { get; }
        InventoryItem Backpack { get; }

        // Declare all getters for any Weapons you will use here
        WeaponItem BaseballBat { get; }
        WeaponItem GhoulClaws { get; }

        // Will handle overwriting specific properties of an InventoryItem Object 
        InventoryItem UpdateInventoryItem(InventoryItem item, string name = null, string description = null, string placementDescription = null,
            string genericPlacementDescription = null, List<string> keywordsForPickup = null, ItemTrait traitToAdd = null,
            bool inOriginalLocation = false, AttributeRequirement attrRequirementToView = null);

        // Will handle overwriting specific properties of a WeaponItem Object 
        WeaponItem UpdateWeaponItem(WeaponItem weapon, string name = null, string description = null, string placementDescription = null,
            string genericPlacementDescription = null, int addToAttackPower = 0, List<string> keywordsForPickup = null, ItemTrait traitToAdd = null, 
            bool inOriginalLocation = false, AttributeRequirement attrRequirementToView = null);
    }
}