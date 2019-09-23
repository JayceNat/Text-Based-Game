using TextBasedGame.Room.Interfaces;
using TextBasedGame.Room.Models;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Room.Implementations
{
    public class RoomExit : IRoomExit
    {
        public RoomExitModel CreateRoomExit(string name, string description, string exitDirection, RoomModel connectedRoom,
            bool hasAttrRequirementToView = false, bool hasItemRequirementToView = false, bool hasAttrRequirementToEnter = false,
            bool hasItemRequirementToEnter = false, AttributeRequirementModel attrRequirementToView = null,
            ItemRequirementModel itemRequirementToView = null, AttributeRequirementModel attrRequirementToEnter = null,
            ItemRequirementModel itemRequirementToEnter = null)
        {
            RoomExitModel roomExit = new RoomExitModel()
            {
                ExitName = name,
                ExitDescription = description,
                ExitDirection = exitDirection,
                ConnectedRoom = connectedRoom,
                ViewExitHasAttributeRequirement = hasAttrRequirementToView,
                ViewExitHasItemRequirement = hasItemRequirementToView,
                EnterExitHasAttributeRequirement = hasAttrRequirementToEnter,
                EnterExitHasItemRequirement = hasItemRequirementToEnter,
                ExitVisibilityAttributeRequirement = attrRequirementToView,
                VisibilityItemRequirement = itemRequirementToView,
                ExitEntranceAttributeRequirement = attrRequirementToEnter,
                EntranceItemRequirement = itemRequirementToEnter
            };

            return roomExit;
        }
    }
}