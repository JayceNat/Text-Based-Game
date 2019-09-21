using System.Collections.Generic;
using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.Implementations
{
    public class Item : IItem
    {
        public InventoryItemModel CreateInventoryItem(string name, string description, string placementDescription, List<ItemTraitModel> traits)
        {
            InventoryItemModel item = new InventoryItemModel()
            {
                ItemName = name,
                ItemDescription = description,
                ItemPlacementDescription = placementDescription,
                ItemTraits = traits
            };

            return item;
        }

        public WeaponItemModel CreateWeaponItem(string name, string description, string placementDescription, int attackPower, List<ItemTraitModel> traits)
        {
            WeaponItemModel weapon = new WeaponItemModel()
            {
                WeaponName = name,
                WeaponDescription = description,
                WeaponPlacementDescription = placementDescription,
                AttackPower = attackPower,
                WeaponTraits = traits
            };

            return weapon;
        }
    }
}