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

        public static CharacterAttribute CharlieAttributes = new CharacterAttribute
        {
            AvailablePoints = 0,
            MaximumCarryingCapacity = 2,
            Defense = 0,
            Dexterity = 1,
            Luck = 3,
            Stamina = 0,
            Strength = 0,
            Wisdom = 2
        };

        public static CharacterAttribute HenryAttributes = new CharacterAttribute
        {
            AvailablePoints = 0,
            MaximumCarryingCapacity = 5,
            Defense = 8,
            Dexterity = 9,
            Luck = 2,
            Stamina = 5,
            Strength = 6,
            Wisdom = 10
        };

        public static CharacterAttribute GhoulAttributes = new CharacterAttribute
        {
            AvailablePoints = 0,
            MaximumCarryingCapacity = 2,
            Defense = 20,
            Dexterity = 12,
            Luck = 10,
            Stamina = 17,
            Strength = 25,
            Wisdom = 5
        };
    }
}