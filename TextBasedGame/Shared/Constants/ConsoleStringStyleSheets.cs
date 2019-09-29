using System.Drawing;
using Colorful;

namespace TextBasedGame.Shared.Constants
{
    public class ConsoleStringStyleSheets
    {
        public static StyleSheet GameHelpStyleSheet(Color defaultColor)
        {
            var gameHelpStyle = new StyleSheet(defaultColor);
            gameHelpStyle.AddStyle("items[a-z]*", Color.Aquamarine);
            gameHelpStyle.AddStyle("weapons[a-z]*", Color.Aquamarine);
            gameHelpStyle.AddStyle("take[a-z]*", Color.ForestGreen);
            gameHelpStyle.AddStyle("drop[a-z]*", Color.ForestGreen);
            gameHelpStyle.AddStyle("exits[a-z]*", Color.Red);
            gameHelpStyle.AddStyle("enter[a-z]*", Color.Red);
            gameHelpStyle.AddStyle("inventory[a-z]*", Color.OliveDrab);
            gameHelpStyle.AddStyle("inv[a-z]*", Color.OliveDrab);
            gameHelpStyle.AddStyle("status[a-z]*", Color.OliveDrab);
            gameHelpStyle.AddStyle("stat[a-z]*", Color.OliveDrab);
            gameHelpStyle.AddStyle("use[a-z]*", Color.Gold);

            return gameHelpStyle;
        }
    }
}