using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.Implementations
{
    public class ItemTraitCreator : IItemTraitCreator
    {
        // Declare all getters for any Traits you will use here
        public ItemTrait BatteryPercentage { get; }
        public ItemTrait DefensePlusOne { get; }
        public ItemTrait LuckPlusOne { get; }

        // Constructor: Add the reference to all the Trait Objects here
        public ItemTraitCreator()
        {
            BatteryPercentage = GameItemTraits.BatteryPercentage;
            DefensePlusOne = GameItemTraits.DefensePlusOne;
            LuckPlusOne = GameItemTraits.LuckPlusOne;
        }
    }
}