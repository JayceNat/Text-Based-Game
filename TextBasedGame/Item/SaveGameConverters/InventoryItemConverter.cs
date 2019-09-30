using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.SaveGameConverters
{
    public class InventoryItemConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (!(value is string str)) return base.ConvertFrom(context, culture, value);

            var parts = str.Split(',');
            var inventoryItem = new InventoryItem
            {
                // TODO: Fix this converter
                ItemName = parts[0],
                InOriginalLocation = Convert.ToBoolean(parts[1]),
                ItemDescription = parts[2],
                OriginalPlacementDescription = parts[3],
                GenericPlacementDescription = parts[4],
                InventorySpaceConsumed = Convert.ToInt32(parts[5]),
                TreatItemAs = parts[6],
                DocumentText = parts[7],
                KeywordsForPickup = new List<string> { parts[8] },
                ItemTraits = new List<ItemTrait>(),// { parts[9] },
                AttributeRequirementToSee = null, // parts[10]
                AttributeRequirementToTake = null // parts[11]
            };

            return inventoryItem;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType != typeof(string)) return base.ConvertTo(context, culture, value, destinationType);

            var inventoryItem = value as InventoryItem;

            return $"{inventoryItem?.ItemName},{inventoryItem?.InOriginalLocation}," +
                   $"{inventoryItem?.ItemDescription},{inventoryItem?.OriginalPlacementDescription}," +
                   $"{inventoryItem?.GenericPlacementDescription},{inventoryItem?.InventorySpaceConsumed}," +
                   $"{inventoryItem?.TreatItemAs},{inventoryItem?.DocumentText}," +
                   $"{inventoryItem?.KeywordsForPickup},{inventoryItem?.ItemTraits}," +
                   $"{inventoryItem?.AttributeRequirementToSee},{inventoryItem?.AttributeRequirementToTake}";
        }
    }
}