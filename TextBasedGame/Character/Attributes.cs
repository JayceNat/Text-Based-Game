using TextBasedGame.Character.Interfaces;
using TextBasedGame.Character.Models;

namespace TextBasedGame.Character
{
    public class Attributes
    {
        private static readonly IAttribute Attribute = new Implementations.Attribute();

        public static CharacterAttributeModel GhoulAttributes =
            Attribute.CreateCharacterAttributes(
                0,
                7,
                4,
                6,
                6,
                9,
                4);
    }
}