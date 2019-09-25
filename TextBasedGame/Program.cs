using System.Drawing;
using TextBasedGame.Character.Handlers;
using TextBasedGame.Character.Interfaces;
using TextBasedGame.Game.Handlers;
using TextBasedGame.Game.Models;
using TextBasedGame.Room.Interfaces;

namespace TextBasedGame
{
    internal class Program
    {
        private static readonly ICharacterCreator CharacterCreator = new Character.Implementations.CharacterCreator();
        private static readonly IRoomCreator RoomCreator = new Room.Implementations.RoomCreator();

        private static void Main(string[] args)
        {
            var gameTitle = new GameTitle()
            {
                Title = "Awesome Title!",
                TitleTextColor = Color.Aqua,
                Author = "<Your Name Here!>",
                AuthorTextColor = Color.CadetBlue
            };

            GameSetupHandler.DisplayGameTitle(gameTitle);

            var player = CharacterCreator.Player;

            PlayerSetupHandler.WelcomePlayer(player);
            PlayerSetupHandler.SetPlayerTraits(player);

            GameSetupHandler.BeginAdventure(player, RoomCreator.YourBedroom);
            //game over
        }
    }
}
