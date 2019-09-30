using System;
using System.ComponentModel;
using System.Globalization;
using TextBasedGame.Character.Models;

namespace TextBasedGame.Character.SaveGameConverters
{
    public class CharacterAttributeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (!(value is string str)) return base.ConvertFrom(context, culture, value);

            var parts = str.Split(',');
            var characterAttribute = new CharacterAttribute
            {
                AvailablePoints = Convert.ToInt32(parts[0]),
                MaximumCarryingCapacity = Convert.ToInt32(parts[1]),
                CarriedItemsCount = Convert.ToInt32(parts[2]),
                Defense = Convert.ToInt32(parts[3]),
                Dexterity = Convert.ToInt32(parts[4]),
                Luck = Convert.ToInt32(parts[5]),
                Stamina = Convert.ToInt32(parts[6]),
                Strength = Convert.ToInt32(parts[7]),
                Wisdom = Convert.ToInt32(parts[8])
            };

            return characterAttribute;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string)) return base.ConvertTo(context, culture, value, destinationType);

            var characterAttribute = value as CharacterAttribute;

            return $"{characterAttribute?.AvailablePoints},{characterAttribute?.MaximumCarryingCapacity}," +
                   $"{characterAttribute?.CarriedItemsCount},{characterAttribute?.Defense}," +
                   $"{characterAttribute?.Dexterity},{characterAttribute?.Luck}," +
                   $"{characterAttribute?.Stamina},{characterAttribute?.Strength}," +
                   $"{characterAttribute?.Wisdom}";
        }
    }
}