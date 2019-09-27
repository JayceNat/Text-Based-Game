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

        // Privately used by this class to add the Room references to Room Objects as the Exit Property
        private void AddExitsToAllRooms()
        {
            YourBedroom.AvailableExits = new RoomExit() { NorthRoom = YourLivingRoom };

            YourLivingRoom.AvailableExits = new RoomExit()
            {
                EastRoom = YourKitchen,
                SouthRoom = YourBedroom,
                WestRoom = YourFrontEntryway
            };

            YourKitchen.AvailableExits = new RoomExit() { WestRoom = YourLivingRoom };
            YourFrontEntryway.AvailableExits = new RoomExit() { EastRoom = YourLivingRoom };
        }
    }
}