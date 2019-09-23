using System.Collections.Generic;

namespace TextBasedGame.Item.Models
{
    public class WeaponItemModel
    {
        public string WeaponName { get; set; }

        public bool InOriginalLocation { get; set; }

        public string WeaponDescription { get; set; }

        public string OriginalPlacementDescription { get; set; }

        public string GenericPlacementDescription { get; set; }

        public int AttackPower { get; set; }

        public List<string> KeywordsForPickup { get; set; }

        public List<ItemTraitModel> WeaponTraits { get; set; }
    }
}