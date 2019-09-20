﻿using TextBasedGame.Constants;

namespace TextBasedGame.Room.Models
{
    public class RoomExitModel
    {
        public string ExitName { get; set; }

        public string ExitDescription { get; set; }

        public ExitDirections ExitExitDirection { get; set; }
    }
}