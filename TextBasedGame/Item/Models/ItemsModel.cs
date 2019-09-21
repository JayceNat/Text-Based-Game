using System.Collections.Generic;

namespace TextBasedGame.Item.Models
{
    public class ItemsModel
    {
        public List<InventoryItemModel> InventoryItems { get; set; }

        public List<WeaponItemModel> WeaponItems { get; set; }
    }
}