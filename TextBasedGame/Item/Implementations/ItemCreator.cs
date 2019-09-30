using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.Implementations
{
    public class ItemCreator : IItemCreator
    {
        // Declare all getters for any Items you will use here
        public InventoryItem Flashlight { get; }
        public InventoryItem RunningShoes { get; }
        public InventoryItem TinyBackpack { get; }
        public InventoryItem PlainBagel { get; }
        public InventoryItem StrangeCreaturesBook { get; }
        public InventoryItem FlashlightBattery { get; }
        public InventoryItem DirtyLetter { get; }
        public InventoryItem Newspaper { get; }
        public InventoryItem ScotchWhiskey { get; }
        public InventoryItem CanvasBookBag { get; }

        // Declare all getters for any Weapons you will use here
        public WeaponItem BaseballBat { get; }
        public WeaponItem LumberAxe { get; }
        public WeaponItem MagnumRevolver { get; }
        public WeaponItem GhoulClaws { get; }

        // Constructor: Add the reference to all the Item/Weapon Objects here
        public ItemCreator()
        {
            // Inventory Items
            Flashlight = GameItems.Flashlight;
            RunningShoes = GameItems.RunningShoes;
            TinyBackpack = GameItems.TinyBackpack;
            PlainBagel = GameItems.PlainBagel;
            StrangeCreaturesBook = GameItems.StrangeCreaturesBook;
            FlashlightBattery = GameItems.FlashlightBattery1;
            DirtyLetter = GameItems.DirtyLetter;
            Newspaper = GameItems.Newspaper;
            ScotchWhiskey = GameItems.ScotchWhiskey;
            CanvasBookBag = GameItems.CanvasBookBag;

            // Weapon Items
            BaseballBat = GameWeapons.BaseballBat;
            LumberAxe = GameWeapons.LumberAxe;
            MagnumRevolver = GameWeapons.MagnumRevolver;
            GhoulClaws = GameWeapons.GhoulClaws;
        }
    }
}