using System.Collections.Generic;
using TextBasedGame.Constants;
using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;
using static TextBasedGame.Item.ItemTraits;

namespace TextBasedGame.Item
{
    public class Items
    {
        private static readonly IItem Item = new Implementations.Item();

        public static InventoryItemModel Flashlight = Item.CreateInventoryItem(
            "Flashlight",
            "A small LED flashlight that fits in your pocket.",
            "",
            "There's a small LED flashlight resting on the ground beneath your feet.",
            ItemKeywords.Flashlight,
            new List<ItemTraitModel>()
                { BatteryPercentage });

        public static InventoryItemModel RunningShoes = Item.CreateInventoryItem(
            "Running Shoes",
            "Your trusty old running shoes. You swear you run way faster in them.",
            "Your old red and white running shoes are peaking up at you from under your bed.",
            "A pair of red and white running shoes are laying on the floor.",
            ItemKeywords.Shoes,
            new List<ItemTraitModel>()
                { LuckPlusOne });
    }
}