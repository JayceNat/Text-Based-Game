namespace TextBasedGame.Room.Interfaces
{
    public interface IRoomCreator
    {
        // Declare all getters for any Rooms you will use here
        Models.Room YourBedroom { get; }
        Models.Room YourLivingRoom { get; }
        Models.Room YourKitchen { get; }
        Models.Room YourFrontEntryway { get; }
        Models.Room YourBasement { get; }
        Models.Room YourFrontPorch { get; }
    }
}