using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Character.Models
{
    [Serializable]
    [XmlRoot("C")]
    public class Character
    {
        [XmlElement("nom")]
        public string Name { get; set; }

        [XmlElement("loc")]
        public string CurrentRoomName { get; set; }

        [XmlElement("hepomax")]
        public int MaximumHealthPoints { get; set; } = Constants.CharacterDefaults.DefaultMaximumHealthPoints;

        [XmlElement("hepo")]
        public int HealthPoints { get; set; } = Constants.CharacterDefaults.DefaultBaseHealthPoints;

        [XmlElement("trib")]
        public CharacterAttribute Attributes { get; set; } = new CharacterAttribute();

        [XmlArray("ci")]
        [XmlArrayItem("i")]
        public List<InventoryItem> CarriedItems { get; set; } = new List<InventoryItem>();

        [XmlElement("cw")]
        public WeaponItem WeaponItem { get; set; } = new WeaponItem();

        [XmlElement("hebar")]
        public bool ShowInputHelp { get; set; } = true;

        [XmlElement("pdisi")]
        public bool PersistDisplayedItems { get; set; }

        [XmlElement("pdisw")]
        public bool PersistDisplayedWeapons { get; set; }

        [XmlElement("pdise")]
        public bool PersistDisplayedExits { get; set; }
    }
}