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
        public Models.Room YourDriveway { get; }
        public Models.Room YourShed { get; }
        public Models.Room RoadConnectingYourHouseToTown { get; }

        // Constructor: Add the reference to all the Room Objects here
        public RoomCreator()
        {
            YourBedroom = GameRooms.YourBedroom;
            YourLivingRoom = GameRooms.YourLivingRoom;
            YourKitchen = GameRooms.YourKitchen;
            YourFrontEntryway = GameRooms.YourFrontEntryway;
            YourBasement = GameRooms.YourBasement;
            YourFrontPorch = GameRooms.YourFrontPorch;
            YourDriveway = GameRooms.YourDriveway;
            YourShed = GameRooms.YourShed;
            RoadConnectingYourHouseToTown = GameRooms.RoadConnectingYourHouseToTown;

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
                NorthRoom = YourDriveway,
                NorthRoomDescription = "Ahead of you is " + YourDriveway.RoomName + ".",
                EastRoom = YourFrontEntryway,
                EastRoomDescription = "To your right is the door into your house, " + YourFrontEntryway.RoomName + ".",
                SouthRoom = YourShed,
                SouthRoomDescription = "Behind you, a ways back towards the trees is " + YourShed.RoomName + "."
            };

            YourDriveway.AvailableExits = new RoomExit()
            {
                NorthRoom = RoadConnectingYourHouseToTown,
                NorthRoomDescription = "To the North is the " + RoadConnectingYourHouseToTown.RoomName + ".",
                SouthRoom = YourFrontPorch,
                SouthRoomDescription = "Behind you, to the South, is " + YourFrontPorch.RoomName + "."
            };

            YourShed.AvailableExits = new RoomExit
            {
                NorthRoom = YourFrontPorch,
                NorthRoomDescription = "A little ways ahead of you is " + YourFrontPorch.RoomName + "."
            };
        }
    }
}