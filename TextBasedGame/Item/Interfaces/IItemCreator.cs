using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.Interfaces
{
    public interface IItemCreator
    {
        // Declare all getters for any Items you will use here
        InventoryItem Flashlight { get; }
        InventoryItem RunningShoes { get; }
        InventoryItem Backpack { get; }

        // Declare all getters for any Weapons you will use here
        WeaponItem BaseballBat { get; }
        WeaponItem GhoulClaws { get; }
    }
}