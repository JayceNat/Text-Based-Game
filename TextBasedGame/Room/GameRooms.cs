using System.Collections.Generic;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Models;
using TextBasedGame.Shared.Models;
using Items = TextBasedGame.Item.Models.Items;

namespace TextBasedGame.Room
{
    public class GameRooms
    {
        // This is where all Rooms for the game are defined/instantiated
        // Note: These should only ever be referenced by the RoomCreator

        public static Models.Room YourBedroom = new Models.Room
        {
            RoomName = "Your Bedroom",
            InitialRoomDescription = "You are standing in your bedroom, next to your bed. \n" +
                                     "There's faint moonlight coming in through the blinds of your open window. \n" +
                                     "You can feel the cool night air coming in from outside.",
            GenericRoomDescription = "You are standing in your bedroom.",
            AvailableExits = new RoomExit(),
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>()
                {
                    Program.ItemCreator.RunningShoes
                },
                WeaponItems = new List<WeaponItem>()
                {
                    Program.ItemCreator.BaseballBat
                }
            },
            KeywordsToEnter = Constants.RoomKeywords.YourBedroom
        };

        public static Models.Room YourLivingRoom = new Models.Room
        {
            RoomName = "Your Living Room",
            InitialRoomDescription = "You are now standing in your living room. \n" +
                                     "You hear the wind start blowing quite intensely through one of your open living room windows. \n" +
                                     "Tree branches rattle and tap on the glass just before the gusts of wind begin to calm down a bit. \n\n" +
                                     "Just then, you hear some strange and sudden *clank* sound from your kitchen. \n\n\n" +
                                     "HINT: There are some items that require you to have high enough stats to see or take them. \n" +
                                     "Try typing 'items' - you will see the Small Backpack if your Luck is 2 or more.",
            GenericRoomDescription = "You are standing in your living room.",
            AvailableExits = new RoomExit(),
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>()
                {
                    Program.ItemCreator.SmallBackpack
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = Constants.RoomKeywords.YourLivingRoom
        };

        public static Models.Room YourKitchen = new Models.Room
        {
            RoomName = "Your Kitchen",
            InitialRoomDescription = "You've entered your kitchen, and you're looking around for anything that might \n" +
                                     "have made that strange noise... \n\n" +
                                     "In an flurry of fur, you see a dark gray (and very plump) rat jump out from beneath your counter, \n" +
                                     "and scurry through your living room and out of the house through a small hole in your window screen.",
            GenericRoomDescription = "You're standing in your kitchen, on the light beige floor tiles.",
            AvailableExits = new RoomExit(),
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>()
                {
                    Program.ItemCreator.PlainBagel
                },
                WeaponItems = new List<WeaponItem>()
                {

                }
            },
            KeywordsToEnter = Constants.RoomKeywords.YourKitchen
        };

        public static Models.Room YourFrontEntryway = new Models.Room
        {
            RoomName = "Your Front Entryway",
            InitialRoomDescription = "Now you're standing just inside the front door of your house, in the entryway. \n" +
                                     "As you begin to notice the sound of your own breathing, the wind pick up outside again. \n" +
                                     "You can hear it pushing tree limbs into each other, and what sounds like other things too. \n\n" +
                                     "It's getting really windy out there. \n\n\n" +
                                     "HINT: There are some rooms that require you to have specific items or high enough stats to enter them. \n" +
                                     "Try typing 'exits' - you will see the exits from this room.\n" +
                                     "Try typing 'enter the porch' - if you are carrying the Small Backpack you can leave the house.",
            GenericRoomDescription = "You're standing inside the entryway of your home.",
            AvailableExits = new RoomExit(),
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.Flashlight
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = Constants.RoomKeywords.YourFrontEntryway
        };

        public static Models.Room YourBasement = new Models.Room
        {
            RoomName = "Your Basement",
            InitialRoomDescription = "You walked down the dark stairs into your basement, thanks to the flashlight.\n" +
                                     "The wind seems far quieter from down here... Almost silent, in fact.\n\n" +
                                     "Something about being in the basement right now is giving you the creeps.\n\n" +
                                     "Just then, your flashlight briefly flickers.",
            GenericRoomDescription = "You're in your basement. It's really dark and creepy in here.",
            AvailableExits = new RoomExit(),
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.StrangeCreaturesBook,
                    Program.ItemCreator.FlashlightBattery
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = Constants.RoomKeywords.YourBasement,
            ItemRequirementToSee = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Flashlight.ItemName,
                RelevantItem = Program.ItemCreator.Flashlight
            },
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Flashlight.ItemName,
                RelevantItem = Program.ItemCreator.Flashlight
            }
        };

        public static Models.Room YourFrontPorch = new Models.Room
        {
            RoomName = "Your Front Porch",
            InitialRoomDescription = "You've just walked out of your house, and you're standing outside the front door. \n" +
                                     "The wind is gusting aggressively in the trees overhead, but the air is oddly calm around you. \n\n" +
                                     "Those haunting sounds that woke you up seem to be non-existent... Maybe you dreamt them? \n\n" +
                                     "You suddenly notice a small, dirty letter poking out from under your doormat... \n" +
                                     "It definitely wasn't there when you came home earlier.",
            GenericRoomDescription = "You're on your front porch, just outside the front door of your house.",
            AvailableExits = new RoomExit(),
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.DirtyLetter
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = Constants.RoomKeywords.YourFrontPorch,
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.SmallBackpack.ItemName,
                RelevantItem = Program.ItemCreator.SmallBackpack
            }
        };
    }
}