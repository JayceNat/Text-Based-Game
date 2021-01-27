using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using TextBasedGame.Character.Constants;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Character.Models
{
    [Serializable]
    [XmlRoot("C")]
    public class Character
    {
        [XmlElement("nom")]
        public string Name { get; set; }

        [XmlElement("desc")]
        public string OnMeetDescription { get; set; }

        [XmlArray("phrs")]
        [XmlArrayItem("phr")]
        public List<string> CharacterPhrases { get; set; } = new List<string>();

        [XmlArray("aphrs")]
        [XmlArrayItem("aphr")]
        public List<string> CharacterAppeasedPhrases { get; set; } = new List<string>();

        [XmlArray("kwrds")]
        [XmlArrayItem("kwrd")]
        public List<string> CharacterKeywords { get; set; } = new List<string>();

        [XmlElement("desi")] 
        public InventoryItem DesiredItem { get; set; } = new InventoryItem();

        [XmlElement("offd")]
        public InventoryItem OfferedItem { get; set; }

        [XmlElement("typ")]
        public string CharacterType { get; set; } = CharacterTypes.Friendly;

        [XmlElement("loc")]
        public string CurrentRoomName { get; set; }

        [XmlElement("hepomax")]
        public int MaximumHealthPoints { get; set; } = CharacterDefaults.DefaultMaximumHealthPoints;

        [XmlElement("hepo")]
        public int HealthPoints { get; set; } = CharacterDefaults.DefaultBaseHealthPoints;

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