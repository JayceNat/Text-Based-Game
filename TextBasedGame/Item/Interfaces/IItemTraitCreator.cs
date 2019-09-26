using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.Interfaces
{
    public interface IItemTraitCreator
    {
        // Declare all getters for any Traits you will use here
        ItemTrait BatteryPercentage { get; }
        ItemTrait DefensePlusOne { get; }
        ItemTrait LuckPlusOne { get; }
        ItemTrait CarryingCapacityPlusTen { get; }
        ItemTrait CarriedItemCountMinusOne { get; }
    }
}