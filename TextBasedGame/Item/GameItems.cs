using System.Collections.Generic;
using TextBasedGame.Item.Constants;
using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item
{
    public class GameItems
    {
        private static readonly IItemTraitCreator ItemTraitCreator = new Implementations.ItemTraitCreator();

        public static InventoryItem Flashlight = new InventoryItem
        {
            ItemName = "Flashlight",
            InOriginalLocation = true,
            ItemDescription = "A small LED flashlight that fits in your pocket.",
            OriginalPlacementDescription = "Your LED flashlight is resting on the coffee table, just to the left of a candle.",
            GenericPlacementDescription = "There's a small LED flashlight resting on the ground beneath your feet.",
            KeywordsForPickup = ItemKeywords.Flashlight,
            ItemTraits = new List<ItemTrait>()
            {
                ItemTraitCreator.BatteryPercentage
            }
        };

        public static InventoryItem RunningShoes = new InventoryItem
        {
            ItemName = "Running Shoes",
            InOriginalLocation = false,
            ItemDescription = "Your trusty old running shoes. You swear you run way faster in them.",
            OriginalPlacementDescription = "Your old red and white running shoes are peaking up at you from under your bed.",
            GenericPlacementDescription = "A pair of red and white running shoes are laying on the floor.",
            KeywordsForPickup = ItemKeywords.Shoes,
            ItemTraits = new List<ItemTrait>()
            {
                ItemTraitCreator.LuckPlusOne
            }
        };
    }
}