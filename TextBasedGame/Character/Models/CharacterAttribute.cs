using System.Xml.Serialization;
using TextBasedGame.Character.Constants;

namespace TextBasedGame.Character.Models
{
    public class CharacterAttribute
    {
        [XmlElement("avlpo")]
        public int AvailablePoints { get; set; } = CharacterDefaults.DefaultPointsToSpend;

        [XmlElement("macacap")]
        public int MaximumCarryingCapacity { get; set; } = CharacterDefaults.DefaultMaximumCarryingCapacity;

        [XmlElement("nocai")]
        public int CarriedItemsCount { get; set; } = 0;

        [XmlElement("fen")]
        public int Defense { get; set; } = CharacterDefaults.DefaultValueForAllAttributes;

        [XmlElement("x")]
        public int Dexterity { get; set; } = CharacterDefaults.DefaultValueForAllAttributes;

        [XmlElement("ck")]
        public int Luck { get; set; } = CharacterDefaults.DefaultValueForAllAttributes;

        [XmlElement("min")]
        public int Stamina { get; set; } = CharacterDefaults.DefaultValueForAllAttributes;

        [XmlElement("ren")]
        public int Strength { get; set; } = CharacterDefaults.DefaultValueForAllAttributes;

        [XmlElement("om")]
        public int Wisdom { get; set; } = CharacterDefaults.DefaultValueForAllAttributes;
    }
}