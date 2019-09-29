using System.Drawing;
using Colorful;

namespace TextBasedGame.Room.Constants
{
    public class RoomStyleSheets
    {
        public static StyleSheet InputHelperStyleSheet()
        {
            var inputHelperStyle = new StyleSheet(Color.Gray);
            inputHelperStyle.AddStyle("items[a-z]*", Color.CadetBlue);
            inputHelperStyle.AddStyle("weapons[a-z]*", Color.CadetBlue);
            inputHelperStyle.AddStyle("exits[a-z]*", Color.DarkRed);
            inputHelperStyle.AddStyle("inv[a-z]*", Color.DarkOliveGreen);
            inputHelperStyle.AddStyle("stat[a-z]*", Color.DarkOliveGreen);
            inputHelperStyle.AddStyle("use[a-z]*", Color.DarkGoldenrod);

            return inputHelperStyle;
        }
    }
}