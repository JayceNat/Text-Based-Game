using TextBasedGame.Constants;
using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item
{
    public class ItemTraits
    {
        private static readonly IItemTrait Trait = new Implementations.ItemTrait();

        public static ItemTraitModel BatteryPercentage = Trait.CreateItemTrait("Battery Percentage", null, 100);

        public static ItemTraitModel DefensePlusOne = Trait.CreateItemTrait("Defense + (1)!", CharacterAttributes.Defense, 1);

        public static ItemTraitModel LuckPlusOne = Trait.CreateItemTrait("Luck + (1)!", CharacterAttributes.Luck, 1);
    }
}