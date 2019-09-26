using System.Drawing;
using TextBasedGame.Character.Handlers;
using TextBasedGame.Character.Interfaces;
using TextBasedGame.Game.Handlers;
using TextBasedGame.Game.Models;
using TextBasedGame.Item.Interfaces;
using TextBasedGame.Room.Interfaces;

namespace TextBasedGame
{
    internal class Program
    {
        // These will build/create our Trait, Attr, Item, Character and Room objects from Game*.cs files
        // The order here is important, as some objects depend on others to already exist
        public static readonly IItemTraitCreator ItemTraitCreator = new Item.Implementations.ItemTraitCreator();
        public static readonly IAttributeCreator AttributeCreator = new Character.Implementations.AttributeCreator();
        public static readonly IItemCreator ItemCreator = new Item.Implementations.ItemCreator();
        public static readonly ICharacterCreator CharacterCreator = new Character.Implementations.CharacterCreator();
        public static readonly IRoomCreator RoomCreator = new Room.Implementations.RoomCreator();
        

        // This is the Entry Point for the entire Game (the console application)
        private static void Main()
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

            // Helper to pretty up and print the above variable
            GameSetupHandler.DisplayGameTitle(gameTitle);

            // This calls the Interface to { get; } a reference to our Player object we built earlier
            var player = CharacterCreator.Player;

            // Gets the players name from console input
            PlayerSetupHandler.WelcomePlayer(player);

            // User assigns their starting traits
            PlayerSetupHandler.SetPlayerTraits(player);

            // Game ends once 'BeginAdventure' returns
            GameSetupHandler.BeginAdventure(player, RoomCreator.YourBedroom);
        }
    }
}
