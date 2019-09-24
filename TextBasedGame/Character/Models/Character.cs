using System.Collections.Generic;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Character.Models
{
    public class Character
    {
        public string Name { get; set; }

        public int MaximumHealthPoints { get; set; } = 100;

        public int HealthPoints { get; set; } = 100;

        public CharacterAttribute Attributes { get; set; }

        public List<InventoryItem> CarriedItems { get; set; }

        public int MaximumCarryingCapacity { get; set; } = 4;

        public int CarriedItemsCount { get; set; } = 0;

        public WeaponItem WeaponItem { get; set; }
    }
}