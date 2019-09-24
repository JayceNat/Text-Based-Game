using TextBasedGame.Item.Interfaces;

namespace TextBasedGame.Item.Implementations
{
    public class ItemTrait : IItemTrait
    {
        public Models.ItemTrait CreateItemTrait(string name, string relevantCharacterAttribute, int traitValue)
        {
            var itemTrait = new Models.ItemTrait()
            {
                TraitName = name,
                RelevantCharacterAttribute = relevantCharacterAttribute,
                TraitValue = traitValue
            };

            return itemTrait;
        }
    }
}