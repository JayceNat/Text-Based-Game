using System.Collections.Generic;
using TextBasedGame.Item.Constants;
using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item
{
    public class GameWeapons
    {
        private static readonly IItemTraitCreator ItemTraitCreator = new Implementations.ItemTraitCreator();

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
                ItemTraitCreator.DefensePlusOne
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