using System.Collections.Generic;
using TextBasedGame.Character.Constants;
using TextBasedGame.Item.Constants;
using TextBasedGame.Item.Models;
using TextBasedGame.Shared.Models;

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
            OriginalPlacementDescription = "Your LED flashlight is resting on a small table, just to the left of a candle. The battery is low.",
            GenericPlacementDescription = "There's a small LED flashlight resting on the ground beneath your feet.",
            KeywordsForPickup = ItemKeywords.Flashlight,
            ItemTraits = new List<ItemTrait>()
            {
                Program.ItemTraitCreator.BatteryPercentage(12)
            }
        };

        public static InventoryItem FlashlightBattery1 = new InventoryItem
        {
            ItemName = "Old Flashlight Battery",
            InOriginalLocation = true,
            ItemDescription = "A used battery for an LED flashlight. \n\t\t(Type 'use battery' to use it)",
            OriginalPlacementDescription = "On a wood shelf to your left is a flashlight battery.",
            GenericPlacementDescription = "There's a flashlight battery on the floor.",
            InventorySpaceConsumed = 1,
            KeywordsForPickup = ItemKeywords.FlashlightBattery,
            ItemTraits = new List<ItemTrait>()
            {
                Program.ItemTraitCreator.BatteryItem(21)
            },
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
            InventorySpaceConsumed = 0,
            AttributeRequirementToSee = new AttributeRequirement
            {
                RequirementName = "Luck - 2+",
                RelevantCharacterAttribute = AttributeStrings.Luck,
                MinimumAttributeValue = 2
            },
            AttributeRequirementToTake = new AttributeRequirement
            {
                RequirementName = "Luck - 2+",
                RelevantCharacterAttribute = AttributeStrings.Luck,
                MinimumAttributeValue = 2
            }
        };

        public static InventoryItem StrangeCreaturesBook = new InventoryItem
        {
            ItemName = "Book on Strange Creatures",
            InOriginalLocation = true,
            ItemDescription = "A book on mythical creatures. Henry (your friend who lives in a cabin across town) gave it to you." +
                              "\n\t\t(Type 'use book' to read it)",
            OriginalPlacementDescription = "On a dusty metal table you spot an old book that Henry gave to you a while back.",
            GenericPlacementDescription = "A dusty old book on strange creatures is laying on the floor.",
            InventorySpaceConsumed = 1,
            KeywordsForPickup = ItemKeywords.StrangeCreaturesBook,
            ItemTraits = new List<ItemTrait>
            {
                Program.ItemTraitCreator.WisdomIncrease(2),
                Program.ItemTraitCreator.DexterityIncrease(1)
            }
        };

        public static InventoryItem DirtyLetter = new InventoryItem
        {
            ItemName = "Dirty Letter",
            InOriginalLocation = true,
            ItemDescription = "It's a small, dirty letter that you found under your front doormat. \n\t\t(Type 'use letter' to read it)",
            OriginalPlacementDescription = "A small, dirty letter is sticking half way out from under your doormat.",
            GenericPlacementDescription = "A small, dirty letter is on the ground.",
            InventorySpaceConsumed = 1,
            KeywordsForPickup = ItemKeywords.DirtyLetter
        };
    }
}