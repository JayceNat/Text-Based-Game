namespace TextBasedGame.Character.Interfaces
{
    public interface ICharacterCreator
    {
        // Declare all getters for any Characters you will use here
        Models.Character Player { get; }
        Models.Character Ghoul { get; }
    }
}