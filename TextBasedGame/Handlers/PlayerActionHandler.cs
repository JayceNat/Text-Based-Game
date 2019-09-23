using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using TextBasedGame.Character.Interfaces;
using TextBasedGame.Character.Models;
using TextBasedGame.Constants;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Interfaces;
using TextBasedGame.Room.Models;
using TextBasedGame.Utilities;
using Console = Colorful.Console;

namespace TextBasedGame.Handlers
{
    public class PlayerActionHandler
    {
        private static readonly ICharacter Character = new Character.Implementations.Character();
        private static readonly IRoom Room = new Room.Implementations.Room();

        public static string HandlePlayerInput(string input, CharacterModel player, RoomModel currentRoom)
        {
            var inputWords = input.Split(ConsoleStrings.StringDelimiters);
            var keywords = GetAllItemKeywords(currentRoom);
            bool inputResolved = false;

            foreach (var inputWord in inputWords)
            {
                switch (inputWord)
                {
                    case "pickup":
                    case "grab":
                    case "get":
                    case "take":
                    case "collect":
                    case "gather":
                        var matchingWordLength = inputWord.Length + 1;
                        var keyword = inputWord.IndexOf(inputWord, StringComparison.Ordinal);
                        var substring = input.Substring(keyword + matchingWordLength);
                        var foundItem = InventoryHandler.FindAnyMatchingItems(substring.Trim(), keywords, currentRoom.RoomItems);
                        if (foundItem != null)
                        {
                            var updatedPlayerAndRoom = InventoryHandler.HandleItemAdd(player, currentRoom, foundItem);
                            player = updatedPlayerAndRoom.Item1;
                            currentRoom = updatedPlayerAndRoom.Item2;
                            inputResolved = true;
                        }
                        break;
                    case "go":
                    case "goto":
                    case "walk":
                    case "run":
                        // trying to go to another room
                        break;
                    case "item":
                    case "items":
                        string items = StringDescriptionHandler.CreateStringOfItemDescriptions(currentRoom.RoomItems.InventoryItems);
                        Console.WriteLine();
                        if (items == "")
                        {
                            TypingAnimation.Animate(ConsoleStrings.NoItemsFound, Color.Aquamarine);
                        }
                        else
                        {
                            TypingAnimation.Animate(items, Color.Aquamarine);
                        }
                        inputResolved = true;
                        break;
                    case "weapon":
                    case "weapons":
                        string weapons = StringDescriptionHandler.CreateStringOfWeaponDescriptions(currentRoom.RoomItems.WeaponItems);
                        Console.WriteLine();
                        if (weapons == "")
                        {
                            TypingAnimation.Animate(ConsoleStrings.NoWeaponsFound, Color.Aquamarine);
                        }
                        else
                        {
                            TypingAnimation.Animate(weapons, Color.Aquamarine);
                        }
                        inputResolved = true;
                        break;
                    case "exit":
                    case "exits":
                    case "leave":
                    case "door":
                    case "doors":
                    case "out":
                    case "where":
                        string exits = StringDescriptionHandler.CreateStringOfExitDescriptions(currentRoom.AvailableExits);
                        Console.WriteLine();
                        TypingAnimation.Animate(exits, Color.Red);
                        inputResolved = true;
                        break;
                    case "inventory":
                    case "inv":
                    case "carried":
                    case "carrying":
                    case "pockets":
                    case "backpack":
                        string playerInventory = StringDescriptionHandler.CreateStringOfPlayerInventory(player, true);
                        Console.WriteLine();
                        Console.WriteLine(playerInventory, Color.ForestGreen);
                        inputResolved = true;
                        break;
                    case "character":
                    case "status":
                    case "stats":
                        string characterInfo = StringDescriptionHandler.CreateStringOfPlayerInfo(player);
                        Console.WriteLine();
                        Console.WriteLine(characterInfo, Color.ForestGreen);
                        inputResolved = true;
                        break;
                    case "info":
                    case "help":
                    case "guidance":
                    case "assist":
                    case "assistance":
                    case "?":
                        string exitDescriptions = StringDescriptionHandler.CreateStringOfExitDescriptions(currentRoom.AvailableExits);
                        Console.WriteLine();
                        Console.WriteLine(currentRoom.GenericRoomDescription, Color.Bisque);
                        Console.WriteLine(exitDescriptions, Color.Red);
                        Console.WriteLine(ConsoleStrings.GameHelp, Color.MediumPurple);
                        inputResolved = true;
                        break;
                }
            }

            if (!inputResolved)
            {
                Console.WriteLine();
                TypingAnimation.Animate("You " + input + "...", Color.Chartreuse, 40);
                TypingAnimation.Animate(". . . Nothing happens. \n", Color.Chartreuse, 40);
            }

            Console.WriteWithGradient(ConsoleStrings.PressEnterPrompt, Color.Yellow, Color.DarkRed, 4);
            Console.ReadLine();
            Console.Clear();
            Console.ReplaceAllColorsWithDefaults();
            return PlayerInputActions.Redisplay; ;
        }

        private static List<string> GetAllItemKeywords(RoomModel currentRoom)
        {
            IEnumerable<string> itemKeywords = new List<string>();
            IEnumerable<string> weaponKeywords = new List<string>();
            var keywords = new List<string>();

            foreach (var item in currentRoom.RoomItems.InventoryItems)
            {
                itemKeywords = (item.KeywordsForPickup.Where(k => !string.IsNullOrEmpty(k)));
            }

            foreach (var weapon in currentRoom.RoomItems.WeaponItems)
            {
                weaponKeywords = weapon.KeywordsForPickup.Where(k => !string.IsNullOrEmpty(k));
            }

            keywords.AddRange(itemKeywords);
            keywords.AddRange(weaponKeywords);
            return keywords;
        }
    }
}