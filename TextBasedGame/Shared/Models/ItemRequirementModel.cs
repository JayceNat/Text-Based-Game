using TextBasedGame.Item.Models;

namespace TextBasedGame.Shared.Models
{
    public class ItemRequirementModel
    {
        public string RequirementName { get; set; }

        public InventoryItemModel RelevantItem { get; set; }
    }
}