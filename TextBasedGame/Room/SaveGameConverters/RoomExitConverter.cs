using System;
using System.ComponentModel;
using System.Globalization;

namespace TextBasedGame.Room.SaveGameConverters
{
    public class RoomExitConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (!(value is string str)) return base.ConvertFrom(context, culture, value);

            var parts = str.Split(',');
            var roomExit = new Models.RoomExit
            {
                // TODO: Fix this converter
                NorthRoom = null,
                NorthRoomDescription = null,
                EastRoom = null,
                EastRoomDescription = null,
                SouthRoom = null,
                SouthRoomDescription = null,
                WestRoom = null,
                WestRoomDescription = null
            };

            return roomExit;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string)) return base.ConvertTo(context, culture, value, destinationType);

            var roomExit = value as Models.RoomExit;

            return $"{roomExit?.NorthRoom},{roomExit?.NorthRoomDescription}," +
                   $"{roomExit?.EastRoom},{roomExit?.EastRoomDescription}," +
                   $"{roomExit?.SouthRoom},{roomExit?.SouthRoomDescription}," +
                   $"{roomExit?.WestRoom},{roomExit?.WestRoomDescription},";
        }
    }
}