namespace TextBasedGame.Item.Models
{
    public class WeaponItemModel
    {
        public string WeaponName { get; set; }

        public string WeaponDescription { get; set; }

        public string WeaponPlacementDescription { get; set; }

        public int AttackPower { get; set; }

        public ItemTraitModel WeaponTraits { get; set; }
    }
}