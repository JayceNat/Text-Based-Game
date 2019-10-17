using System.Collections.Generic;
using TextBasedGame.Item.Models;
using TextBasedGame.Shared.Models;
using System;
using System.Xml.Serialization;

namespace TextBasedGame.Room.Models
{
    [Serializable]
    [XmlRoot("R")]
    public class Room
    {
        [XmlElement("nom")]
        public string RoomName { get; set; }

        [XmlElement("ent")]
        public bool RoomEntered { get; set; } = false;

        [XmlElement("initdr")]
        public string InitialRoomDescription { get; set; }

        [XmlElement("gendr")]
        public string GenericRoomDescription { get; set; }

        [XmlElement("exs")]
        public RoomExit AvailableExits { get; set; } = new RoomExit();

        [XmlArray("chrs")]
        [XmlArrayItem("chr")]
        public List<Character.Models.Character> RoomCharacters { get; set; } = new List<Character.Models.Character>();

        [XmlElement("ev")] 
        public bool RoomEvent { get; set; }

        [XmlElement("is")]
        public Items RoomItems { get; set; } = 
            new Items() { InventoryItems = new List<InventoryItem>(), WeaponItems = new List<WeaponItem>()};

        [XmlArray("kwrds")]
        [XmlArrayItem("kwrd")]
        public List<string> KeywordsToEnter { get; set; } = new List<string>();

        [XmlElement("tribqs")]
        public AttributeRequirement AttributeRequirementToSee { get; set; } = null;

        [XmlElement("iqs")]
        public ItemRequirement ItemRequirementToSee { get; set; } = null;

        [XmlElement("tribqe")]
        public AttributeRequirement AttributeRequirementToEnter { get; set; } = null;

        [XmlElement("iqe")]
        public ItemRequirement ItemRequirementToEnter { get; set; } = null;
    }
}