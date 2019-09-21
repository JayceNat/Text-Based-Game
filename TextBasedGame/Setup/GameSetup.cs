using System.Collections.Generic;
using System.Drawing;
using Colorful;
using TextBasedGame.Character.Models;
using TextBasedGame.Game.Models;

namespace TextBasedGame.Setup
{
    public class GameSetup
    {
        public static void DisplayGameTitle(GameTitleModel gameTitle)
        {
            List<char> chars = new List<char>()
            {
                'P', 'r', 'e', 's', 's', ' ',
                'E', 'n', 't', 'e', 'r', ' ',
                'T', 'o', ' ',
                'C', 'o', 'n', 't', 'i', 'n', 'u', 'e',
                '.', '.', '.', ' '
            };
            FigletFont font = FigletFont.Default;
            Figlet figlet = new Figlet(font);

            Console.ReplaceAllColorsWithDefaults();
            Console.WriteLine(figlet.ToAscii(gameTitle.Title), gameTitle.TitleTextColor);
            Console.WriteLine();
            Console.WriteLine("\t-- Written by " + gameTitle.Author + "--", gameTitle.AuthorTextColor);
            Console.WriteLine("\n\n");
            Console.WriteWithGradient(chars, Color.Yellow, Color.DarkRed, 12);
            Console.ReadLine();
            Console.ReplaceAllColorsWithDefaults();
            Console.Clear();
        }

        public static CharacterModel BeginAdventure(CharacterModel player)
        {
            bool gameFinished = false;

            return player;
        }
    }
}