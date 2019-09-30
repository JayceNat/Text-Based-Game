using System.ComponentModel;
using System.Configuration;
using TextBasedGame.Room.SaveGameConverters;

namespace TextBasedGame.Room.Models
{
    [TypeConverter(typeof(RoomExitConverter))]
    [SettingsSerializeAs(SettingsSerializeAs.String)]
    public class RoomExit
    {
        public Room NorthRoom { get; set; }
        public string NorthRoomDescription { get; set; }

        public Room EastRoom { get; set; }
        public string EastRoomDescription { get; set; }

        public Room SouthRoom { get; set; }
        public string SouthRoomDescription { get; set; }

        public Room WestRoom { get; set; }
        public string WestRoomDescription { get; set; }
    }
}