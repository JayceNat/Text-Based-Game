using TextBasedGame.Constants;
using TextBasedGame.Room.Interfaces;
using TextBasedGame.Room.Models;

namespace TextBasedGame.Room
{
    public class RoomExits
    {
        private static readonly IRoomExit RoomExit = new Implementations.RoomExit();

        public static RoomExitModel YourLivingRoom = RoomExit.CreateRoomExit(
            "Your Living Room",
            "Behind you is the doorway leading to your living room.",
            ExitDirections.Behind,
            Rooms.YourLivingRoom);
    }
}