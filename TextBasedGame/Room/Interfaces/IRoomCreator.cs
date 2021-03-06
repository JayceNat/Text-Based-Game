﻿namespace TextBasedGame.Room.Interfaces
{
    public interface IRoomCreator
    {
        // Files to edit when adding a room: GameRooms.cs, RoomCreator.cs, GameSetupHandler.cs
        // Declare all getters for any Rooms you will use here

        // Your House
        Models.Room YourBedroom { get; set; }
        Models.Room YourLivingRoom { get; set; }
        Models.Room YourKitchen { get; set; }
        Models.Room YourFrontEntryway { get; set; }
        Models.Room YourBasement { get; set; }
        Models.Room YourFrontPorch { get; set; }
        Models.Room YourDriveway { get; set; }
        Models.Room YourShed { get; set; }
        Models.Room RoadConnectingYourHouseToTown { get; set; }

        // Forest
        Models.Room ForestLake { get; set; }
        Models.Room ForestLakeTent { get; set; }
        Models.Room EastForest { get; set; }
        Models.Room EastForestLowerClearing { get; set; }
        Models.Room EastForestUpperClearing { get; set; }
        Models.Room DeepEastForest { get; set; }
        Models.Room DeepEastForestLowerRiver { get; set; }
        Models.Room DeepEastForestUpperRiver { get; set; }
        Models.Room DeepEastForestUpperRiverCave { get; set; }
        Models.Room EastForestCampground { get; set; }
        Models.Room PathBetweenCampAndEastRoad { get; set; }
        Models.Room EastRoadToTown { get; set; }

        // Town
        Models.Room TownSouthEntrance { get; set; }
        Models.Room TownNorthEntrance { get; set; }
        Models.Room TownEastEntrance { get; set; }
        Models.Room TownWestEntrance { get; set; }
        Models.Room AshburySouthSquare { get; set; }
        Models.Room AshburyNorthSquare { get; set; }
        Models.Room AshburyEastSquare { get; set; }
        Models.Room AshburyWestSquare { get; set; }
        Models.Room AshburySouthMainStreet { get; set; }
        Models.Room AshburyNorthMainStreet { get; set; }
        Models.Room AshburyEastPlaza { get; set; }
        Models.Room AshburyWestPlaza { get; set; }
        Models.Room AshburyTownCenter { get; set; }
        Models.Room AshburySouthSquareEastAlley { get; set; }
        Models.Room AshburySouthEastVeterinaryClinic { get; set; }
        Models.Room AshburySouthEastCornerLot { get; set; }
        Models.Room AshburySouthEastDurrowHouse { get; set; }
        Models.Room AshburySouthEastAviary { get; set; }
        Models.Room AshburySouthEastWell { get; set; }
        Models.Room AshburySouthSquareWestAlley { get; set; }

        // Helpers to avoid circular dependency during compilation and serialization
        void AddExitsToAllRooms();
        void RemoveExitsFromAllRooms();
    }
}