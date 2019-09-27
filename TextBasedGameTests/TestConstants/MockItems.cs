using System.Collections.Generic;
using TextBasedGame.Character.Constants;
using TextBasedGame.Item.Models;

namespace TextBasedGameTests.TestConstants
{
    public class MockItems
    {
        public static InventoryItem MockItemFlare = new InventoryItem
        {
            ItemName = "Flare",
            InOriginalLocation = false,
            ItemDescription = "A red stick flare. It could be confused with dynamite.",
            OriginalPlacementDescription = "A flare rests on the table near the corner of the room.",
            GenericPlacementDescription = "A red stick rests on the ground. Looks like dynamite.",
            KeywordsForPickup = new List<string>
            {
                "red",
                "stick",
                "flare",
                "dynamite"
            },
            ItemTraits = new List<ItemTrait>
            {
                new ItemTrait()
                {
                    TraitName = "Wisdom + (1)!",
                    RelevantCharacterAttribute = AttributeStrings.Wisdom,
                    TraitValue = 1
                }
            }
        };

        public static InventoryItem MockItemRabbitsFoot = new InventoryItem
        {
            ItemName = "Rabbits Foot",
            InOriginalLocation = true,
            ItemDescription = "A soft white rabbits foot on a brass chain.",
            OriginalPlacementDescription = "Next to the bed, you see a small white object sitting on the nightstand.",
            GenericPlacementDescription = "An odd looking white object is laying on the floor.",
            KeywordsForPickup = new List<string>
            {
                "white",
                "object",
                "rabbit",
                "rabbits",
                "foot",
                "rabbitsfoot"
            },
            ItemTraits = new List<ItemTrait>
            {
                new ItemTrait()
                {
                    TraitName = "Luck + (3)!",
                    RelevantCharacterAttribute = AttributeStrings.Luck,
                    TraitValue = 3
                }
            }
        };

        public static WeaponItem MockItemGun = new WeaponItem()
        {
            WeaponName = ".44 Magnum",
            InOriginalLocation = false,
            WeaponDescription = "It's really heavy.",
            OriginalPlacementDescription = "A shiny revolver sits neatly on a pile of papers on the desk.",
            GenericPlacementDescription = "Someone seems to have left a revolver on the floor here...",
            AttackPower = 10,
            KeywordsForPickup = new List<string>
            {
                "gun",
                "revolver",
                "magnum",
                "pistol"
            },
            WeaponTraits = new List<ItemTrait>
            {
                new ItemTrait()
                {
                    TraitName = "Stamina + (2)!",
                    RelevantCharacterAttribute = AttributeStrings.Stamina,
                    TraitValue = 2
                }
            }
        };

        public static WeaponItem MockItemKatana = new WeaponItem
        {
            WeaponName = "Katana",
            InOriginalLocation = true,
            WeaponDescription = "A beautifully crafted katana. The blade is perfectly balanced.",
            OriginalPlacementDescription = "On the ground next to the ninja's body, his katana lays there shimmering in the light.",
            GenericPlacementDescription = "An elegant katana rests on the floor.",
            AttackPower = 7,
            KeywordsForPickup = new List<string>()
            {
                "sword",
                "katana",
                "blade"
            },
            WeaponTraits = new List<ItemTrait>()
            {
                new ItemTrait
                {
                    TraitName = "Dexterity + (4)!",
                    RelevantCharacterAttribute = AttributeStrings.Dexterity,
                    TraitValue = 4
                }
            }
        };
    }
}