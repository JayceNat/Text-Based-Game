using System;
using System.ComponentModel;
using System.Globalization;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Shared.SaveGameConverters
{
    public class ItemRequirementConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (!(value is string str)) return base.ConvertFrom(context, culture, value);

            var parts = str.Split(',');
            var itemRequirement = new ItemRequirement
            {
                // TODO: Fix this converter
                RequirementName = parts[0],
                RelevantItem = null
            };

            return itemRequirement;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string)) return base.ConvertTo(context, culture, value, destinationType);

            var itemRequirement = value as ItemRequirement;

            return $"{itemRequirement?.RequirementName},{itemRequirement?.RelevantItem}";
        }
    }
}