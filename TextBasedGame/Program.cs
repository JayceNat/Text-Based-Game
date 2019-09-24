using System.Drawing;
using TextBasedGame.Character.Handlers;
using TextBasedGame.Game.Models;
using TextBasedGame.Game.Setup;
using TextBasedGame.Room.Interfaces;

namespace TextBasedGame
{
    internal class Program
    {
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

            GameSetup.DisplayGameTitle(gameTitle);

            var player = PlayerSetupHandler.InstantiatePlayer();

            player = PlayerSetupHandler.WelcomePlayer(player);
            player = PlayerSetupHandler.SetPlayerTraits(player);

            player = GameSetup.BeginAdventure(player, RoomCreator.YourBedroom);
            //game over
        }
    }
}
