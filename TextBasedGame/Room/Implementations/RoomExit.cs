using TextBasedGame.Constants;
using TextBasedGame.Room.Interfaces;
using TextBasedGame.Room.Models;

namespace TextBasedGame.Room.Implementations
{
    public class RoomExit : IRoomExit
    {
        public RoomExitModel CreateRoomExit(string name, string description, string exitDirection)
        {
            RoomExitModel roomExit = new RoomExitModel()
            {
                ExitName = name,
                ExitDescription = description,
                ExitExitDirection = exitDirection
            };

            return roomExit;
        }
    }
}