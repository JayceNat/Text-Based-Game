using System;
using System.Collections.Generic;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Interfaces;
using TextBasedGame.Room.Models;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Room.Implementations
{
    public class RoomCreator : IRoomCreator
    {
        public Models.Room YourBedroom { get; }

        public Models.Room YourLivingRoom { get; }

        public RoomCreator()
        {
            YourBedroom = Rooms.YourBedroom;
            YourLivingRoom = Rooms.YourLivingRoom;

            AddExitsToAllRooms();
        }

        public Models.Room UpdateRoom(Models.Room room, bool roomEntered = false, string initialDescription = null, string genericDescription = null,
            string exitDescription = null, RoomExit availableExits = null, InventoryItem itemToAdd = null, InventoryItem itemToRemove = null,
            WeaponItem weaponToAdd = null, WeaponItem weaponToRemove = null, List<string> keywordsToEnter = null,
            AttributeRequirement attributeRequirementToSee = null, ItemRequirement itemRequirementToSee = null,
            AttributeRequirement attributeRequirementToEnter = null, ItemRequirement itemRequirementToEnter = null)
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
                if (room?.RoomItems?.InventoryItems != null)
                {
                    room.RoomItems.InventoryItems.Add(itemToAdd);
                }
                else
                {
                    room.RoomItems.InventoryItems = new List<InventoryItem>()
                    {
                        itemToAdd
                    };
                }
            }

            if (itemToRemove != null)
            {
                room?.RoomItems?.InventoryItems?.Remove(itemToRemove);
            }

            if (weaponToAdd != null)
            {
                if (room?.RoomItems?.WeaponItems != null)
                {
                    room.RoomItems.WeaponItems.Add(weaponToAdd);
                }
                else
                {
                    room.RoomItems.WeaponItems = new List<WeaponItem>()
                    {
                        weaponToAdd
                    };
                }
            }

            if (weaponToRemove != null)
            {
                room?.RoomItems?.WeaponItems?.Remove(weaponToRemove);
            }

            if (keywordsToEnter != null)
            {
                room.KeywordsToEnter = keywordsToEnter;
            }

            if (attributeRequirementToSee != null)
            {
                room.AttributeRequirementToSee = attributeRequirementToSee;
            }

            if (itemRequirementToSee != null)
            {
                room.ItemRequirementToSee = itemRequirementToSee;
            }

            if (attributeRequirementToEnter != null)
            {
                room.AttributeRequirementToEnter = attributeRequirementToEnter;
            }

            if (itemRequirementToEnter != null)
            {
                room.ItemRequirementToEnter = itemRequirementToEnter;
            }

            return room;
        }

        private void AddExitsToAllRooms()
        {
            UpdateRoom(YourBedroom, availableExits: new RoomExit() { NorthRoom = YourLivingRoom });
            UpdateRoom(YourLivingRoom, availableExits: new RoomExit() { SouthRoom = YourBedroom });
        }
    }
}