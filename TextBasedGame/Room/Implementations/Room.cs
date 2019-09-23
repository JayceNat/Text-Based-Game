using System.Collections.Generic;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Interfaces;
using TextBasedGame.Room.Models;

namespace TextBasedGame.Room.Implementations
{
    public class Room : IRoom
    {
        public RoomModel CreateRoom(string name, string initialDescription, string genericDescription, List<RoomExitModel> availableExits,
            ItemsModel items)
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

        public RoomModel UpdateRoom(RoomModel room, bool roomEntered = false, string initialDescription = null, string genericDescription = null,
            List<RoomExitModel> availableExits = null, InventoryItemModel itemToAdd = null, InventoryItemModel itemToRemove = null,
            WeaponItemModel weaponToAdd = null, WeaponItemModel weaponToRemove = null)
        {
            room.RoomEntered = roomEntered;

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

            if (itemToAdd != null)
            {
                room.RoomItems.InventoryItems.Add(itemToAdd);
            }

            if (itemToRemove != null)
            {
                room.RoomItems.InventoryItems.Remove(itemToRemove);
            }

            if (weaponToAdd != null)
            {
                room.RoomItems.WeaponItems.Add(weaponToAdd);
            }

            if (weaponToRemove != null)
            {
                room.RoomItems.WeaponItems.Remove(weaponToRemove);
            }

            return room;
        }
    }
}