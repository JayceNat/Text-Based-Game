using System.Collections.Generic;
using TextBasedGame.Item.Models;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Item.Interfaces
{
    public interface IItem
    {
        ItemsModel CreateItemsModel(List<InventoryItemModel> inventoryItems, List<WeaponItemModel> weaponItems);

        InventoryItemModel CreateInventoryItem(string name, string description, string placementDescription, string genericPlacementDescription,
            List<string> keywordsForPickup, List<ItemTraitModel> traits, bool inOriginalLocation = true,
            bool itemHasAttrRequirementToView = false, AttributeRequirementModel viewItemAttrRequirement = null);

        InventoryItemModel UpdateInventoryItem(InventoryItemModel item, string name = null, string description = null, string placementDescription = null,
            string genericPlacementDescription = null, List<string> keywordsForPickup = null, ItemTraitModel traitToAdd = null, bool inOriginalLocation = false,
            bool itemHasAttrRequirementToView = false, AttributeRequirementModel viewItemAttrRequirement = null);

        WeaponItemModel CreateWeaponItem(string name, string description, string placementDescription, string genericPlacementDescription,
            int attackPower, List<string> keywordsForPickup, List<ItemTraitModel> traits, bool inOriginalLocation = true,
            bool weaponHasAttrRequirementToView = false, AttributeRequirementModel viewWeaponAttrRequirement = null);

        WeaponItemModel UpdateWeaponItem(WeaponItemModel weapon, string name = null, string description = null, string placementDescription = null,
            string genericPlacementDescription = null, int addToAttackPower = 0, List<string> keywordsForPickup = null, ItemTraitModel traitToAdd = null, 
            bool inOriginalLocation = false, bool weaponHasAttrRequirementToView = false, AttributeRequirementModel viewWeaponAttrRequirement = null);
    }
}