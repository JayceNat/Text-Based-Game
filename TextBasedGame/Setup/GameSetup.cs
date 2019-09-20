using System.Collections.Generic;
using System.Drawing;
using Colorful;
using TextBasedGame.Character.Models;
using TextBasedGame.Constants;
using TextBasedGame.Game.Models;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Models;

namespace TextBasedGame.Setup
{
    public class GameSetup
    {
        public static void DisplayGameTitle(GameTitleModel gameTitle)
        {
            List<char> chars = new List<char>()
            {
                'P', 'r', 'e', 's', 's', ' ',
                'E', 'n', 't', 'e', 'r', ' ',
                'T', 'o', ' ',
                'C', 'o', 'n', 't', 'i', 'n', 'u', 'e',
                '.', '.', '.', ' '
            };
            FigletFont font = FigletFont.Default;
            Figlet figlet = new Figlet(font);

            Console.ReplaceAllColorsWithDefaults();
            Console.WriteLine(figlet.ToAscii(gameTitle.Title), gameTitle.TitleTextColor);
            Console.WriteLine();
            Console.WriteLine("\t-- Written by " + gameTitle.Author + "--", gameTitle.AuthorTextColor);
            Console.WriteLine("\n\n");
            Console.WriteWithGradient(chars, Color.Yellow, Color.DarkRed, 12);
            Console.ReadLine();
            Console.ReplaceAllColorsWithDefaults();
            Console.Clear();
        }

        public static CharacterModel BeginAdventure(CharacterModel player)
        {
            bool gameFinished = false;
//            RoomModel YourBedroom = new RoomModel()
//            {
//                RoomName = "Your Bedroom",
//                GenericRoomDescription = "You are standing in your bedroom, next to your bed. \n" +
//                                  "There's a faint, early morning light coming in through the blinds of your open window. \n" +
//                                  "You can feel the cold autumn air coming in from outside.",
//                AvailableExits = new List<RoomExitModel>()
//                {
//                    new RoomExitModel()
//                    {
//                        ExitName = "Your Living Room",
//                        ExitDescription = "Behind you is the doorway leading out of \n" +
//                                          "your bedroom and into your living room.",
//                        ExitExitDirection = new ExitDirections().Behind
//                    }
//                },
//                RoomItems = new List<ItemModel>()
//                {
//                    new ItemModel()
//                    {
//                        InventoryItem = new InventoryItemModel()
//                        {
//                            ItemName = "Running Shoes",
//                            ItemDescription = "Your trusty old running shoes. You swear you run way faster in them.",
//                            ItemPlacementDescription = "Your old running shoes are peaking up at you from under your bed.",
//                            ItemTraits = new List<ItemTraitModel>()
//                            {
//                                new ItemTraitModel()
//                                {
//                                    TraitName = "Luck + (1)!",
//                                    RelevantCharacterAttribute = CharacterAttributes.Luck,
//                                    TraitValue = 1
//                                }
//                            }
//                        }
//                    },
//                    new ItemModel()
//                    {
////                        new WeaponItemModel()
////                        {
////
////                        }
//                    }
//                }
//            };
            return player;
        }
    }
}