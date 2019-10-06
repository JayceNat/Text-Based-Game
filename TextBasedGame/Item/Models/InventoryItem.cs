using System.Collections.Generic;
using System.Xml.Serialization;
using TextBasedGame.Item.Constants;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Item.Models
{
    public class InventoryItem
    {
        [XmlElement("nom")]
        public string ItemName { get; set; }

        [XmlElement("inog")]
        public bool InOriginalLocation { get; set; }

        [XmlElement("idr")]
        public string ItemDescription { get; set; }

        [XmlElement("ogdr")]
        public string OriginalPlacementDescription { get; set; }

        [XmlElement("gendr")]
        public string GenericPlacementDescription { get; set; }

        [XmlElement("inv")]
        public int InventorySpaceConsumed { get; set; } = 1;

        [XmlElement("typ")]
        public string TreatItemAs { get; set; } = ItemUseTypes.Default;

        [XmlElement("amtyp")]
        public string AmmunitionType { get; set; } = "";

        [XmlElement("amamt")]
        public int AmmunitionAmount { get; set; } = 1;

        [XmlElement("docx")]
        public string DocumentText { get; set; } = null;

        [XmlElement("wert")]
        public string WearableType { get; set; } = "";

        [XmlArray("kwds")]
        [XmlArrayItem("kwd")]
        public List<string> KeywordsForPickup { get; set; } = new List<string>();

        [XmlArray("trs")]
        [XmlArrayItem("tr")]
        public List<ItemTrait> ItemTraits { get; set; } = new List<ItemTrait>();

        [XmlElement("tribqs")]
        public AttributeRequirement AttributeRequirementToSee { get; set; } = null;

        [XmlElement("tribqt")]
        public AttributeRequirement AttributeRequirementToTake { get; set; } = null;
    }
}