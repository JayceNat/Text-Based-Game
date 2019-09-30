using System;
using System.ComponentModel;
using System.Globalization;

namespace TextBasedGame.Room.SaveGameConverters
{
    public class RoomConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (!(value is string str)) return base.ConvertFrom(context, culture, value);

            var parts = str.Split(',');
            var room = new Models.Room
            {
                // TODO: Fix this converter
                RoomName = null,
                RoomEntered = false,
                InitialRoomDescription = null,
                GenericRoomDescription = null,
                AsExitDescription = null,
                AvailableExits = null,
                RoomItems = null,
                KeywordsToEnter = null,
                AttributeRequirementToSee = null,
                ItemRequirementToSee = null,
                AttributeRequirementToEnter = null,
                ItemRequirementToEnter = null
            };

            return room;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string)) return base.ConvertTo(context, culture, value, destinationType);

            var room = value as Models.Room;

            return $"{room?.RoomName},{room?.RoomEntered}," +
                   $"{room?.InitialRoomDescription},{room?.GenericRoomDescription}," +
                   $"{room?.AsExitDescription},{room?.AvailableExits}," +
                   $"{room?.RoomItems},{room?.KeywordsToEnter}," +
                   $"{room?.AttributeRequirementToSee},{room?.ItemRequirementToSee}," +
                   $"{room?.AttributeRequirementToEnter},{room?.ItemRequirementToEnter}";
        }
    }
}