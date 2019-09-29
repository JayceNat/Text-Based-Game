using TextBasedGame.Room.Interfaces;
using TextBasedGame.Room.Models;

namespace TextBasedGame.Room.Implementations
{
    public class RoomCreator : IRoomCreator
    {
        // Declare all getters for any Rooms you will use here
        public Models.Room YourBedroom { get; }
        public Models.Room YourLivingRoom { get; }
        public Models.Room YourKitchen { get; }
        public Models.Room YourFrontEntryway { get; }
        public Models.Room YourBasement { get; }
        public Models.Room YourFrontPorch { get; }

        // Constructor: Add the reference to all the Room Objects here
        public RoomCreator()
        {
            YourBedroom = GameRooms.YourBedroom;
            YourLivingRoom = GameRooms.YourLivingRoom;
            YourKitchen = GameRooms.YourKitchen;
            YourFrontEntryway = GameRooms.YourFrontEntryway;
            YourBasement = GameRooms.YourBasement;
            YourFrontPorch = GameRooms.YourFrontPorch;

            AddExitsToAllRooms();
        }

        // Used to add the Room references to Room Objects as the Exit Property
        private void AddExitsToAllRooms()
        {
            YourBedroom.AvailableExits = new RoomExit()
            {
                NorthRoom = YourLivingRoom,
                NorthRoomDescription = "Ahead of you is the entrance to " + YourLivingRoom.RoomName + "."
            };

            YourLivingRoom.AvailableExits = new RoomExit()
            {
                EastRoom = YourKitchen,
                EastRoomDescription = "To your right is the entrance to " + YourKitchen.RoomName + ".",
                SouthRoom = YourBedroom,
                SouthRoomDescription = "Behind you is the entrance to " + YourBedroom.RoomName + ".",
                WestRoom = YourFrontEntryway,
                WestRoomDescription = "To your left is the entrance to " + YourFrontEntryway.RoomName + "."
            };

            YourKitchen.AvailableExits = new RoomExit()
            {
                NorthRoom = YourBasement,
                NorthRoomDescription = "Ahead of you is the door into " + YourBasement.RoomName + ".",
                WestRoom = YourLivingRoom,
                WestRoomDescription = "To your left is the entrance to " + YourLivingRoom.RoomName + "."
            };

            YourBasement.AvailableExits = new RoomExit()
            {
                SouthRoom = YourKitchen,
                SouthRoomDescription = "Behind you is the stairway up to " + YourKitchen.RoomName + "."
            };

            YourFrontEntryway.AvailableExits = new RoomExit()
            {
                EastRoom = YourLivingRoom,
                EastRoomDescription = "To your right is the entrance to " + YourLivingRoom.RoomName + ".",
                WestRoom = YourFrontPorch,
                WestRoomDescription = "To your left is the door out to " + YourFrontPorch.RoomName + "."
            };

            YourFrontPorch.AvailableExits = new RoomExit()
            {
                EastRoom = YourFrontEntryway,
                EastRoomDescription = "To your right is the door into your house, " + YourFrontEntryway.RoomName + "."
            };
        }
    }
}