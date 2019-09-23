using System.Collections.Generic;
using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Item.Implementations
{
    public class Item : IItem
    {
        public ItemsModel CreateItemsModel(List<InventoryItemModel> inventoryItems, List<WeaponItemModel> weaponItems)
        {
            ItemsModel itemsModel = new ItemsModel()
            {
                InventoryItems = inventoryItems,
                WeaponItems = weaponItems
            };

            return itemsModel;
        }

        public InventoryItemModel CreateInventoryItem(string name, string description, string placementDescription, 
            string genericPlacementDescription, List<string> keywordsForPickup, List<ItemTraitModel> traits, bool inOriginalLocation = true,
            bool itemHasAttrRequirementToView = false, AttributeRequirementModel viewItemAttrRequirement = null)
        {
            InventoryItemModel item = new InventoryItemModel()
            {
                ItemName = name,
                InOriginalLocation = inOriginalLocation,
                ItemDescription = description,
                OriginalPlacementDescription = placementDescription,
                GenericPlacementDescription = genericPlacementDescription,
                KeywordsForPickup = keywordsForPickup,
                ItemTraits = traits,
                ViewItemHasAttributeRequirement = itemHasAttrRequirementToView,
                ItemVisibilityAttributeRequirement = viewItemAttrRequirement
            };

            return item;
        }

        public InventoryItemModel UpdateInventoryItem(InventoryItemModel item, string name = null, string description = null,
            string genericPlacementDescription = null, string placementDescription = null, List<string> keywordsForPickup = null, 
            ItemTraitModel traitToAdd = null, bool inOriginalLocation = false, bool itemHasAttrRequirementToView = false, 
            AttributeRequirementModel viewItemAttrRequirement = null)
        {
            if (name != null)
            {
                item.ItemName = name;
            }

            if (description != null)
            {
                item.ItemDescription = description;
            }

            if (placementDescription != null)
            {
                item.OriginalPlacementDescription = placementDescription;
            }

            if (genericPlacementDescription != null)
            {
                item.GenericPlacementDescription = genericPlacementDescription;
            }

            if (keywordsForPickup != null)
            {
                item.KeywordsForPickup = keywordsForPickup;
            }

            if (traitToAdd != null)
            {
                item.ItemTraits.Add(traitToAdd);
            }

            if (viewItemAttrRequirement != null)
            {
                item.ItemVisibilityAttributeRequirement = viewItemAttrRequirement;
            }

            item.InOriginalLocation = inOriginalLocation;
            item.ViewItemHasAttributeRequirement = itemHasAttrRequirementToView;

            return item;
        }

        public WeaponItemModel CreateWeaponItem(string name, string description, string placementDescription, string genericPlacementDescription,
            int attackPower, List<string> keywordsForPickup, List<ItemTraitModel> traits, bool inOriginalLocation = true,
            bool weaponHasAttrRequirementToView = false, AttributeRequirementModel viewWeaponAttrRequirement = null)
        {
            WeaponItemModel weapon = new WeaponItemModel()
            {
                WeaponName = name,
                InOriginalLocation = inOriginalLocation,
                WeaponDescription = description,
                OriginalPlacementDescription = placementDescription,
                GenericPlacementDescription = genericPlacementDescription,
                AttackPower = attackPower,
                KeywordsForPickup = keywordsForPickup,
                WeaponTraits = traits,
                ViewWeaponHasAttributeRequirement = weaponHasAttrRequirementToView,
                WeaponVisibilityAttributeRequirement = viewWeaponAttrRequirement
            };

            return weapon;
        }

        public WeaponItemModel UpdateWeaponItem(WeaponItemModel weapon, string name = null, string description = null, string placementDescription = null,
            string genericPlacementDescription = null, int addToAttackPower = 0, List<string> keywordsForPickup = null, 
            ItemTraitModel traitToAdd = null, bool inOriginalLocation = false, bool weaponHasAttrRequirementToView = false, 
            AttributeRequirementModel viewWeaponAttrRequirement = null)
        {
            if (name != null)
            {
                weapon.WeaponName = name;
            }

            if (description != null)
            {
                weapon.WeaponDescription = description;
            }

            if (placementDescription != null)
            {
                weapon.OriginalPlacementDescription = placementDescription;
            }

            if (genericPlacementDescription != null)
            {
                weapon.GenericPlacementDescription = genericPlacementDescription;
            }

            if (addToAttackPower != 0)
            {
                weapon.AttackPower += addToAttackPower;
            }

            if (keywordsForPickup != null)
            {
                weapon.KeywordsForPickup = keywordsForPickup;
            }

            if (traitToAdd != null)
            {
                weapon.WeaponTraits.Add(traitToAdd);
            }

            if (viewWeaponAttrRequirement != null)
            {
                weapon.WeaponVisibilityAttributeRequirement = viewWeaponAttrRequirement;
            }

            weapon.InOriginalLocation = inOriginalLocation;
            weapon.ViewWeaponHasAttributeRequirement = weaponHasAttrRequirementToView;

            return weapon;
        }
    }
}