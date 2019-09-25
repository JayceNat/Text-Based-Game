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
                // TODO: Come up with a cooler title...
                Title = "Awesome Title!",
                TitleTextColor = Color.Aqua,

                // TODO: Put your name here...
                Author = "<Your Name Here!>",
                AuthorTextColor = Color.CadetBlue
            };

            GameSetupHandler.DisplayGameTitle(gameTitle);

            var player = CharacterCreator.Player;

            // Gets the players name
            PlayerSetupHandler.WelcomePlayer(player);

            // User assigns their starting traits 
            PlayerSetupHandler.SetPlayerTraits(player);

            // Game ends once 'BeginAdventure' returns
            GameSetupHandler.BeginAdventure(player, RoomCreator.YourBedroom);
        }
    }
}
