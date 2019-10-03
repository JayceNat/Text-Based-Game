using System.Xml.Serialization;

namespace TextBasedGame.Shared.Models
{
    public class AttributeRequirement
    {
        [XmlElement("nom")]
        public string RequirementName { get; set; }

        [XmlElement("reltrib")]
        public string RelevantCharacterAttribute { get; set; }

        [XmlElement("v")]
        public int MinimumAttributeValue { get; set; }
    }
}