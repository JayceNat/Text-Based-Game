using System;
using System.ComponentModel;
using System.Globalization;

namespace TextBasedGame.Character.SaveGameConverters
{
    public class CharacterConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (!(value is string str)) return base.ConvertFrom(context, culture, value);

            var parts = str.Split(',');
            var character = new Models.Character
            {
                // TODO: Correct this Converter
                Name = parts[0],
                MaximumHealthPoints = Convert.ToInt32(parts[1]),
                HealthPoints = Convert.ToInt32(parts[2]),
                Attributes = null,
                //parts[3] CharacterAttributeConverter.ConvertTo(context, culture, value, typeof(string)),
                CarriedItems = null,
                //parts[4] InventoryItemConverter.ConvertTo(context, culture, value, typeof(string)),
                WeaponItem = null,
                //parts[5] WeaponItemConverter.ConvertTo(context, culture, value, typeof(string)),
                ShowInputHelp = Convert.ToBoolean(parts[6])
            };

            return character;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string)) return base.ConvertTo(context, culture, value, destinationType);

            var character = value as Models.Character;

            return $"{character?.Name},{character?.MaximumHealthPoints}," +
                   $"{character?.HealthPoints},{character?.Attributes}," +
                   $"{character?.CarriedItems},{character?.WeaponItem}," +
                   $"{character?.ShowInputHelp}";
        }
    }
}