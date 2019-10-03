using System.Xml.Serialization;

namespace TextBasedGame.Item.Models
{
    public class ItemTrait
    {
        [XmlElement("nom")]
        public string TraitName { get; set; }

        [XmlElement("reltrib")]
        public string RelevantCharacterAttribute { get; set; }

        [XmlElement("v")]
        public int TraitValue { get; set; }
    }
}