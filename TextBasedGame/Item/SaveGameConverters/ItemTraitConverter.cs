using System;
using System.ComponentModel;
using System.Globalization;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.SaveGameConverters
{
    public class ItemTraitConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (!(value is string str)) return base.ConvertFrom(context, culture, value);

            var parts = str.Split(',');
            var itemTrait = new ItemTrait
            {
                TraitName = parts[0],
                RelevantCharacterAttribute = parts[1],
                TraitValue = Convert.ToInt32(parts[2])
            };

            return itemTrait;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string)) return base.ConvertTo(context, culture, value, destinationType);

            var itemTrait = value as ItemTrait;

            return $"{itemTrait?.TraitName},{itemTrait?.RelevantCharacterAttribute}," +
                   $"{itemTrait?.TraitValue}";
        }
    }
}