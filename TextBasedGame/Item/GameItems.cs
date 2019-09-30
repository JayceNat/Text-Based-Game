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
            TreatItemAs = ItemUseTypes.ConsumableBattery,
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
            TreatItemAs = ItemUseTypes.ConsumableHealth,
            KeywordsForPickup = ItemKeywords.PlainBagel,
            ItemTraits = new List<ItemTrait>()
            {
                Program.ItemTraitCreator.HealthItem(10)
            },
            InventorySpaceConsumed = 1
        };

        public static InventoryItem TinyBackpack = new InventoryItem
        {
            ItemName = "Tiny Backpack",
            InOriginalLocation = true,
            ItemDescription = "A tiny bag made of gray nylon.",
            OriginalPlacementDescription = "Tucked behind your living room sofa is your tiny backpack, you just barely noticed it.",
            GenericPlacementDescription = "An empty gray backpack is laying on the ground... It's tiny.",
            TreatItemAs = ItemUseTypes.Bag,
            KeywordsForPickup = ItemKeywords.TinyBackpack,
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
                RequirementName = "Luck - 1+",
                RelevantCharacterAttribute = AttributeStrings.Luck,
                MinimumAttributeValue = 1
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
            TreatItemAs = ItemUseTypes.Document,
            DocumentText = DocumentTexts.StrangeCreaturesBookText,
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
            TreatItemAs = ItemUseTypes.Document,
            DocumentText = DocumentTexts.DirtyLetterText,
            KeywordsForPickup = ItemKeywords.DirtyLetter
        };

        public static InventoryItem Newspaper = new InventoryItem
        {
            ItemName = "Newspaper",
            InOriginalLocation = true,
            ItemDescription = "The local newspaper that was on your driveway.",
            OriginalPlacementDescription = "There's a newspaper laying on the driveway that you forgot to pick up yesterday.",
            GenericPlacementDescription = "A copy of the local newspaper is on the ground. Looks brand new.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.Document,
            DocumentText = DocumentTexts.NewspaperText,
            KeywordsForPickup = ItemKeywords.Newspaper
        };

        public static InventoryItem ScotchWhiskey = new InventoryItem
        {
            ItemName = "Scotch Whiskey",
            InOriginalLocation = true,
            ItemDescription = "It'll warm you right up.",
            OriginalPlacementDescription = "You smile as you notice a small bottle of Scotch Whiskey stashed in the corner of the shed.",
            GenericPlacementDescription = "A bottle of some good Scotch Whiskey seems to have been left here.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.ConsumableAttribute,
            KeywordsForPickup = ItemKeywords.ScotchWhiskey,
            ItemTraits = new List<ItemTrait>
            {
                Program.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Stamina, 1)
            },
            AttributeRequirementToSee = new AttributeRequirement
            {
                RequirementName = "Luck - 2+",
                RelevantCharacterAttribute = AttributeStrings.Luck,
                MinimumAttributeValue = 2
            }
        };

        public static InventoryItem CanvasBookBag = new InventoryItem
        {
            ItemName = "Canvas Book-Bag",
            InOriginalLocation = true,
            ItemDescription = "A decently large bag made from rugged canvas.",
            OriginalPlacementDescription = "There's a canvas book-bag sitting on the floor of the shed.",
            GenericPlacementDescription = "A rugged canvas book-bag is laying empty on the floor.",
            InventorySpaceConsumed = 0,
            TreatItemAs = ItemUseTypes.Bag,
            KeywordsForPickup = ItemKeywords.CanvasBookBag,
            ItemTraits = new List<ItemTrait>
            {
                Program.ItemTraitCreator.CarryingCapacityIncrease(6),
                Program.ItemTraitCreator.CarriedItemsIncrease(0)
            }
        };
    }
}