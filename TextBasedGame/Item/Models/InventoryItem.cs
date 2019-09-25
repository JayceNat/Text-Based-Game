using System.Collections.Generic;
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

        public List<string> KeywordsForPickup { get; set; } = new List<string>();

        public List<ItemTrait> ItemTraits { get; set; } = new List<ItemTrait>();

        public AttributeRequirement AttributeRequirementToSee { get; set; } = null;
    }
}