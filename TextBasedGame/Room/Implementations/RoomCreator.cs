using TextBasedGame.Room.GameRooms;
using TextBasedGame.Room.Interfaces;
using TextBasedGame.Room.Models;

namespace TextBasedGame.Room.Implementations
{
    public class RoomCreator : IRoomCreator
    {
        // Files to edit when adding a room: GameRooms.cs, RoomCreator.cs, GameSetupHandler.cs
        // Declare all getters for any Rooms you will use here

        // Your House
        public Models.Room YourBedroom { get; set; }
        public Models.Room YourLivingRoom { get; set; }
        public Models.Room YourKitchen { get; set; }
        public Models.Room YourFrontEntryway { get; set; }
        public Models.Room YourBasement { get; set; }
        public Models.Room YourFrontPorch { get; set; }
        public Models.Room YourDriveway { get; set; }
        public Models.Room YourShed { get; set; }
        public Models.Room RoadConnectingYourHouseToTown { get; set; }

        // Forest
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
        public Models.Room PathBetweenCampAndEastRoad { get; set; }
        public Models.Room EastRoadToTown { get; set; }

        // Town
        public Models.Room TownSouthEntrance { get; set; }
        public Models.Room TownNorthEntrance { get; set; }
        public Models.Room TownEastEntrance { get; set; }
        public Models.Room TownWestEntrance { get; set; }
        public Models.Room AshburySouthSquare { get; set; }
        public Models.Room AshburyNorthSquare { get; set; }
        public Models.Room AshburyEastSquare { get; set; }
        public Models.Room AshburyWestSquare { get; set; }
        public Models.Room AshburySouthMainStreet { get; set; }
        public Models.Room AshburyNorthMainStreet { get; set; }
        public Models.Room AshburyEastPlaza { get; set; }
        public Models.Room AshburyWestPlaza { get; set; }
        public Models.Room AshburyTownCenter { get; set; }
        public Models.Room AshburySouthSquareEastAlley { get; set; }
        public Models.Room AshburySouthEastVeterinaryClinic { get; set; }
        public Models.Room AshburySouthEastCornerLot { get; set; }
        public Models.Room AshburySouthEastDurrowHouse { get; set; }
        public Models.Room AshburySouthEastAviary { get; set; }
        public Models.Room AshburySouthEastWell { get; set; }
        public Models.Room AshburySouthSquareWestAlley { get; set; }

        // Constructor: Add the reference to all the Room Objects here
        public RoomCreator()
        {
            // Your House
            YourBedroom = YourHouse.YourBedroom;
            YourLivingRoom = YourHouse.YourLivingRoom;
            YourKitchen = YourHouse.YourKitchen;
            YourFrontEntryway = YourHouse.YourFrontEntryway;
            YourBasement = YourHouse.YourBasement;
            YourFrontPorch = YourHouse.YourFrontPorch;
            YourDriveway = YourHouse.YourDriveway;
            YourShed = YourHouse.YourShed;
            RoadConnectingYourHouseToTown = YourHouse.RoadConnectingYourHouseToTown;

            // Forest
            ForestLake = Forest.ForestLake;
            ForestLakeTent = Forest.ForestLakeTent;
            EastForest = Forest.EastForest;
            EastForestLowerClearing = Forest.EastForestLowerClearing;
            EastForestUpperClearing = Forest.EastForestUpperClearing;
            DeepEastForest = Forest.DeepEastForest;
            DeepEastForestLowerRiver = Forest.DeepEastForestLowerRiver;
            DeepEastForestUpperRiver = Forest.DeepEastForestUpperRiver;
            DeepEastForestUpperRiverCave = Forest.DeepEastForestUpperRiverCave;
            EastForestCampground = Forest.EastForestCampground;
            PathBetweenCampAndEastRoad = Forest.PathBetweenCampAndEastRoad;
            EastRoadToTown = Forest.EastRoadToTown;

            // Town
            TownSouthEntrance = Town.TownSouthEntrance;
            TownNorthEntrance = Town.TownNorthEntrance;
            TownEastEntrance = Town.TownEastEntrance;
            TownWestEntrance = Town.TownWestEntrance;
            AshburySouthSquare = Town.AshburySouthSquare;
            AshburyNorthSquare = Town.AshburyNorthSquare;
            AshburyEastSquare = Town.AshburyEastSquare;
            AshburyWestSquare = Town.AshburyWestSquare;
            AshburySouthMainStreet = Town.AshburySouthMainStreet;
            AshburyNorthMainStreet = Town.AshburyNorthMainStreet;
            AshburyEastPlaza = Town.AshburyEastPlaza;
            AshburyWestPlaza = Town.AshburyWestPlaza;
            AshburyTownCenter = Town.AshburyTownCenter;
            AshburySouthSquareEastAlley = Town.AshburySouthSquareEastAlley;
            AshburySouthEastVeterinaryClinic = Town.AshburySouthEastVeterinaryClinic;
            AshburySouthEastCornerLot = Town.AshburySouthEastCornerLot;
            AshburySouthEastDurrowHouse = Town.AshburySouthEastDurrowHouse;
            AshburySouthEastAviary = Town.AshburySouthEastAviary;
            AshburySouthEastWell = Town.AshburySouthEastWell;
            AshburySouthSquareWestAlley = Town.AshburySouthSquareWestAlley;

            AddExitsToAllRooms();
        }

        // Used to add the Room references to Room Objects as the Exit Property
        public void AddExitsToAllRooms()
        {
            //*******************************************************************************************
            // Your House
            //*******************************************************************************************
            #region Your House

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

            #endregion

            //*******************************************************************************************
            // Forest
            //*******************************************************************************************
            #region Forest

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
                NorthRoom = PathBetweenCampAndEastRoad,
                NorthRoomDescription = "Ahead of you is a well walked dirt path going North that looks like it might go to town.\n" +
                                       "It gets really foggy that way.",
                EastRoom = DeepEastForest,
                EastRoomDescription = "To your right is the way back into the Deep East Forest."
            };

            PathBetweenCampAndEastRoad.AvailableExits = new RoomExit
            {
                NorthRoom = EastRoadToTown,
                NorthRoomDescription = "The fog makes it hard to tell, but you think going North should get you closer to town.",
                SouthRoom = EastForestCampground,
                SouthRoomDescription = "The path South from where you came leads to the East Forest Campground."
            };

            EastRoadToTown.AvailableExits = new RoomExit
            {
                SouthRoom = PathBetweenCampAndEastRoad,
                SouthRoomDescription = "To the South you can just make out the dirt path towards the Campground",
                WestRoom = TownEastEntrance,
                WestRoomDescription = "Following this road West should lead you to town..."
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

            #endregion

            //*******************************************************************************************
            // Town
            //*******************************************************************************************
            #region Town

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

            TownNorthEntrance.AvailableExits = new RoomExit
            {
                //NorthRoom = RoadBetweenHenrysHouseAndTown,
                //NorthRoomDescription = "To the North, the road away from town serpentines into the cold darkness...",
                SouthRoom = AshburyNorthSquare,
                SouthRoomDescription = "Behind you is the North Gate entrance into Ashbury."
            };

            TownEastEntrance.AvailableExits = new RoomExit
            {
                EastRoom = EastRoadToTown,
                EastRoomDescription = "To the East, the road away from town drops into fog going towards the East Forest...",
                WestRoom = AshburyEastSquare,
                WestRoomDescription = "To the West is the East Gate entrance into Ashbury."
            };

            TownWestEntrance.AvailableExits = new RoomExit
            {
                EastRoom = AshburyWestSquare,
                EastRoomDescription = "To the East is the West Gate entrance into Ashbury.",
                //WestRoom = RoadIntoWestForest,
                //WestRoomDescription = "To the West is the crumbling road into the West Forest."
            };

            AshburySouthSquare.AvailableExits = new RoomExit
            {
                NorthRoom = AshburySouthMainStreet,
                NorthRoomDescription = "Ahead of you, and to the North, is the metal alley door to South Main Street.",
                EastRoom = AshburySouthSquareEastAlley,
                EastRoomDescription = "To your right is an alley going East.",
                SouthRoom = TownSouthEntrance,
                SouthRoomDescription = "Behind you, and to the South, is the South Gate exit from town.",
                WestRoom = AshburySouthSquareWestAlley,
                WestRoomDescription = "To your left is an alley going West."
            };

            AshburyNorthSquare.AvailableExits = new RoomExit
            {
                NorthRoom = TownNorthEntrance,
                NorthRoomDescription = "Ahead of you, and to the North, is the North Gate going out of town.",
                //                EastRoom = null,
                //                EastRoomDescription = "",
                SouthRoom = AshburyNorthMainStreet,
                SouthRoomDescription = "Behind you, and to the South, is North Main Street.",
                //                WestRoom = null,
                //                WestRoomDescription = ""
            };

            AshburyEastSquare.AvailableExits = new RoomExit
            {
                EastRoom = TownEastEntrance,
                EastRoomDescription = "To your right (East) is the East Gate going out of town.",
                WestRoom = AshburyEastPlaza,
                WestRoomDescription = "To your left (West) is the Ashbury East Plaza."
            };

            AshburyWestSquare.AvailableExits = new RoomExit
            {
                EastRoom = AshburyWestPlaza,
                EastRoomDescription = "To your right (East) is the Ashbury West Plaza.",
                WestRoom = TownWestEntrance,
                WestRoomDescription = "To your left (West) is the West Gate going out of town."
            };

            AshburySouthMainStreet.AvailableExits = new RoomExit
            {
                NorthRoom = AshburyTownCenter,
                NorthRoomDescription = "To the North is the Ashbury Town Center.",
                SouthRoom = AshburySouthSquare,
                SouthRoomDescription = "To the South is the South Square of Ashbury."
            };

            AshburyNorthMainStreet.AvailableExits = new RoomExit
            {
                NorthRoom = AshburyNorthSquare,
                NorthRoomDescription = "To the North is the North Square of Ashbury.",
                SouthRoom = AshburyTownCenter,
                SouthRoomDescription = "To the South is the Ashbury Town Center."
            };

            AshburyEastPlaza.AvailableExits = new RoomExit
            {
//                NorthRoom = null,
//                NorthRoomDescription = null,
                EastRoom = AshburyEastSquare,
                EastRoomDescription = "To the East is the East Square of Ashbury.",
//                SouthRoom = null,
//                SouthRoomDescription = null,
                WestRoom = AshburyTownCenter,
                WestRoomDescription = "To the West is Ashbury Town Center."
            };

            AshburyWestPlaza.AvailableExits = new RoomExit
            {
//                NorthRoom = null,
//                NorthRoomDescription = null,
                EastRoom = AshburyTownCenter,
                EastRoomDescription = "To the East is Ashbury Town Center.",
//                SouthRoom = null,
//                SouthRoomDescription = null,
                WestRoom = AshburyWestSquare,
                WestRoomDescription = "To the West is the West Square of Ashbury."
            };

            AshburyTownCenter.AvailableExits = new RoomExit
            {
                NorthRoom = AshburyNorthMainStreet,
                NorthRoomDescription = "To the North is North Main Street.",
                EastRoom = AshburyEastPlaza,
                EastRoomDescription = "To the East is the East Plaza.",
                SouthRoom = AshburySouthMainStreet,
                SouthRoomDescription = "To the South is South Main Street.",
                WestRoom = AshburyWestPlaza,
                WestRoomDescription = "To the West is the West Plaza."
            };

            AshburySouthSquareEastAlley.AvailableExits = new RoomExit
            {
                NorthRoom = AshburySouthEastVeterinaryClinic,
                NorthRoomDescription = "To the North is a back door into the old Ashbury Veterinary Clinic.",
                EastRoom = AshburySouthEastCornerLot,
                EastRoomDescription = "To the East is a small walkway leading to an open lot.",
                WestRoom = AshburySouthSquare,
                WestRoomDescription = "To the West is the South Square of Ashbury."
            };

            AshburySouthEastVeterinaryClinic.AvailableExits = new RoomExit
            {
                //NorthRoom = null,
                //NorthRoomDescription = null,
                SouthRoom = AshburySouthSquareEastAlley,
                SouthRoomDescription = "Behind you is the door back out into the SouthEast alley."
            };

            AshburySouthEastCornerLot.AvailableExits = new RoomExit
            {
                NorthRoom = AshburySouthEastDurrowHouse,
                NorthRoomDescription = "To the North is the front door of the Durrow's house.",
                EastRoom = AshburySouthEastAviary,
                EastRoomDescription = "To the East is the entrance into a large, empty aviary.",
                SouthRoom = AshburySouthEastWell,
                SouthRoomDescription = "To the South is a stone well.",
                WestRoom = AshburySouthSquareEastAlley,
                WestRoomDescription = "To the West is the alley leading back to the South Square."
            };

            AshburySouthEastDurrowHouse.AvailableExits = new RoomExit
            {
                SouthRoom = AshburySouthEastCornerLot,
                SouthRoomDescription = "Behind you is the front door back to the open lot."
            };

            AshburySouthEastAviary.AvailableExits = new RoomExit
            {
                WestRoom = AshburySouthEastCornerLot,
                WestRoomDescription = "To the West is the aviary door back to the open lot."
            };

            AshburySouthEastWell.AvailableExits = new RoomExit
            {
                NorthRoom = AshburySouthEastCornerLot,
                NorthRoomDescription = "To the North is the open lot."
            };

            AshburySouthSquareWestAlley.AvailableExits = new RoomExit
            {
//                NorthRoom = null,
//                NorthRoomDescription = null,
                EastRoom = AshburySouthSquare,
                EastRoomDescription = "Back to the East is the South Square of Ashbury.",
//                SouthRoom = null,
//                SouthRoomDescription = null,
//                WestRoom = null,
//                WestRoomDescription = null
            };

            #endregion
        }

        // Used to remove the room exits to avoid a circular dependency when serializing
        public void RemoveExitsFromAllRooms()
        {
            // Your House
            YourBedroom.AvailableExits = new RoomExit();
            YourLivingRoom.AvailableExits = new RoomExit();
            YourKitchen.AvailableExits = new RoomExit();
            YourBasement.AvailableExits = new RoomExit();
            YourFrontEntryway.AvailableExits = new RoomExit();
            YourFrontPorch.AvailableExits = new RoomExit();
            YourDriveway.AvailableExits = new RoomExit();
            YourShed.AvailableExits = new RoomExit();
            RoadConnectingYourHouseToTown.AvailableExits = new RoomExit();

            // Forest
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
            PathBetweenCampAndEastRoad.AvailableExits = new RoomExit();
            EastRoadToTown.AvailableExits = new RoomExit();

            // Town
            TownSouthEntrance.AvailableExits = new RoomExit();
            TownNorthEntrance.AvailableExits = new RoomExit();
            TownEastEntrance.AvailableExits = new RoomExit();
            TownWestEntrance.AvailableExits = new RoomExit();
            AshburySouthSquare.AvailableExits = new RoomExit();
            AshburyNorthSquare.AvailableExits = new RoomExit();
            AshburyEastSquare.AvailableExits = new RoomExit();
            AshburyWestSquare.AvailableExits = new RoomExit();
            AshburySouthMainStreet.AvailableExits = new RoomExit();
            AshburyNorthMainStreet.AvailableExits = new RoomExit();
            AshburyEastPlaza.AvailableExits = new RoomExit();
            AshburyWestPlaza.AvailableExits = new RoomExit();
            AshburyTownCenter.AvailableExits = new RoomExit();
            AshburySouthSquareEastAlley.AvailableExits = new RoomExit();
            AshburySouthEastVeterinaryClinic.AvailableExits = new RoomExit();
            AshburySouthEastCornerLot.AvailableExits = new RoomExit();
            AshburySouthEastDurrowHouse.AvailableExits = new RoomExit();
            AshburySouthEastAviary.AvailableExits = new RoomExit();
            AshburySouthEastWell.AvailableExits = new RoomExit();
            AshburySouthSquareWestAlley.AvailableExits = new RoomExit();
        }
    }
}