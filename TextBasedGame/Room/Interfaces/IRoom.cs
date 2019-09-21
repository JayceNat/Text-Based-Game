using System.Collections.Generic;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Models;

namespace TextBasedGame.Room.Interfaces
{
    public interface IRoom
    {
        RoomModel CreateRoom(string name, string initialDescription, string genericDescription,
            List<RoomExitModel> availableExits, ItemsModel itemses);

        RoomModel UpdateRoom(RoomModel room, string initialDescription = null, string genericDescription = null,
            List<RoomExitModel> availableExits = null, ItemsModel itemses = null);
    }
}