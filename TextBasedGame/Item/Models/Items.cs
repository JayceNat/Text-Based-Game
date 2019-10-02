using System.Collections.Generic;

namespace TextBasedGame.Item.Models
{
    public class Items
    {
        public List<InventoryItem> InventoryItems { get; set; }

        public List<WeaponItem> WeaponItems { get; set; }
    }
}