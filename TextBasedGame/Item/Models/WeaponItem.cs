using System.Collections.Generic;
using System.Xml.Serialization;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Item.Models
{
    public class WeaponItem
    {
        [XmlElement("nom")]
        public string WeaponName { get; set; }

        [XmlElement("inog")]
        public bool InOriginalLocation { get; set; }

        [XmlElement("wdr")]
        public string WeaponDescription { get; set; }

        [XmlElement("ogdr")]
        public string OriginalPlacementDescription { get; set; }

        [XmlElement("gendr")]
        public string GenericPlacementDescription { get; set; }

        [XmlElement("akpwr")]
        public int AttackPower { get; set; }

        [XmlElement("am")]
        public int AmmunitionAmount { get; set; } = -1;

        [XmlElement("amtyp")]
        public string AmmunitionType { get; set; } = "";

        [XmlArray("kwrds")]
        [XmlArrayItem("kwrd")]
        public List<string> KeywordsForPickup { get; set; } = new List<string>();

        [XmlArray("trs")]
        [XmlArrayItem("tr")]
        public List<ItemTrait> WeaponTraits { get; set; } = new List<ItemTrait>();

        [XmlElement("tribqs")]
        public AttributeRequirement AttributeRequirementToSee { get; set; } = null;

        [XmlElement("tribqt")]
        public AttributeRequirement AttributeRequirementToTake { get; set; } = null;
    }
}