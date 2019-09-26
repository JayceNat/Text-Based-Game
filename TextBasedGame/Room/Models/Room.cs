using System.Collections.Generic;
using TextBasedGame.Item.Models;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Room.Models
{
    public class Room
    {
        public string RoomName { get; set; }

        public bool RoomEntered { get; set; } = false;

        public string InitialRoomDescription { get; set; }

        public string GenericRoomDescription { get; set; }

        public string AsExitDescription { get; set; }

        public RoomExit AvailableExits { get; set; }

        public Items RoomItems { get; set; } = new Items();

        public List<string> KeywordsToEnter { get; set; } = new List<string>();

        public AttributeRequirement AttributeRequirementToSee { get; set; } = null;

        public ItemRequirement ItemRequirementToSee { get; set; } = null;

        public AttributeRequirement AttributeRequirementToEnter { get; set; } = null;

        public ItemRequirement ItemRequirementToEnter { get; set; } = null;
    }
}