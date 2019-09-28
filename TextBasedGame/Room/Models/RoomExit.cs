namespace TextBasedGame.Room.Models
{
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