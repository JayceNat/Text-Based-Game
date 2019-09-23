using System.Collections.Generic;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Room.Models
{
    public class RoomModel
    {
        public string RoomName { get; set; }

        public bool RoomEntered { get; set; } = false;

        public string InitialRoomDescription { get; set; }

        public string GenericRoomDescription { get; set; }

        public List<RoomExitModel> AvailableExits { get; set; }

        public ItemsModel RoomItems { get; set; }
    }
}