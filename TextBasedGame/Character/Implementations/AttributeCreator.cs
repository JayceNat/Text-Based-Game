using TextBasedGame.Character.Interfaces;
using TextBasedGame.Character.Models;

namespace TextBasedGame.Character.Implementations
{
    public class AttributeCreator : IAttributeCreator
    {
        public CharacterAttribute PlayerAttributes { get; }

        public CharacterAttribute GhoulAttributes { get; }

        public AttributeCreator()
        {
            PlayerAttributes = Attributes.PlayerAttributes;
            GhoulAttributes = Attributes.GhoulAttributes;
        }
    }
}