using TextBasedGame.Character.Constants;
using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.Game_Items
{
    public class ItemTraits
    {
        private static readonly IItemTrait Trait = new Implementations.ItemTrait();

        public static ItemTrait BatteryPercentage = Trait.CreateItemTrait("Battery Percentage", null, 100);

        public static ItemTrait DefensePlusOne = Trait.CreateItemTrait("Defense + (1)!", CharacterAttributes.Defense, 1);

        public static ItemTrait LuckPlusOne = Trait.CreateItemTrait("Luck + (1)!", CharacterAttributes.Luck, 1);
    }
}