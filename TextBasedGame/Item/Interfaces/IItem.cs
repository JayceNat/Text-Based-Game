using System.Collections.Generic;
using TextBasedGame.Item.Models;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Item.Interfaces
{
    public interface IItem
    {
        Models.Items CreateItemsModel(List<InventoryItem> inventoryItems, List<WeaponItem> weaponItems);

        InventoryItem CreateInventoryItem(string name, string description, string placementDescription, string genericPlacementDescription,
            List<string> keywordsForPickup, List<ItemTrait> traits, bool inOriginalLocation = true,
            bool itemHasAttrRequirementToView = false, AttributeRequirement viewItemAttrRequirement = null);

        InventoryItem UpdateInventoryItem(InventoryItem item, string name = null, string description = null, string placementDescription = null,
            string genericPlacementDescription = null, List<string> keywordsForPickup = null, ItemTrait traitToAdd = null, bool inOriginalLocation = false,
            bool itemHasAttrRequirementToView = false, AttributeRequirement viewItemAttrRequirement = null);

        WeaponItem CreateWeaponItem(string name, string description, string placementDescription, string genericPlacementDescription,
            int attackPower, List<string> keywordsForPickup, List<ItemTrait> traits, bool inOriginalLocation = true,
            bool weaponHasAttrRequirementToView = false, AttributeRequirement viewWeaponAttrRequirement = null);

        WeaponItem UpdateWeaponItem(WeaponItem weapon, string name = null, string description = null, string placementDescription = null,
            string genericPlacementDescription = null, int addToAttackPower = 0, List<string> keywordsForPickup = null, ItemTrait traitToAdd = null, 
            bool inOriginalLocation = false, bool weaponHasAttrRequirementToView = false, AttributeRequirement viewWeaponAttrRequirement = null);
    }
}