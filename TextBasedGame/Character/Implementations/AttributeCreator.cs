using TextBasedGame.Character.Interfaces;
using TextBasedGame.Character.Models;

namespace TextBasedGame.Character.Implementations
{
    public class AttributeCreator : IAttributeCreator
    {
        // Declare all getters for any Character Attributes you will use here
        public CharacterAttribute PlayerAttributes { get; }
        public CharacterAttribute CharlieAttributes { get; }
        public CharacterAttribute HenryAttributes { get; }
        public CharacterAttribute GhoulAttributes { get; }

        // Constructor: Add the reference to all the Attribute Objects here
        public AttributeCreator()
        {
            PlayerAttributes = GameAttributes.PlayerAttributes;
            CharlieAttributes = GameAttributes.CharlieAttributes;
            HenryAttributes = GameAttributes.HenryAttributes;
            GhoulAttributes = GameAttributes.GhoulAttributes;
        }
    }
}