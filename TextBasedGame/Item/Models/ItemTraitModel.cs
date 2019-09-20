using TextBasedGame.Character.Models;
using TextBasedGame.Constants;

namespace TextBasedGame.Item.Models
{
    public class ItemTraitModel
    {
        public string TraitName { get; set; }

        public CharacterAttributes RelevantCharacterAttribute { get; set; }

        public int TraitValue { get; set; }
    }
}