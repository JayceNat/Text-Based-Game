using System.Drawing;
using Colorful;
using TextBasedGame.Character.Models;
using TextBasedGame.Constants;
using TextBasedGame.Game.Models;
using TextBasedGame.Handlers;
using TextBasedGame.Room.Interfaces;
using TextBasedGame.Room.Models;
using TextBasedGame.Utilities;

namespace TextBasedGame.Setup
{
    public class GameSetup
    {
        private static readonly IRoom Room = new Room.Implementations.Room();

        public static void DisplayGameTitle(GameTitleModel gameTitle)
        {
            FigletFont font = FigletFont.Default;
            Figlet figlet = new Figlet(font);

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

            string introText = "It was a dark and stormy night... \n";

            TypingAnimation.Animate(introText, Color.DarkTurquoise);
            Console.WriteWithGradient(ConsoleStrings.PressEnterPrompt, Color.Yellow, Color.DarkRed, 4);
            Console.ReadLine();
        }

        public static CharacterModel BeginAdventure(CharacterModel player, RoomModel room)
        {
            DisplayGameIntro();
            return TheAdventure(player, room);
        }

        private static CharacterModel TheAdventure(CharacterModel player, RoomModel room)
        {
            RoomModel currentRoom = room;
            while (true)
            {
                currentRoom = RoomActionHandler.EnterRoom(player, currentRoom);

                if (currentRoom == null)
                {
                    break;
                }
                if (!room.RoomEntered)
                {
                    Room.UpdateRoom(currentRoom, true);
                }
            }

            return player;
        }
    }
}