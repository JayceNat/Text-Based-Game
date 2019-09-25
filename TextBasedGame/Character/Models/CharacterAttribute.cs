using TextBasedGame.Character.Constants;

namespace TextBasedGame.Character.Models
{
    public class CharacterAttribute
    {
        public int AvailablePoints { get; set; } = CharacterAttributes.DefaultPointsToSpend;

        public int Defense { get; set; } = CharacterAttributes.DefaultValueForAllAttributes;

        public int Dexterity { get; set; } = CharacterAttributes.DefaultValueForAllAttributes;

        public int Luck { get; set; } = CharacterAttributes.DefaultValueForAllAttributes;

        public int Stamina { get; set; } = CharacterAttributes.DefaultValueForAllAttributes;

        public int Strength { get; set; } = CharacterAttributes.DefaultValueForAllAttributes;

        public int Wisdom { get; set; } = CharacterAttributes.DefaultValueForAllAttributes;
    }
}