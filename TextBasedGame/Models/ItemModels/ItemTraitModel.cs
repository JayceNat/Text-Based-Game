using TextBasedGame.Models.CharacterModels;

namespace TextBasedGame.Models.ItemModels
{
    public class ItemTraitModel
    {
        public string TraitName { get; set; }

        public AttributeModel RelevantAttribute { get; set; }

        public int TraitValue { get; set; }
    }
}