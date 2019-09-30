using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.SaveGameConverters
{
    public class WeaponItemConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (!(value is string str)) return base.ConvertFrom(context, culture, value);

            var parts = str.Split(',');
            var weapon = new WeaponItem
            {
                // TODO: Fix this converter
                WeaponName = parts[0],
                InOriginalLocation = Convert.ToBoolean(parts[1]),
                WeaponDescription = parts[2],
                OriginalPlacementDescription = parts[3],
                GenericPlacementDescription = parts[4],
                AttackPower = Convert.ToInt32(parts[5]),
                AmmunitionAmount = Convert.ToInt32(parts[6]),
                KeywordsForPickup = new List<string> { parts[7] },
                WeaponTraits = new List<ItemTrait>(), // parts[8]
                AttributeRequirementToSee = null, // parts[9]
                AttributeRequirementToTake = null // parts[10]
            };

            return weapon;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string)) return base.ConvertTo(context, culture, value, destinationType);

            var weapon = value as WeaponItem;

            return $"{weapon?.WeaponName},{weapon?.InOriginalLocation}," +
                   $"{weapon?.WeaponDescription},{weapon?.OriginalPlacementDescription}," +
                   $"{weapon?.GenericPlacementDescription},{weapon?.AttackPower}," +
                   $"{weapon?.AmmunitionAmount},{weapon?.KeywordsForPickup}," +
                   $"{weapon?.WeaponTraits},{weapon?.AttributeRequirementToSee}," +
                   $"{weapon?.AttributeRequirementToTake}";
        }
    }
}