using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Colorful;
using TextBasedGame.Character.Models;
using TextBasedGame.Game.Models;
using TextBasedGame.Room;
using TextBasedGame.Room.Models;
using TextBasedGame.Utilities;

namespace TextBasedGame.Setup
{
    public class GameSetup
    {
        public static List<char> continueText = new List<char>()
        {
            'P', 'r', 'e', 's', 's', ' ',
            'E', 'n', 't', 'e', 'r', ' ',
            'T', 'o', ' ',
            'C', 'o', 'n', 't', 'i', 'n', 'u', 'e',
            '.', '.', '.', ' '
        };

        public static List<char> playerInput = new List<char>()
        {
            'W', 'h', 'a', 't', ' ',
            'd', 'o', ' ',
            'y', 'o', 'u', ' ',
            'w', 'a', 'n', 't', ' ',
            't', 'o', ' ',
            'd', 'o', '?'
        };

        public static void DisplayGameTitle(GameTitleModel gameTitle)
        {
            FigletFont font = FigletFont.Default;
            Figlet figlet = new Figlet(font);

            Console.ReplaceAllColorsWithDefaults();
            Console.WriteLine(figlet.ToAscii(gameTitle.Title), gameTitle.TitleTextColor);
            Console.WriteLine();
            Console.WriteLine("\t-- Written by " + gameTitle.Author + "--", gameTitle.AuthorTextColor);
            Console.WriteLine("\n\n");
            Console.WriteWithGradient(continueText, Color.Yellow, Color.DarkRed, 12);
            Console.ReadLine();
            Console.ReplaceAllColorsWithDefaults();
            Console.Clear();
        }

        public static void DisplayGameIntro()
        {
            Console.ReplaceAllColorsWithDefaults();

            string introText = "It was a dark and stormy autumn night... \n";

            TypingAnimation.Animate(introText, Color.DarkTurquoise);
            Console.WriteWithGradient(continueText, Color.Yellow, Color.DarkRed, 12);
            Console.ReadLine();
        }

        public static void EnterRoom(RoomModel room)
        {
            Console.Clear();
            Console.ReplaceAllColorsWithDefaults();
            TypingAnimation.Animate(room.InitialRoomDescription, Color.Bisque, 35);
            Thread.Sleep(50);
            Console.WriteLine();
            Console.WriteWithGradient(playerInput, Color.Yellow, Color.DarkRed, 12);
            Console.WriteLine();
            Console.Write("> ");
        }

        public static CharacterModel BeginAdventure(CharacterModel player)
        {
            bool gameRunning = true;
            while (gameRunning)
            {
                DisplayGameIntro();
                EnterRoom(Rooms.YourBedroom);
                var playerInput = Console.ReadLine();

                gameRunning = false;
            }
            return player;
        }
    }
}