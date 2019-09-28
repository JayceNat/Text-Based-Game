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

        public static CharacterAttribute MockPlayerAttrAfterAddLuck = new CharacterAttribute()
        {
            AvailablePoints = 20,
            MaximumCarryingCapacity = 2,
            CarriedItemsCount = 1,
            Defense = 5,
            Dexterity = 6,
            Luck = 10,
            Stamina = 8,
            Strength = 9,
            Wisdom = 10
        };

        public static CharacterAttribute MockPlayerAttrAfterRemoveLuck = new CharacterAttribute()
        {
            AvailablePoints = 20,
            MaximumCarryingCapacity = 2,
            CarriedItemsCount = 1,
            Defense = 5,
            Dexterity = 6,
            Luck = 4,
            Stamina = 8,
            Strength = 9,
            Wisdom = 10
        };


        public static CharacterAttribute MockPlayerAttrAfterAddDexterity = new CharacterAttribute()
        {
            AvailablePoints = 20,
            MaximumCarryingCapacity = 2,
            CarriedItemsCount = 1,
            Defense = 5,
            Dexterity = 10,
            Luck = 7,
            Stamina = 8,
            Strength = 9,
            Wisdom = 10
        };

        public static CharacterAttribute MockPlayerAttrAfterRemoveDexterity = new CharacterAttribute()
        {
            AvailablePoints = 20,
            MaximumCarryingCapacity = 2,
            CarriedItemsCount = 1,
            Defense = 5,
            Dexterity = 2,
            Luck = 7,
            Stamina = 8,
            Strength = 9,
            Wisdom = 10
        };
    }
}