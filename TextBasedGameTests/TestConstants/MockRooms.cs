using System.Collections.Generic;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Models;

namespace TextBasedGameTests.TestConstants
{
    public class MockRooms
    {
        public static Room MockRoomObservatory = new Room
        {
            RoomName = "The Observatory",
            RoomEntered = false,
            InitialRoomDescription = "You walk into the observatory. It really does have an incredibly ominous air about it.",
            GenericRoomDescription = "You're standing in the ominous observatory.",
            AsExitDescription = "To the right is a large set of glass doors into an ominous looking room.",
            AvailableExits = new RoomExit(),
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>()
                {
                    MockItems.MockItemFlare
                },
                WeaponItems = new List<WeaponItem>()
                {
                    MockItems.MockItemGun
                }
            },
            KeywordsToEnter = new List<string>()
            {
                "observatory",
                "ominous",
                "odd",
                "glass"
            }
        };

        public static Room MockRoomNursery = new Room
        {
            RoomName = "The Nursery",
            RoomEntered = true,
            InitialRoomDescription = "You enter into a nursery that seems to be lived in... there's a bed here with a nightstand.",
            GenericRoomDescription = "You're in the nursery that's been made into some kind of bedroom.",
            AsExitDescription = "To your left is a room with plant leaves poking from the entrance. Maybe a nursery?",
            AvailableExits = new RoomExit(),
            RoomItems = new Items
            {
                InventoryItems = new List<InventoryItem>()
                {
                    MockItems.MockItemRabbitsFoot
                },
                WeaponItems = new List<WeaponItem>()
            },
            KeywordsToEnter = new List<string>()
            {
                "nursery",
                "plant",
                "leaves"
            }
        };

        public static Room MockRoomBathroom = new Room
        {
            RoomName = "The Bathroom",
            RoomEntered = false,
            InitialRoomDescription = "This place is filthy... It's probably going to give you nightmares.",
            GenericRoomDescription = "A filthy bathroom. Just get out.",
            AsExitDescription = "Behind you is what looks to be a bathroom door.",
            AvailableExits = new RoomExit(),
            RoomItems = new Items(),
            KeywordsToEnter = new List<string>()
            {
                "filthy",
                "bathroom",
                "restroom",
                "toilet"
            }
        };
    }
}