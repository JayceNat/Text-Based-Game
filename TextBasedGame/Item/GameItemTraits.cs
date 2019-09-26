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
            TraitName = "Battery Percentage",
            RelevantCharacterAttribute = "",
            TraitValue = 100
        };

        public static ItemTrait DefensePlusOne = new ItemTrait
        {
            TraitName = "Defense + (1)!",
            RelevantCharacterAttribute = CharacterAttributes.Defense,
            TraitValue = 1
        };

        public static ItemTrait LuckPlusOne = new ItemTrait
        {
            TraitName = "Luck + (1)!",
            RelevantCharacterAttribute = CharacterAttributes.Luck,
            TraitValue = 1
        };
    }
}