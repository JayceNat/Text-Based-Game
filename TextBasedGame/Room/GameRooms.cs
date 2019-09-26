using System.Collections.Generic;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Models;
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
                                     "There's a faint, early morning light coming in through the blinds of your open window. \n" +
                                     "You can feel the cool autumn air coming in from outside.",
            GenericRoomDescription = "You are standing in your bedroom.",
            AsExitDescription = "Behind you is the doorway into your bedroom.",
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
                                     "You see the wind start blowing quite intensely through your living room windows. \n" +
                                     "Tree branches rattle and tap on the glass just before the gusts of wind begin to calm down a bit. \n\n" +
                                     "Just then, you hear some strange and sudden *clank* sound from your kitchen.",
            GenericRoomDescription = "You are standing in your living room.",
            AsExitDescription = "Ahead of you is the doorway leading to your living room.",
            AvailableExits = new RoomExit(),
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>()
                {
                    Program.ItemCreator.Flashlight,
                    Program.ItemCreator.Backpack
                }
            },
            KeywordsToEnter = Constants.RoomKeywords.YourLivingRoom
        };

        public static Models.Room YourKitchen = new Models.Room
        {
            RoomName = "Your Kitchen",
            InitialRoomDescription = "You've entered your kitchen, and you're looking around for anything that might \n" +
                                     "have made that strange noise... \n\n" +
                                     "In an flurry of fur, you see a dark grey (and very plump) rat jump out from beneath your counter, \n" +
                                     "and scurry through your living room and out of the house through a small hole in your window screen.",
            GenericRoomDescription = "You're standing in your kitchen, on the light beige floor tiles.",
            AsExitDescription = "To your right is your kitchen.",
            AvailableExits = new RoomExit(),
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>()
                {

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
                                     "It's getting really windy out there.",
            GenericRoomDescription = "You're standing inside the entryway of your home.",
            AsExitDescription = "To your left is the small entryway of your house.",
            AvailableExits = new RoomExit(),
            KeywordsToEnter = Constants.RoomKeywords.YourFrontEntryway
        };
    }
}