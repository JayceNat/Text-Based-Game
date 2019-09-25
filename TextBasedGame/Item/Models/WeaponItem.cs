using System.Collections.Generic;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Item.Models
{
    public class WeaponItem
    {
        public string WeaponName { get; set; }

        public bool InOriginalLocation { get; set; }

        public string WeaponDescription { get; set; }

        public string OriginalPlacementDescription { get; set; }

        public string GenericPlacementDescription { get; set; }

        public int AttackPower { get; set; }

        public List<string> KeywordsForPickup { get; set; } = new List<string>();

        public List<ItemTrait> WeaponTraits { get; set; } = new List<ItemTrait>();

        public AttributeRequirement AttributeRequirementToSee { get; set; } = null;
    }
}