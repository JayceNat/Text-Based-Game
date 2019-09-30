using System.Collections.Generic;
using TextBasedGame.Character.Constants;
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
                                     "Try typing 'items' - you will see the Tiny Backpack if your Luck is 1 or more.",
            GenericRoomDescription = "You are standing in your living room.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>()
                {
                    Program.ItemCreator.TinyBackpack
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
                                     "As you begin to notice the sound of your own breathing, the wind picks up outside again. \n" +
                                     "You can hear it pushing tree limbs into each other, and what sounds like other things too. \n\n" +
                                     "It's getting really windy out there. \n\n\n" +
                                     "HINT: There are some rooms that require you to have specific items or high enough stats to enter them. \n" +
                                     "Try typing 'exits' - you will see the exits from this room.\n" +
                                     "Try typing 'enter the porch' - if you are carrying the Tiny Backpack you can leave the house.",
            GenericRoomDescription = "You're standing inside the entryway of your home.",
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
                RequirementName = Program.ItemCreator.TinyBackpack.ItemName,
                RelevantItem = Program.ItemCreator.TinyBackpack
            }
        };

        public static Models.Room YourDriveway = new Models.Room
        {
            RoomName = "Your Driveway",
            InitialRoomDescription = "You walk over to your driveway in the moonlight.\n\n" +
                                     "Very quickly you notice the hood of your car is open, and the battery is missing...\n" +
                                     "You start wondering if Henry did that... And if so, why?\n\n" +
                                     "The walk to town is about 2 miles North.\n\n" +
                                     "The wind picks up suddenly and...\n\n" +
                                     "... Wait... It almost sounds like someone is stomping around in the grove of trees behind your house.",
            GenericRoomDescription = "You're standing outside your house on the moonlit driveway.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.Newspaper
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = Constants.RoomKeywords.YourDriveway
        };

        public static Models.Room YourShed = new Models.Room
        {
            RoomName = "Your Shed",
            InitialRoomDescription = "You open the rusted metal makeshift shed door and it creaks and screeches loudly.\n\n" +
                                     "It's really cold in here, and the whole shed seems flimsy in the wind.\n" +
                                     "It keeps shifting slightly from side to side and making unsettling noises with each gust.",
            GenericRoomDescription = "You're in your rusted, creaky old shed.",
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>
                {
                    Program.ItemCreator.ScotchWhiskey,
                    Program.ItemCreator.CanvasBookBag
                },
                WeaponItems = new List<WeaponItem>
                {
                    Program.ItemCreator.LumberAxe
                }
            },
            KeywordsToEnter = Constants.RoomKeywords.YourShed,
            AttributeRequirementToSee = new AttributeRequirement
            {
                RequirementName = "Wisdom - 3+",
                RelevantCharacterAttribute = AttributeStrings.Wisdom,
                MinimumAttributeValue = 3
            },
            ItemRequirementToEnter = new ItemRequirement
            {
                RequirementName = Program.ItemCreator.Flashlight.ItemName,
                RelevantItem = Program.ItemCreator.Flashlight
            }
        };

        public static Models.Room RoadConnectingYourHouseToTown = new Models.Room
        {
            RoomName = null,
            InitialRoomDescription = null,
            GenericRoomDescription = null,
            RoomItems = null,
            KeywordsToEnter = null,
            AttributeRequirementToSee = null,
            ItemRequirementToSee = null,
            AttributeRequirementToEnter = null,
            ItemRequirementToEnter = null
        };
    }
}