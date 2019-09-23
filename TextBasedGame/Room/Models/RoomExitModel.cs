namespace TextBasedGame.Room.Models
{
    public class RoomExitModel
    {
        public string ExitName { get; set; }

        public string ExitDescription { get; set; }

        public string ExitDirection { get; set; }

        public RoomModel ConnectedRoom { get; set; }
    }
}