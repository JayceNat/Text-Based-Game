using TextBasedGame.Room.Interfaces;
using TextBasedGame.Room.Models;

namespace TextBasedGame.Room.Implementations
{
    public class RoomExit : IRoomExit
    {
        public RoomExitModel CreateRoomExit(string name, string description, string exitDirection, RoomModel connectedRoom)
        {
            RoomExitModel roomExit = new RoomExitModel()
            {
                ExitName = name,
                ExitDescription = description,
                ExitDirection = exitDirection,
                ConnectedRoom = connectedRoom
            };

            return roomExit;
        }
    }
}