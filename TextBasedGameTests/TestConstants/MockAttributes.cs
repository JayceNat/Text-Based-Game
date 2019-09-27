using TextBasedGame.Character.Models;

namespace TextBasedGameTests.TestConstants
{
    public class MockAttributes
    {
        public static CharacterAttribute MockPlayerAttrBeforeUpdate = new CharacterAttribute()
        {
            AvailablePoints = 20,
            MaximumCarryingCapacity = 2,
            CarriedItemsCount = 1,
            Defense = 5,
            Dexterity = 6,
            Luck = 7,
            Stamina = 8,
            Strength = 9,
            Wisdom = 10
        };

        public static CharacterAttribute MockPlayerAttrAfterUpdate = new CharacterAttribute
        {
            AvailablePoints = 19,
            MaximumCarryingCapacity = 2,
            CarriedItemsCount = 1,
            Defense = 5,
            Dexterity = 6,
            Luck = 7,
            Stamina = 8,
            Strength = 9,
            Wisdom = 11
        };
    }
}