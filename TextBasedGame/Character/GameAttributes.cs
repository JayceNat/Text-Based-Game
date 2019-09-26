using TextBasedGame.Character.Constants;
using TextBasedGame.Character.Models;

namespace TextBasedGame.Character
{
    public class GameAttributes
    {
        // This is where all Character Attributes for the game are defined/instantiated
        // Note: These should only ever be referenced by the AttributeCreator

        public static CharacterAttribute PlayerAttributes = new CharacterAttribute
        {
            AvailablePoints = CharacterDefaults.DefaultPointsToSpend,
            MaximumCarryingCapacity = CharacterDefaults.DefaultMaximumCarryingCapacity,
            Defense = CharacterDefaults.DefaultValueForAllAttributes,
            Dexterity = CharacterDefaults.DefaultValueForAllAttributes,
            Luck = CharacterDefaults.DefaultValueForAllAttributes,
            Stamina = CharacterDefaults.DefaultValueForAllAttributes,
            Strength = CharacterDefaults.DefaultValueForAllAttributes,
            Wisdom = CharacterDefaults.DefaultValueForAllAttributes
        };

        public static CharacterAttribute GhoulAttributes = new CharacterAttribute
        {
            AvailablePoints = 0,
            MaximumCarryingCapacity = 0,
            Defense = 7,
            Dexterity = 4,
            Luck = 6,
            Stamina = 6,
            Strength = 9,
            Wisdom = 4
        };
    }
}