namespace TextBasedGame.Room.Models
{
    public class RoomExit
    {
        public Room NorthRoom { get; set; }

        public Room EastRoom { get; set; }

        public Room SouthRoom { get; set; }

        public Room WestRoom { get; set; }
    }
}