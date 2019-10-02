using TextBasedGame.Item.Models;

namespace TextBasedGame.Shared.Models
{
    public class ItemRequirement
    {
        public string RequirementName { get; set; }

        public InventoryItem RelevantItem { get; set; }
    }
}