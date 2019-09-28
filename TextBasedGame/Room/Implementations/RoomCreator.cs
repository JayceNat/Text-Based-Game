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

        // Constructor: Add the reference to all the Room Objects here
        public RoomCreator()
        {
            YourBedroom = GameRooms.YourBedroom;
            YourLivingRoom = GameRooms.YourLivingRoom;
            YourKitchen = GameRooms.YourKitchen;
            YourFrontEntryway = GameRooms.YourFrontEntryway;

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
                WestRoom = YourLivingRoom,
                WestRoomDescription = "To your left is the entrance to " + YourLivingRoom.RoomName + "."
            };
            YourFrontEntryway.AvailableExits = new RoomExit()
            {
                EastRoom = YourLivingRoom,
                EastRoomDescription = "To your right is the entrance to " + YourLivingRoom.RoomName + "."
            };
        }
    }
}