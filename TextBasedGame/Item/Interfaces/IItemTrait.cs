using TextBasedGame.Item.Models;

namespace TextBasedGame.Item.Interfaces
{
    public interface IItemTrait
    {
        ItemTrait CreateItemTrait(string name, string relevantCharacterAttribute, int traitValue);
    }
}