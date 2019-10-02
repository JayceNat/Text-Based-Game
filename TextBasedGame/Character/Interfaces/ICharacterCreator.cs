namespace TextBasedGame.Character.Interfaces
{
    public interface ICharacterCreator
    {
        // Declare all getters for any Characters you will use here
        Models.Character Player { get; set; }
        Models.Character Ghoul { get; set; }
    }
}