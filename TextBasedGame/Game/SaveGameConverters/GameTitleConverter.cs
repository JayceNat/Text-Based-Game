using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using TextBasedGame.Game.Models;

namespace TextBasedGame.Game.SaveGameConverters
{
    public class GameTitleConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (!(value is string str)) return base.ConvertFrom(context, culture, value);

            var parts = str.Split(',');
            var gameTitle = new GameTitle
            {
                // TODO: Fix this converter
                Title = parts[0],
                TitleTextColor = new Color(),
                //.ToKnownColor(parts[1]),
                Author = parts[2],
                AuthorTextColor = new Color()
                //parts[3]
            };

            return gameTitle;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string)) return base.ConvertTo(context, culture, value, destinationType);

            var gameTitle = value as GameTitle;

            return $"{gameTitle?.Title},{gameTitle?.TitleTextColor}," +
                   $"{gameTitle?.Author},{gameTitle?.AuthorTextColor}";
        }
    }
}