using System.Collections.Generic;
using TextBasedGame.Item.Constants;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item
{
    public class GameItems
    {
        // This is where all Inventory Items for the game are defined/instantiated
        // Note: These should only ever be referenced by the ItemCreator

        public static InventoryItem Flashlight = new InventoryItem
        {
            ItemName = "Flashlight",
            InOriginalLocation = true,
            ItemDescription = "A small LED flashlight that fits in your pocket.",
            OriginalPlacementDescription = "Your LED flashlight is resting on the small table near your door, just to the left of a candle.",
            GenericPlacementDescription = "There's a small LED flashlight resting on the ground beneath your feet.",
            KeywordsForPickup = ItemKeywords.Flashlight,
            ItemTraits = new List<ItemTrait>()
            {
                Program.ItemTraitCreator.BatteryPercentage(27)
            }
        };

        public static InventoryItem RunningShoes = new InventoryItem
        {
            ItemName = "Running Shoes",
            InOriginalLocation = true,
            ItemDescription = "Your trusty old running shoes. You swear you run way faster in them.",
            OriginalPlacementDescription = "Your old red and white running shoes are peaking up at you from under your bed.",
            GenericPlacementDescription = "A pair of red and white running shoes are laying on the floor.",
            KeywordsForPickup = ItemKeywords.Shoes,
            ItemTraits = new List<ItemTrait>()
            {
                Program.ItemTraitCreator.LuckIncrease(1),
                Program.ItemTraitCreator.CarriedItemsIncrease(0)
            },
            InventorySpaceConsumed = 0
        };

        public static InventoryItem PlainBagel = new InventoryItem
        {
            ItemName = "Plain Bagel",
            InOriginalLocation = true,
            ItemDescription = "A plain bagel. It doesn't even have cream cheese on it...",
            OriginalPlacementDescription = "There's a bagel on the counter that you'd planned to eat earlier.",
            GenericPlacementDescription = "There's a... plain bagel just lying on the floor. I don't think the 5 second rule applies here.",
            KeywordsForPickup = ItemKeywords.PlainBagel,
            ItemTraits = new List<ItemTrait>()
            {
                Program.ItemTraitCreator.HealthItem(10)
            },
            InventorySpaceConsumed = 1
        };

        public static InventoryItem SmallBackpack = new InventoryItem
        {
            ItemName = "Small Backpack",
            InOriginalLocation = true,
            ItemDescription = "A small bag made of gray nylon.",
            OriginalPlacementDescription = "Tucked behind your living room sofa is your small backpack, you just barely noticed it.",
            GenericPlacementDescription = "An empty gray backpack is laying on the ground... It's pretty small.",
            KeywordsForPickup = ItemKeywords.SmallBackpack,
            ItemTraits = new List<ItemTrait>
            {
                Program.ItemTraitCreator.CarryingCapacityIncrease(2),
                Program.ItemTraitCreator.CarriedItemsIncrease(0)
            },
            InventorySpaceConsumed = 0
        };
    }
}