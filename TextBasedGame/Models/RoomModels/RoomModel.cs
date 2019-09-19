using System.Collections.Generic;
using TextBasedGame.Models.ItemModels;

namespace TextBasedGame.Models.RoomModels
{
    public class RoomModel
    {
        public string RoomName { get; set; }

        public string RoomDescription { get; set; }

        public List<RoomExitModel> AvailableExits { get; set; }

        public List<ItemModel> RoomItems { get; set; }
    }
}