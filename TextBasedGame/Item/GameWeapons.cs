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
            WeaponTraits = new List<ItemTrait>()
            {
                Program.ItemTraitCreator.DefensePlusOne
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