using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using TextBasedGame.Item.SaveGameConverters;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Item.Models
{
    [TypeConverter(typeof(WeaponItemConverter))]
    [SettingsSerializeAs(SettingsSerializeAs.String)]
    public class WeaponItem
    {
        public string WeaponName { get; set; }

        public bool InOriginalLocation { get; set; }

        public string WeaponDescription { get; set; }

        public string OriginalPlacementDescription { get; set; }

        public string GenericPlacementDescription { get; set; }

        public int AttackPower { get; set; }

        public int AmmunitionAmount { get; set; } = -1;

        public List<string> KeywordsForPickup { get; set; } = new List<string>();

        public List<ItemTrait> WeaponTraits { get; set; } = new List<ItemTrait>();

        public AttributeRequirement AttributeRequirementToSee { get; set; } = null;

        public AttributeRequirement AttributeRequirementToTake { get; set; } = null;
    }
}