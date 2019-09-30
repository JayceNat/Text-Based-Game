using System.ComponentModel;
using System.Configuration;
using TextBasedGame.Item.Models;
using TextBasedGame.Shared.SaveGameConverters;

namespace TextBasedGame.Shared.Models
{
    [TypeConverter(typeof(ItemRequirementConverter))]
    [SettingsSerializeAs(SettingsSerializeAs.String)]
    public class ItemRequirement
    {
        public string RequirementName { get; set; }

        public InventoryItem RelevantItem { get; set; }
    }
}