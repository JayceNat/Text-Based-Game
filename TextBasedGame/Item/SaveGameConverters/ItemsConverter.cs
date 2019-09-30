using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.SaveGameConverters
{
    public class ItemsConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (!(value is string str)) return base.ConvertFrom(context, culture, value);

            var parts = str.Split(',');
            var items = new Items
            {
                // TODO: Fix this converter
                InventoryItems = new List<InventoryItem>(), // parts[0]
                WeaponItems = new List<WeaponItem>() // parts[1]
            };

            return items;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string)) return base.ConvertTo(context, culture, value, destinationType);

            var items = value as Items;

            return $"{items?.InventoryItems},{items?.WeaponItems}";
        }
    }
}