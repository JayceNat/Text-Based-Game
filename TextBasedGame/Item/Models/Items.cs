using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using TextBasedGame.Item.SaveGameConverters;

namespace TextBasedGame.Item.Models
{
    [TypeConverter(typeof(ItemsConverter))]
    [SettingsSerializeAs(SettingsSerializeAs.String)]
    public class Items
    {
        public List<InventoryItem> InventoryItems { get; set; }

        public List<WeaponItem> WeaponItems { get; set; }
    }
}