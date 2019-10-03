using System.Xml.Serialization;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Shared.Models
{
    public class ItemRequirement
    {
        [XmlElement("nom")]
        public string RequirementName { get; set; }

        [XmlElement("reli")]
        public InventoryItem RelevantItem { get; set; }
    }
}