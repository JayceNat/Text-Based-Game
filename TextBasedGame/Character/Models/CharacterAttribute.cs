using TextBasedGame.Character.Constants;

namespace TextBasedGame.Character.Models
{
    public class CharacterAttribute
    {
        public int AvailablePoints { get; set; } = CharacterAttributes.DefaultPointsToSpend;

        public int Defense { get; set; } = CharacterAttributes.DefaultPointsForAllAttributes;

        public int Dexterity { get; set; } = CharacterAttributes.DefaultPointsForAllAttributes;

        public int Luck { get; set; } = CharacterAttributes.DefaultPointsForAllAttributes;

        public int Stamina { get; set; } = CharacterAttributes.DefaultPointsForAllAttributes;

        public int Strength { get; set; } = CharacterAttributes.DefaultPointsForAllAttributes;

        public int Wisdom { get; set; } = CharacterAttributes.DefaultPointsForAllAttributes;
    }
}