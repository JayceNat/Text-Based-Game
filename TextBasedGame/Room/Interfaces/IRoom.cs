using System.Collections.Generic;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Models;

namespace TextBasedGame.Room.Interfaces
{
    public interface IRoom
    {
        RoomModel CreateRoom(string name, string initialDescription, string genericDescription,
            List<RoomExitModel> availableExits, ItemsModel items);

        RoomModel UpdateRoom(RoomModel room, bool roomEntered = false, string initialDescription = null, string genericDescription = null,
            List<RoomExitModel> availableExits = null, InventoryItemModel itemToAdd = null, InventoryItemModel itemToRemove = null,
            WeaponItemModel weaponToAdd = null, WeaponItemModel weaponToRemove = null);
    }
}