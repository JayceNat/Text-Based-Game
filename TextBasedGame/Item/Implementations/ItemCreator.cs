using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.Implementations
{
    public class ItemCreator : IItemCreator
    {
        // Declare all getters for any Items you will use here
        public InventoryItem Flashlight { get; }
        public InventoryItem RunningShoes { get; }
        public InventoryItem Backpack { get; }

        // Declare all getters for any Weapons you will use here
        public WeaponItem BaseballBat { get; }
        public WeaponItem GhoulClaws { get; }

        // Constructor: Add the reference to all the Item/Weapon Objects here
        public ItemCreator()
        {
            // Inventory Items
            Flashlight = GameItems.Flashlight;
            RunningShoes = GameItems.RunningShoes;
            Backpack = GameItems.Backpack;

            // Weapon Items
            BaseballBat = GameWeapons.BaseballBat;
            GhoulClaws = GameWeapons.GhoulClaws;
        }
    }
}