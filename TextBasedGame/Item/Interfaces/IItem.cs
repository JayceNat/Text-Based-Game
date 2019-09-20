using System.Collections.Generic;
using System.Collections.Specialized;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.Interfaces
{
    public interface IItem
    {
        InventoryItemModel CreateInventoryItem(string name, string description, 
            string placementDescription, List<ItemTraitModel> traits);

        WeaponItemModel CreateWeaponItem(string name, string description,
            string placementDescription, int attackPower, ItemTraitModel traits);
    }
}