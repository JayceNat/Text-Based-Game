using System.Collections.Generic;
using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Item.Implementations
{
    public class Item : IItem
    {
        public Models.Items CreateItemsModel(List<InventoryItem> inventoryItems, List<WeaponItem> weaponItems)
        {
            var itemsObject = new Models.Items()
            {
                InventoryItems = inventoryItems,
                WeaponItems = weaponItems
            };

            return itemsObject;
        }

        public InventoryItem CreateInventoryItem(string name, string description, string placementDescription, 
            string genericPlacementDescription, List<string> keywordsForPickup, List<Models.ItemTrait> traits, bool inOriginalLocation = true,
            bool itemHasAttrRequirementToView = false, AttributeRequirement viewItemAttrRequirement = null)
        {
            var item = new InventoryItem()
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

        public InventoryItem UpdateInventoryItem(InventoryItem item, string name = null, string description = null,
            string genericPlacementDescription = null, string placementDescription = null, List<string> keywordsForPickup = null, 
            Models.ItemTrait traitToAdd = null, bool inOriginalLocation = false, bool itemHasAttrRequirementToView = false, 
            AttributeRequirement viewItemAttrRequirement = null)
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

        public WeaponItem CreateWeaponItem(string name, string description, string placementDescription, string genericPlacementDescription,
            int attackPower, List<string> keywordsForPickup, List<Models.ItemTrait> traits, bool inOriginalLocation = true,
            bool weaponHasAttrRequirementToView = false, AttributeRequirement viewWeaponAttrRequirement = null)
        {
            var weapon = new WeaponItem()
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

        public WeaponItem UpdateWeaponItem(WeaponItem weapon, string name = null, string description = null, string placementDescription = null,
            string genericPlacementDescription = null, int addToAttackPower = 0, List<string> keywordsForPickup = null, 
            Models.ItemTrait traitToAdd = null, bool inOriginalLocation = false, bool weaponHasAttrRequirementToView = false, 
            AttributeRequirement viewWeaponAttrRequirement = null)
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