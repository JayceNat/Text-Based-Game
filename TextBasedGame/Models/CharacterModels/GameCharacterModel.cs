using System.Collections.Generic;
using TextBasedGame.Models.ItemModels;

namespace TextBasedGame.Models.CharacterModels
{
    public class GameCharacterModel
    {
        public string Name { get; set; }

        public int HealthPoints { get; set; } = 100;

        public CharacterAttributeModel Attributes { get; set; }

        public List<ItemModel> CarriedItems { get; set; }

        public WeaponItemModel WeaponItem { get; set; }
    }
}