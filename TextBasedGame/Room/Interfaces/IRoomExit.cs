using TextBasedGame.Room.Models;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Room.Interfaces
{
    public interface IRoomExit
    {
        RoomExitModel CreateRoomExit(string name, string description, string exitDirection, RoomModel connectedRoom,
            bool hasAttrRequirementToView = false, bool hasItemRequirementToView = false, bool hasAttrRequirementToEnter = false,
            bool hasItemRequirementToEnter = false, AttributeRequirementModel attrRequirementToView = null, 
            ItemRequirementModel itemRequirementToView = null, AttributeRequirementModel attrRequirementToEnter = null,
            ItemRequirementModel itemRequirementToEnter = null);
    }
}