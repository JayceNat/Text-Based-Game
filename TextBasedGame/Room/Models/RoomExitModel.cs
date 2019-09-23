using TextBasedGame.Shared.Models;

namespace TextBasedGame.Room.Models
{
    public class RoomExitModel
    {
        public string ExitName { get; set; }

        public string ExitDescription { get; set; }

        public string ExitDirection { get; set; }

        public RoomModel ConnectedRoom { get; set; }

        public bool ViewExitHasAttributeRequirement { get; set; }

        public bool ViewExitHasItemRequirement { get; set; }

        public bool EnterExitHasAttributeRequirement { get; set; }

        public bool EnterExitHasItemRequirement { get; set; }

        public AttributeRequirementModel ExitVisibilityAttributeRequirement { get; set; }

        public ItemRequirementModel VisibilityItemRequirement { get; set; }

        public AttributeRequirementModel ExitEntranceAttributeRequirement { get; set; }

        public ItemRequirementModel EntranceItemRequirement { get; set; }
    }
}