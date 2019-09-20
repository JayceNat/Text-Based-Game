﻿using System.Drawing;
using TextBasedGame.Game.Models;
using TextBasedGame.Setup;

namespace TextBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameTitleModel gameTitle = new GameTitleModel()
            {
                Title = "Awesome!",
                TitleTextColor = Color.Aqua,
                Author = "Jayce Meyer",
                AuthorTextColor = Color.CadetBlue
            };

            GameSetup.DisplayGameTitle(gameTitle);

            var player = PlayerSetup.InstantiatePlayer();
            player = PlayerSetup.WelcomePlayer(player);
            player = PlayerSetup.SetPlayerTraits(player);

            GameSetup.BeginAdventure(player);
        }
    }
}