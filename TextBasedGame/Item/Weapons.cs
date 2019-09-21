using System.Collections.Generic;
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
            2,
            new List<ItemTraitModel>()
                { DefensePlusOne });

        public static WeaponItemModel GhoulClaws = Weapon.CreateWeaponItem(
            "Ghoul Claws",
            "Incredibly sharp, jagged claws on the tips of The Ghoul's bloody fingers.",
            "",
            8,
            new List<ItemTraitModel>());
    }
}