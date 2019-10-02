namespace TextBasedGame.Room.Interfaces
{
    public interface IRoomCreator
    {
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

        // Helpers to avoid circular dependency during compilation and serialization
        void AddExitsToAllRooms();
        void RemoveExitsFromAllRooms();
    }
}