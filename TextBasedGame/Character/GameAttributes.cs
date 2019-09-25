using TextBasedGame.Character.Constants;
using TextBasedGame.Character.Models;

namespace TextBasedGame.Character
{
    public class GameAttributes
    {
        public static CharacterAttribute PlayerAttributes = new CharacterAttribute
        {
            AvailablePoints = CharacterAttributes.DefaultPointsToSpend,
            Defense = CharacterAttributes.DefaultValueForAllAttributes,
            Dexterity = CharacterAttributes.DefaultValueForAllAttributes,
            Luck = CharacterAttributes.DefaultValueForAllAttributes,
            Stamina = CharacterAttributes.DefaultValueForAllAttributes,
            Strength = CharacterAttributes.DefaultValueForAllAttributes,
            Wisdom = CharacterAttributes.DefaultValueForAllAttributes
        };

        public static CharacterAttribute GhoulAttributes = new CharacterAttribute
        {
            AvailablePoints = 0,
            Defense = 7,
            Dexterity = 4,
            Luck = 6,
            Stamina = 6,
            Strength = 9,
            Wisdom = 4
        };
    }
}