using System.Collections.Generic;
using TextBasedGame.Constants;
using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;
using static TextBasedGame.Item.ItemTraits;

namespace TextBasedGame.Item
{
    public class Weapons
    {
        private static readonly IItem Weapon = new Implementations.Item();

        public static WeaponItemModel BaseballBat = Weapon.CreateWeaponItem(
            "Baseball Bat",
            "A solid maple wood baseball bat.",
            "You notice your old baseball bat propped up in the corner of the room near your closet.",
            "A solid wood baseball bat lays across the floor. It looks like maple wood.",
            2,
            ItemKeywords.BaseballBat,
            new List<ItemTraitModel>()
                { DefensePlusOne });

        public static WeaponItemModel GhoulClaws = Weapon.CreateWeaponItem(
            "Ghoul Claws",
            "Incredibly sharp, jagged claws from the tips of a Ghoul's bloody fingers.",
            "",
            "Bloodied and sharp black objects lay strewn on the floor... \n They almost look like shards of obsidian.",
            8,
            null,
            new List<ItemTraitModel>());
    }
}