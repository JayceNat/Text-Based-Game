﻿using System.Drawing;
using Colorful;
using TextBasedGame.Game.Models;
using TextBasedGame.Room.Handlers;
using TextBasedGame.Room.Interfaces;
using TextBasedGame.Shared.Constants;
using TextBasedGame.Shared.Utilities;

namespace TextBasedGame.Game.Setup
{
    public class GameSetup
    {
        private static readonly IRoomCreator RoomCreator = new Room.Implementations.RoomCreator();

        public static void DisplayGameTitle(GameTitle gameTitle)
        {
            var font = FigletFont.Default;
            var figlet = new Figlet(font);

            Console.ReplaceAllColorsWithDefaults();
            Console.WriteLine(figlet.ToAscii(gameTitle.Title), gameTitle.TitleTextColor);
            Console.WriteLine();
            Console.WriteLine("\t-- Written by " + gameTitle.Author + "--", gameTitle.AuthorTextColor);
            Console.WriteLine("\n\n");
            Console.WriteWithGradient(ConsoleStrings.PressEnterPrompt, Color.Yellow, Color.DarkRed, 4);
            Console.ReadLine();
            Console.ReplaceAllColorsWithDefaults();
            Console.Clear();
        }

        public static void DisplayGameIntro()
        {
            Console.ReplaceAllColorsWithDefaults();

            TypingAnimation.Animate(ConsoleStrings.GameIntro, Color.DarkTurquoise);
            Console.WriteWithGradient(ConsoleStrings.PressEnterPrompt, Color.Yellow, Color.DarkRed, 4);
            Console.ReadLine();
        }

        public static Character.Models.Character BeginAdventure(Character.Models.Character player, Room.Models.Room room)
        {
            DisplayGameIntro();
            return TheAdventure(player, room, true);
        }

        private static Character.Models.Character TheAdventure(Character.Models.Character player, Room.Models.Room room, bool firstRoomEntered)
        {
            var firstRoom = firstRoomEntered;
            var currentRoom = room;
            while (true)
            {
                currentRoom = RoomHandler.EnterRoom(player, currentRoom, firstRoom);
                firstRoom = false;
                if (currentRoom == null)
                {
                    break;
                }
            }

            return player;
        }
    }
}