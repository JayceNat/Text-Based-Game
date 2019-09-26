using TextBasedGame.Character.Constants;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item
{
    public class GameItemTraits
    {
        // This is where all Traits for the game are defined/instantiated
        // Note: These should only ever be referenced by the ItemTraitCreator

        public static ItemTrait BatteryPercentage = new ItemTrait
        {
            TraitName = $"Battery Percentage - {BatteryValue}",
            RelevantCharacterAttribute = "",
            TraitValue = BatteryValue
        };

        public static ItemTrait DefensePlusOne = new ItemTrait
        {
            TraitName = "Defense + (1)!",
            RelevantCharacterAttribute = AttributeStrings.Defense,
            TraitValue = 1
        };

        public static ItemTrait LuckPlusOne = new ItemTrait
        {
            TraitName = "Luck + (1)!",
            RelevantCharacterAttribute = AttributeStrings.Luck,
            TraitValue = 1
        };

        public static ItemTrait CarryingCapacityPlusTen = new ItemTrait
        {
            TraitName = "Inventory Space + (10)!",
            RelevantCharacterAttribute = AttributeStrings.MaxCarryingCapacity,
            TraitValue = 10
        };

        public static ItemTrait CarriedItemCountMinusOne = new ItemTrait
        {
            TraitName = "This item does not consume inventory space.",
            RelevantCharacterAttribute = AttributeStrings.CarriedItemsCount,
            TraitValue = -1
        };

        private const int BatteryValue = 100;
    }
}