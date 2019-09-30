using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using TextBasedGame.Game.SaveGameConverters;

namespace TextBasedGame.Game.Models
{
    [TypeConverter(typeof(GameTitleConverter))]
    [SettingsSerializeAs(SettingsSerializeAs.String)]
    public class GameTitle
    {
        public string Title { get; set; }

        public Color TitleTextColor { get; set; }

        public string Author { get; set; }

        public Color AuthorTextColor { get; set; }
    }
}