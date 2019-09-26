using System.Collections.Generic;
using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Item.Implementations
{
    public class ItemCreator : IItemCreator
    {
        // Declare all getters for any Items you will use here
        public InventoryItem Flashlight { get; }
        public InventoryItem RunningShoes { get; }

        // Declare all getters for any Weapons you will use here
        public WeaponItem BaseballBat { get; }
        public WeaponItem GhoulClaws { get; }

        // Constructor: Add the reference to all the Item/Weapon Objects here
        public ItemCreator()
        {
            // Inventory Items
            Flashlight = GameItems.Flashlight;
            RunningShoes = GameItems.RunningShoes;

            // Weapon Items
            BaseballBat = GameWeapons.BaseballBat;
            GhoulClaws = GameWeapons.GhoulClaws;
        }

        // Will handle overwriting specific properties of an InventoryItem Object 
        public InventoryItem UpdateInventoryItem(InventoryItem item, string name = null, string description = null,
            string genericPlacementDescription = null, string placementDescription = null, List<string> keywordsForPickup = null, 
            ItemTrait traitToAdd = null, bool inOriginalLocation = false, AttributeRequirement attrRequirementToView = null)
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

            if (attrRequirementToView != null)
            {
                item.AttributeRequirementToSee = attrRequirementToView;
            }

            item.InOriginalLocation = inOriginalLocation;

            return item;
        }

        // Will handle overwriting specific properties of a WeaponItem Object 
        public WeaponItem UpdateWeaponItem(WeaponItem weapon, string name = null, string description = null, string placementDescription = null,
            string genericPlacementDescription = null, int addToAttackPower = 0, List<string> keywordsForPickup = null, 
            ItemTrait traitToAdd = null, bool inOriginalLocation = false, AttributeRequirement attrRequirementToView = null)
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

            if (attrRequirementToView != null)
            {
                weapon.AttributeRequirementToSee = attrRequirementToView;
            }

            weapon.InOriginalLocation = inOriginalLocation;

            return weapon;
        }
    }
}