namespace TextBasedGame.Room.Interfaces
{
    public interface IRoomCreator
    {
        // Files to edit when adding a room: GameRooms.cs, RoomCreator.cs, GameSetupHandler.cs

        // Declare all getters for any Rooms you will use here
        Models.Room YourBedroom { get; set; }
        Models.Room YourLivingRoom { get; set; }
        Models.Room YourKitchen { get; set; }
        Models.Room YourFrontEntryway { get; set; }
        Models.Room YourBasement { get; set; }
        Models.Room YourFrontPorch { get; set; }
        Models.Room YourDriveway { get; set; }
        Models.Room YourShed { get; set; }
        Models.Room RoadConnectingYourHouseToTown { get; set; }
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
        Models.Room TownSouthEntrance { get; set; }
        Models.Room AshburySouthSquare { get; set; }

        // Helpers to avoid circular dependency during compilation and serialization
        void AddExitsToAllRooms();
        void RemoveExitsFromAllRooms();
    }
}