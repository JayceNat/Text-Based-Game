using TextBasedGame.Character.Interfaces;

namespace TextBasedGame.Character.Implementations
{
    public class CharacterCreator : ICharacterCreator
    {
        // Declare all getters for any Characters you will use here
        public Models.Character Player { get; }
        public Models.Character Ghoul { get; }

        // Constructor: Add the reference to all the Attribute Objects here
        public CharacterCreator()
        {
            Player = GameCharacters.Player;
            Ghoul = GameCharacters.Ghoul;
        }
    }
}