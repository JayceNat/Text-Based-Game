using System.Collections.Generic;
using TextBasedGame.Item.Constants;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item
{
    public class GameWeapons
    {
        // This is where all Weapon Items for the game are defined/instantiated
        // Note: These should only ever be referenced by the ItemCreator

        public static WeaponItem BaseballBat = new WeaponItem
        {
            WeaponName = "Baseball Bat",
            InOriginalLocation = true,
            WeaponDescription = "A solid maple wood baseball bat.",
            OriginalPlacementDescription = "You notice your old baseball bat propped up in the corner of the room near your closet.",
            GenericPlacementDescription = "A solid wood baseball bat lays across the floor. It looks like maple wood.",
            AttackPower = 2,
            KeywordsForPickup = ItemKeywords.BaseballBat,
            WeaponTraits = new List<ItemTrait>
            {
                Program.ItemTraitCreator.DefenseIncrease(1)
            }
        };

        public static WeaponItem LumberAxe = new WeaponItem
        {
            WeaponName = "Lumber Axe",
            InOriginalLocation = true,
            WeaponDescription = "A hefty red axe; made for chopping wood.",
            OriginalPlacementDescription = "Leaning against the shed wall next to your leg is a lumber axe.",
            GenericPlacementDescription = "A hefty red lumber axe is laying on the ground.",
            AttackPower = 5,
            KeywordsForPickup = ItemKeywords.LumberAxe,
            WeaponTraits = new List<ItemTrait>
            {
                Program.ItemTraitCreator.DefenseIncrease(1),
                Program.ItemTraitCreator.StrengthIncrease(1)
            }
        };

        public static WeaponItem MagnumRevolver = new WeaponItem
        {
            WeaponName = ".44 Magnum",
            InOriginalLocation = true,
            WeaponDescription = "A hefty revolver. It's been well taken care of.",
            OriginalPlacementDescription = "",
            GenericPlacementDescription = "Someone seems to have left a revolver laying on the floor here.",
            AttackPower = 20,
            AmmunitionAmount = 5,
            KeywordsForPickup = ItemKeywords.MagnumRevolver,
            WeaponTraits = new List<ItemTrait>
            {
                Program.ItemTraitCreator.StrengthIncrease(3)
            }
        };

        public static WeaponItem GhoulClaws = new WeaponItem
        {
            WeaponName = "Ghoul Claws",
            InOriginalLocation = false,
            WeaponDescription = "Incredibly sharp, jagged claws from the tips of a Ghoul's bloody fingers.",
            OriginalPlacementDescription = "",
            GenericPlacementDescription = "Bloodied and sharp black objects lay strewn on the floor... \n They almost look like shards of obsidian.",
            AttackPower = 8
        };
    }
}