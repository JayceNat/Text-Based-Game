using System.Collections.Generic;
using TextBasedGame.Item.Constants;
using TextBasedGame.Shared.Models;

namespace TextBasedGame.Item.Models
{
    public class InventoryItem
    {
        public string ItemName { get; set; }

        public bool InOriginalLocation { get; set; }

        public string ItemDescription { get; set; }

        public string OriginalPlacementDescription { get; set; }

        public string GenericPlacementDescription { get; set; }

        public int InventorySpaceConsumed { get; set; } = 1;

        public string TreatItemAs { get; set; } = ItemUseTypes.Default;

        public string DocumentText { get; set; } = null;

        public List<string> KeywordsForPickup { get; set; } = new List<string>();

        public List<ItemTrait> ItemTraits { get; set; } = new List<ItemTrait>();

        public AttributeRequirement AttributeRequirementToSee { get; set; } = null;

        public AttributeRequirement AttributeRequirementToTake { get; set; } = null;
    }
}