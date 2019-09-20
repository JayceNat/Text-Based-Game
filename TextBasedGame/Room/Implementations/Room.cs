using System.Collections.Generic;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Interfaces;
using TextBasedGame.Room.Models;

namespace TextBasedGame.Room.Implementations
{
    public class Room : IRoom
    {
        public RoomModel CreateRoom(string name, string initialDescription, string genericDescription, List<RoomExitModel> availableExits,
            List<ItemModel> items)
        {
            RoomModel room = new RoomModel()
            {
                RoomName = name,
                InitialRoomDescription = initialDescription,
                GenericRoomDescription = genericDescription,
                AvailableExits = availableExits,
                RoomItems = items
            };

            return room;
        }

        public RoomModel UpdateRoom(RoomModel room, string initialDescription = null, string genericDescription = null,
            List<RoomExitModel> availableExits = null, List<ItemModel> items = null)
        {
            if (initialDescription != null)
            {
                room.InitialRoomDescription = initialDescription;
            }

            if (genericDescription != null)
            {
                room.GenericRoomDescription = genericDescription;
            }

            if (availableExits != null)
            {
                room.AvailableExits = availableExits;
            }

            if (items != null)
            {
                room.RoomItems = items;
            }

            return room;
        }
    }
}