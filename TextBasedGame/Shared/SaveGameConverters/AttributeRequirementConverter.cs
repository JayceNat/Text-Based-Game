using System;
using System.ComponentModel;
using System.Globalization;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Shared.SaveGameConverters
{
    public class AttributeRequirementConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (!(value is string str)) return base.ConvertFrom(context, culture, value);

            var parts = str.Split(',');
            var attributeRequirement = new AttributeRequirement
            {
                RequirementName = parts[0],
                RelevantCharacterAttribute = parts[1],
                MinimumAttributeValue = Convert.ToInt32(parts[2])
            };

            return attributeRequirement;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string)) return base.ConvertTo(context, culture, value, destinationType);

            var attributeRequirement = value as AttributeRequirement;

            return $"{attributeRequirement?.RequirementName},{attributeRequirement?.RelevantCharacterAttribute}," +
                   $"{attributeRequirement?.MinimumAttributeValue}";
        }
    }
}