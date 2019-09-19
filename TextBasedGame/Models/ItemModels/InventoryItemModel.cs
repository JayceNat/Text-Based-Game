using System.Collections.Generic;

namespace TextBasedGame.Models.ItemModels
{
    public class InventoryItemModel
    {
        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public string ItemPlacementDescription { get; set; }

        public List<ItemTraitModel> ItemTraits { get; set; }
    }
}