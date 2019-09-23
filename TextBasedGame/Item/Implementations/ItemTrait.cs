using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.Implementations
{
    public class ItemTrait : IItemTrait
    {
        public ItemTraitModel CreateItemTrait(string name, string relevantCharacterAttribute, int traitValue)
        {
            ItemTraitModel itemTrait = new ItemTraitModel()
            {
                TraitName = name,
                RelevantCharacterAttribute = relevantCharacterAttribute,
                TraitValue = traitValue
            };

            return itemTrait;
        }
    }
}