using System.ComponentModel;
using System.Configuration;
using TextBasedGame.Shared.SaveGameConverters;

namespace TextBasedGame.Shared.Models
{
    [TypeConverter(typeof(AttributeRequirementConverter))]
    [SettingsSerializeAs(SettingsSerializeAs.String)]
    public class AttributeRequirement
    {
        public string RequirementName { get; set; }

        public string RelevantCharacterAttribute { get; set; }

        public int MinimumAttributeValue { get; set; }
    }
}