using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.Implementations
{
    public class ItemCreator : IItemCreator
    {
        // Declare all getters for any Items you will use here
        public InventoryItem Bathrobe { get; }
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
        public InventoryItem DirtyGoldBullet { get; }
        public InventoryItem WornLeatherBoots { get; }
        public InventoryItem RabbitsFoot { get; }
        public InventoryItem StrangeThermos { get; }
        public InventoryItem AbandonedFlashlightBattery { get; }
        public InventoryItem TownCurfewNotice { get; }
        public InventoryItem HumanTeeth { get; }
        public InventoryItem WomansNecklace { get; }
        public InventoryItem BloodyJeans { get; }
        public InventoryItem LuckyBrandChewingGum { get; }
        public InventoryItem HuntingCap { get; }
        public InventoryItem PlatinumRing { get; }
        public InventoryItem SomberNote { get; }
        public InventoryItem TownSouthGateKey { get; }
        public InventoryItem EnergyBar { get; }
        public InventoryItem BottleOfScentMask { get; }
        public InventoryItem BoxOf44MagnumAmmo { get; }
        public InventoryItem WetGoldBullet { get; }
        public InventoryItem MiracleTonic { get; }
        public InventoryItem SnakeBracelet { get; }
        public InventoryItem WaterloggedJournal { get; }
        public InventoryItem BloodyGoldBullet { get; }
        public InventoryItem BomberJacket { get; }
        public InventoryItem BoxOfShotgunShells { get; }
        public InventoryItem LargeKnapsack { get; }
        public InventoryItem CannedMeat { get; }
        public InventoryItem TownNorthGateKey { get; }
        public InventoryItem GoldWristwatch { get; }
        public InventoryItem TownWestGateKey { get; }
        public InventoryItem WestForestNotice { get; }
        public InventoryItem TownEastGateKey { get; }
        public InventoryItem Crowbar { get; }
        public InventoryItem ToyBoat { get; }
        public InventoryItem BottleOfRum { get; }
        public InventoryItem SteelToedBoots { get; }

        // Missing Person Posters
        public InventoryItem MissingPersonPosterLucy { get; }
        public InventoryItem MissingPersonPosterPenny { get; }
        public InventoryItem MissingPersonPosterSimon { get; }
        public InventoryItem MissingPersonPosterArthur { get; }

        // Declare all getters for any Weapons you will use here
        public WeaponItem LetterOpener { get; }
        public WeaponItem BaseballBat { get; }
        public WeaponItem Femur { get; }
        public WeaponItem LumberAxe { get; }
        public WeaponItem FiremansAxe { get; }
        public WeaponItem MagnumRevolver { get; }
        public WeaponItem GhoulRifle { get; }
        public WeaponItem GhoulClaws { get; }

        // Constructor: Add the reference to all the Item/Weapon Objects here
        public ItemCreator()
        {
            // Inventory Items
            Bathrobe = GameItems.Bathrobe;
            Flashlight = GameItems.Flashlight;
            RunningShoes = GameItems.RunningShoes;
            TinyBackpack = GameItems.TinyBackpack;
            PlainBagel = GameItems.PlainBagel;
            StrangeCreaturesBook = GameItems.StrangeCreaturesBook;
            FlashlightBattery = GameItems.OldFlashlightBattery;
            DirtyLetter = GameItems.DirtyLetter;
            Newspaper = GameItems.Newspaper;
            ScotchWhiskey = GameItems.ScotchWhiskey;
            CanvasBookBag = GameItems.CanvasBookBag;
            DirtyGoldBullet = GameItems.DirtyGoldBullet;
            WornLeatherBoots = GameItems.WornLeatherBoots;
            RabbitsFoot = GameItems.RabbitsFoot;
            StrangeThermos = GameItems.StrangeThermos;
            AbandonedFlashlightBattery = GameItems.AbandonedFlashlightBattery;
            TownCurfewNotice = GameItems.TownCurfewNotice;
            HumanTeeth = GameItems.HumanTeeth;
            WomansNecklace = GameItems.WomansNecklace;
            BloodyJeans = GameItems.BloodyJeans;
            LuckyBrandChewingGum = GameItems.LuckyBrandChewingGum;
            HuntingCap = GameItems.HuntingCap;
            PlatinumRing = GameItems.PlatinumRing;
            SomberNote = GameItems.SomberNote;
            TownSouthGateKey = GameItems.TownSouthGateKey;
            EnergyBar = GameItems.EnergyBar;
            BottleOfScentMask = GameItems.BottleOfScentMask;
            BoxOf44MagnumAmmo = GameItems.BoxOf44MagnumAmmo;
            WetGoldBullet = GameItems.MuddyGoldBullet;
            MiracleTonic = GameItems.MiracleTonic;
            SnakeBracelet = GameItems.SnakeBracelet;
            WaterloggedJournal = GameItems.WaterloggedJournal;
            BloodyGoldBullet = GameItems.BloodyGoldBullet;
            BomberJacket = GameItems.BomberJacket;
            BoxOfShotgunShells = GameItems.BoxOfShotgunShells;
            LargeKnapsack = GameItems.LargeKnapsack;
            CannedMeat = GameItems.CannedMeat;
            TownNorthGateKey = GameItems.TownNorthGateKey;
            TownEastGateKey = GameItems.TownEastGateKey;
            TownWestGateKey = GameItems.TownWestGateKey;
            GoldWristwatch = GameItems.GoldWristwatch;
            WestForestNotice = GameItems.WestForestNotice;
            Crowbar = GameItems.Crowbar;
            ToyBoat = GameItems.ToyBoat;
            BottleOfRum = GameItems.BottleOfRum;
            SteelToedBoots = GameItems.SteelToedBoots;
            MissingPersonPosterLucy = GameItems.MissingPersonPosterLucy;
            MissingPersonPosterPenny = GameItems.MissingPersonPosterPenny;
            MissingPersonPosterSimon = GameItems.MissingPersonPosterSimon;
            MissingPersonPosterArthur = GameItems.MissingPersonPosterArthur;

            // Weapon Items
            LetterOpener = GameWeapons.LetterOpener;
            BaseballBat = GameWeapons.BaseballBat;
            Femur = GameWeapons.Femur;
            LumberAxe = GameWeapons.LumberAxe;
            FiremansAxe = GameWeapons.FiremansAxe;
            MagnumRevolver = GameWeapons.MagnumRevolver;
            GhoulRifle = GameWeapons.GhoulRifle;
            GhoulClaws = GameWeapons.GhoulClaws;
        }
    }
}