using System.ComponentModel;
using System.Configuration;
using TextBasedGame.Item.SaveGameConverters;

namespace TextBasedGame.Item.Models
{
    [TypeConverter(typeof(ItemTraitConverter))]
    [SettingsSerializeAs(SettingsSerializeAs.String)]
    public class ItemTrait
    {
        public string TraitName { get; set; }

        public string RelevantCharacterAttribute { get; set; }

        public int TraitValue { get; set; }
    }
}