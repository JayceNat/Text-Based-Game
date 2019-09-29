using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.Interfaces
{
    public interface IItemCreator
    {
        // Declare all getters for any Items you will use here
        InventoryItem Flashlight { get; }
        InventoryItem RunningShoes { get; }
        InventoryItem SmallBackpack { get; }
        InventoryItem PlainBagel { get; }
        InventoryItem StrangeCreaturesBook { get; }
        InventoryItem FlashlightBattery { get; }
        InventoryItem DirtyLetter { get; }

        // Declare all getters for any Weapons you will use here
        WeaponItem BaseballBat { get; }
        WeaponItem MagnumRevolver { get; }
        WeaponItem GhoulClaws { get; }
    }
}