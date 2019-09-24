using System.Collections.Generic;
using TextBasedGame.Item.Constants;
using TextBasedGame.Item.Game_Items;
using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item
{
    public class Items
    {
        private static readonly IItem Item = new Implementations.Item();

        public static InventoryItem Flashlight = Item.CreateInventoryItem(
            "Flashlight",
            "A small LED flashlight that fits in your pocket.",
            "",
            "There's a small LED flashlight resting on the ground beneath your feet.",
            ItemKeywords.Flashlight,
            new List<ItemTrait>()
                { ItemTraits.BatteryPercentage });

        public static InventoryItem RunningShoes = Item.CreateInventoryItem(
            "Running Shoes",
            "Your trusty old running shoes. You swear you run way faster in them.",
            "Your old red and white running shoes are peaking up at you from under your bed.",
            "A pair of red and white running shoes are laying on the floor.",
            ItemKeywords.Shoes,
            new List<ItemTrait>()
                { ItemTraits.LuckPlusOne });
    }
}