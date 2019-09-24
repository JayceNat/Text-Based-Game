using System.Collections.Generic;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Models;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Room.Interfaces
{
    public interface IRoomCreator
    {
        Models.Room YourBedroom { get; }

        Models.Room YourLivingRoom { get; }

        Models.Room UpdateRoom(Models.Room room, bool roomEntered = false, string initialDescription = null, string genericDescription = null,
            string exitDescription = null, RoomExit availableExits = null, InventoryItem itemToAdd = null, InventoryItem itemToRemove = null,
            WeaponItem weaponToAdd = null, WeaponItem weaponToRemove = null, List<string> keywordsToEnter = null,
            AttributeRequirement attributeRequirementToSee = null, ItemRequirement itemRequirementToSee = null,
            AttributeRequirement attributeRequirementToEnter = null, ItemRequirement itemRequirementToEnter = null);
    }
}