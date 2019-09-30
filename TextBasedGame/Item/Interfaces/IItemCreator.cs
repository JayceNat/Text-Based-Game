using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.Interfaces
{
    public interface IItemCreator
    {
        // Declare all getters for any Items you will use here
        InventoryItem Flashlight { get; }
        InventoryItem RunningShoes { get; }
        InventoryItem TinyBackpack { get; }
        InventoryItem PlainBagel { get; }
        InventoryItem StrangeCreaturesBook { get; }
        InventoryItem FlashlightBattery { get; }
        InventoryItem DirtyLetter { get; }
        InventoryItem Newspaper { get; }
        InventoryItem ScotchWhiskey { get; }
        InventoryItem CanvasBookBag { get; }

        // Declare all getters for any Weapons you will use here
        WeaponItem BaseballBat { get; }
        WeaponItem LumberAxe { get; }
        WeaponItem MagnumRevolver { get; }
        WeaponItem GhoulClaws { get; }
    }
}