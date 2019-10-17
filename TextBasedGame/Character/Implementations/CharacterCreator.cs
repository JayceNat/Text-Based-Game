using TextBasedGame.Character.Interfaces;

namespace TextBasedGame.Character.Implementations
{
    public class CharacterCreator : ICharacterCreator
    {
        // Declare all getters for any Characters you will use here
        public Models.Character Player { get; set; }
        public Models.Character Charlie { get; set; }
        public Models.Character Henry { get; set; }
        public Models.Character Ghoul { get; set; }

        // Constructor: Add the reference to all the Attribute Objects here
        public CharacterCreator()
        {
            Player = GameCharacters.Player;
            Charlie = GameCharacters.Charlie;
            Henry = GameCharacters.Henry;
            Ghoul = GameCharacters.Ghoul;
        }
    }
}