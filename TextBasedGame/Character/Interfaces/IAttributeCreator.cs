using TextBasedGame.Character.Models;

namespace TextBasedGame.Character.Interfaces
{
    public interface IAttributeCreator
    {
        CharacterAttribute PlayerAttributes { get; }

        CharacterAttribute GhoulAttributes { get; }
    }
}