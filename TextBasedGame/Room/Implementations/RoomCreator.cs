using TextBasedGame.Room.Interfaces;
using TextBasedGame.Room.Models;

namespace TextBasedGame.Room.Implementations
{
    public class RoomCreator : IRoomCreator
    {
        // Files to edit when adding a room: GameRooms.cs, RoomCreator.cs, GameSetupHandler.cs

        // Declare all getters for any Rooms you will use here
        public Models.Room YourBedroom { get; set; }
        public Models.Room YourLivingRoom { get; set; }
        public Models.Room YourKitchen { get; set; }
        public Models.Room YourFrontEntryway { get; set; }
        public Models.Room YourBasement { get; set; }
        public Models.Room YourFrontPorch { get; set; }
        public Models.Room YourDriveway { get; set; }
        public Models.Room YourShed { get; set; }
        public Models.Room RoadConnectingYourHouseToTown { get; set; }
        public Models.Room ForestLake { get; set; }
        public Models.Room ForestLakeTent { get; set; }
        public Models.Room EastForest { get; set; }
        public Models.Room EastForestLowerClearing { get; set; }
        public Models.Room EastForestUpperClearing { get; set; }
        public Models.Room DeepEastForest { get; set; }
        public Models.Room DeepEastForestLowerRiver { get; set; }
        public Models.Room DeepEastForestUpperRiver { get; set; }
        public Models.Room DeepEastForestUpperRiverCave { get; set; }
        public Models.Room EastForestCampground { get; set; }
        public Models.Room TownSouthEntrance { get; set; }
        public Models.Room AshburySouthSquare { get; set; }

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
            ForestLake = GameRooms.ForestLake;
            ForestLakeTent = GameRooms.ForestLakeTent;
            EastForest = GameRooms.EastForest;
            EastForestLowerClearing = GameRooms.EastForestLowerClearing;
            EastForestUpperClearing = GameRooms.EastForestUpperClearing;
            DeepEastForest = GameRooms.DeepEastForest;
            DeepEastForestLowerRiver = GameRooms.DeepEastForestLowerRiver;
            DeepEastForestUpperRiver = GameRooms.DeepEastForestUpperRiver;
            DeepEastForestUpperRiverCave = GameRooms.DeepEastForestUpperRiverCave;
            EastForestCampground = GameRooms.EastForestCampground;
            TownSouthEntrance = GameRooms.TownSouthEntrance;
            AshburySouthSquare = GameRooms.AshburySouthSquare;

            AddExitsToAllRooms();
        }

        // Used to add the Room references to Room Objects as the Exit Property
        public void AddExitsToAllRooms()
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
                WestRoomDescription = "To your left is " + YourFrontEntryway.RoomName + "."
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
                NorthRoomDescription = "To the North is " + RoadConnectingYourHouseToTown.RoomName + ".",
                SouthRoom = YourFrontPorch,
                SouthRoomDescription = "Behind you, to the South, is " + YourFrontPorch.RoomName + "."
            };

            YourShed.AvailableExits = new RoomExit
            {
                NorthRoom = YourFrontPorch,
                NorthRoomDescription = "A little ways ahead of you is " + YourFrontPorch.RoomName + "."
            };

            RoadConnectingYourHouseToTown.AvailableExits = new RoomExit
            {
                NorthRoom = TownSouthEntrance,
                NorthRoomDescription = "To the North, you see the illuminated road leading towards town. It'll be a long walk.",
                SouthRoom = YourDriveway,
                SouthRoomDescription = "Behind you, you can faintly see " + YourDriveway.RoomName + " in the distance."
            };

            ForestLake.AvailableExits = new RoomExit
            {
//                NorthRoom = null,
//                NorthRoomDescription = null,
                EastRoom = TownSouthEntrance,
                EastRoomDescription = "Back through the forest to the East is " + TownSouthEntrance.RoomName + ".",
//                SouthRoom = null,
//                SouthRoomDescription = null,
                WestRoom = ForestLakeTent,
                WestRoomDescription = "To the West, near the opposite side of the lake, seems to be a collapsed tent."
            };

            ForestLakeTent.AvailableExits = new RoomExit
            {
//                NorthRoom = null,
//                NorthRoomDescription = null,
                EastRoom = ForestLake,
                EastRoomDescription = "Back to the East is the bank of the lake near the forest.",
//                SouthRoom = null,
//                SouthRoomDescription = null,
//                WestRoom = null,
//                WestRoomDescription = null
            };

            EastForest.AvailableExits = new RoomExit
            {
                EastRoom = EastForestLowerClearing,
                EastRoomDescription = "Far through the trees to your right you can see moonlight illuminating a clearing.",
                WestRoom = TownSouthEntrance,
                WestRoomDescription = "To your left is the path West to the road by the Southern Entrance to town."
            };

            EastForestLowerClearing.AvailableExits = new RoomExit
            {
                NorthRoom = EastForestUpperClearing,
                NorthRoomDescription = "You can see the clearing continuing North ahead of you.",
                WestRoom = EastForest,
                WestRoomDescription = "To your left is the entrance into the trees of the East Forest."
            };

            EastForestUpperClearing.AvailableExits = new RoomExit
            {
                NorthRoom = DeepEastForest,
                NorthRoomDescription = "You can see a small, faint trail going North... Deeper into the East Forest.",
                SouthRoom = EastForestLowerClearing,
                SouthRoomDescription = "Behind you is the Southern part of the clearing."
            };

            DeepEastForest.AvailableExits = new RoomExit
            {
                //NorthRoom = FoggyTreeCemeteryTrail,
                //NorthRoomDescription = "There's a trail going North, into a fog...",
                EastRoom = DeepEastForestLowerRiver,
                EastRoomDescription = "Farther East, to your right, you hear the sound of running water.",
                SouthRoom = EastForestUpperClearing,
                SouthRoomDescription = "Behind you is the way back to the moonlit clearing.",
                WestRoom = EastForestCampground,
                WestRoomDescription = "To your left, it looks like there might be a campground."
            };

            EastForestCampground.AvailableExits = new RoomExit
            {
                //NorthRoom = DirtRoadToTown,
                //NorthRoomDescription = "Ahead of you is a dirt road going North that looks like it might go to town.",
                EastRoom = DeepEastForest,
                EastRoomDescription = "To your right is the way back into the Deep East Forest."
            };

            DeepEastForestLowerRiver.AvailableExits = new RoomExit
            {
                NorthRoom = DeepEastForestUpperRiver,
                NorthRoomDescription = "Ahead of you, the riverbank continues North to the upper river.",
                WestRoom = DeepEastForest,
                WestRoomDescription = "To your left is the way back into the Deep East Forest."
            };

            DeepEastForestUpperRiver.AvailableExits = new RoomExit
            {
                NorthRoom = DeepEastForestUpperRiverCave,
                NorthRoomDescription = "It kind of looks like there might be a cave mouth behind the waterfall...",
                SouthRoom = DeepEastForestLowerRiver,
                SouthRoomDescription = "Behind you, to the South, is the lower river."
            };

            DeepEastForestUpperRiverCave.AvailableExits = new RoomExit
            {
                SouthRoom = DeepEastForestUpperRiver,
                SouthRoomDescription = "Behind you is the cave mouth leading back to the upper river."
            };

            TownSouthEntrance.AvailableExits = new RoomExit
            {
                NorthRoom = AshburySouthSquare,
                NorthRoomDescription = "Ahead of you, and to the North, is the gate into South Square.",
                EastRoom = EastForest,
                EastRoomDescription = "To your right, you can make out what seems to be a small pathway leading into the forest to the East.",
                SouthRoom = RoadConnectingYourHouseToTown,
                SouthRoomDescription = "Behind you, and to the South, is the long road back to your house.",
                WestRoom = ForestLake,
                WestRoomDescription = "To your left, you see a sign for the trail to a lake farther West into the forest."
            };

            AshburySouthSquare.AvailableExits = new RoomExit
            {
//                NorthRoom = null,
//                NorthRoomDescription = "Ahead of you, and to the North, is the Town Square.",
//                EastRoom = null,
//                EastRoomDescription = "",
                SouthRoom = TownSouthEntrance,
                SouthRoomDescription = "Behind you, and to the South, is the South Gate exit from town.",
//                WestRoom = null,
//                WestRoomDescription = ""
            };
        }

        // Used to remove the room exits to avoid a circular dependency when serializing
        public void RemoveExitsFromAllRooms()
        {
            YourBedroom.AvailableExits = new RoomExit();

            YourLivingRoom.AvailableExits = new RoomExit();

            YourKitchen.AvailableExits = new RoomExit();

            YourBasement.AvailableExits = new RoomExit();

            YourFrontEntryway.AvailableExits = new RoomExit();

            YourFrontPorch.AvailableExits = new RoomExit();

            YourDriveway.AvailableExits = new RoomExit();

            YourShed.AvailableExits = new RoomExit();

            RoadConnectingYourHouseToTown.AvailableExits = new RoomExit();

            ForestLake.AvailableExits = new RoomExit();

            ForestLakeTent.AvailableExits = new RoomExit();

            EastForest.AvailableExits = new RoomExit();

            EastForestLowerClearing.AvailableExits = new RoomExit();

            EastForestUpperClearing.AvailableExits = new RoomExit();

            DeepEastForest.AvailableExits = new RoomExit();

            DeepEastForestLowerRiver.AvailableExits = new RoomExit();

            DeepEastForestUpperRiver.AvailableExits = new RoomExit();

            DeepEastForestUpperRiverCave.AvailableExits = new RoomExit();

            EastForestCampground.AvailableExits = new RoomExit();

            TownSouthEntrance.AvailableExits = new RoomExit();

            AshburySouthSquare.AvailableExits = new RoomExit();
        }
    }
}