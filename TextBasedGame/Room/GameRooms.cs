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
                                     "Tree branches rattle and tap on the glass as the gusts of wind begin to calm down a bit. \n \n" +
                                     "Just then, you hear some strange and sudden *clank* sound from your kitchen.",
            GenericRoomDescription = "You are standing in your living room.",
            AsExitDescription = "Ahead of you is the doorway leading to your living room.",
            AvailableExits = new RoomExit(),
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>()
                {
                    // Book on something about the town you live in (maybe a map?),
                    // A lighter next to a candle on the coffee table,
                    // Flashlight,
                    // Backpack (increases inventory, but need luck > 4 to see it)
                }
            },
            KeywordsToEnter = Constants.RoomKeywords.YourLivingRoom
        };
    }
}