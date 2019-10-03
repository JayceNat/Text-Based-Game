using System.Collections.Generic;
using System.Xml.Serialization;

namespace TextBasedGame.Item.Models
{
    public class Items
    {
        [XmlArray("iis")]
        [XmlArrayItem("ii")]
        public List<InventoryItem> InventoryItems { get; set; }

        [XmlArray("wis")]
        [XmlArrayItem("wi")]
        public List<WeaponItem> WeaponItems { get; set; }
    }
}