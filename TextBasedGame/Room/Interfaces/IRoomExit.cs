using TextBasedGame.Constants;
using TextBasedGame.Room.Models;

namespace TextBasedGame.Room.Interfaces
{
    public interface IRoomExit
    {
        RoomExitModel CreateRoomExit(string name, string description, ExitDirections exitDirection);
    }
}