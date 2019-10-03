using TextBasedGame.Character.Models;

namespace TextBasedGame.Character.Interfaces
{
    public interface IAttributeCreator
    {
        // Declare all getters for any Character Attributes you will use here
        CharacterAttribute PlayerAttributes { get; }
        CharacterAttribute HenryAttributes { get; }
        CharacterAttribute GhoulAttributes { get; }
    }
}