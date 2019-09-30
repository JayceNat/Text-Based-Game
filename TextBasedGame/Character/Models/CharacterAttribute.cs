using System.ComponentModel;
using System.Configuration;
using TextBasedGame.Character.Constants;
using TextBasedGame.Character.SaveGameConverters;

namespace TextBasedGame.Character.Models
{
    [TypeConverter(typeof(CharacterAttributeConverter))]
    [SettingsSerializeAs(SettingsSerializeAs.String)]
    public class CharacterAttribute
    {
        public int AvailablePoints { get; set; } = CharacterDefaults.DefaultPointsToSpend;

        public int MaximumCarryingCapacity { get; set; } = CharacterDefaults.DefaultMaximumCarryingCapacity;

        public int CarriedItemsCount { get; set; } = 0;

        public int Defense { get; set; } = CharacterDefaults.DefaultValueForAllAttributes;

        public int Dexterity { get; set; } = CharacterDefaults.DefaultValueForAllAttributes;

        public int Luck { get; set; } = CharacterDefaults.DefaultValueForAllAttributes;

        public int Stamina { get; set; } = CharacterDefaults.DefaultValueForAllAttributes;

        public int Strength { get; set; } = CharacterDefaults.DefaultValueForAllAttributes;

        public int Wisdom { get; set; } = CharacterDefaults.DefaultValueForAllAttributes;
    }
}