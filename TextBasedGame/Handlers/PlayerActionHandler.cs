using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TextBasedGame.Character.Models;
using TextBasedGame.Constants;
using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Models;
using TextBasedGame.Utilities;
using Console = Colorful.Console;

namespace TextBasedGame.Handlers
{
    public class PlayerActionHandler
    {
        private static readonly IItem Item = new Item.Implementations.Item();

        public static string HandlePlayerInput(string input, CharacterModel player, RoomModel currentRoom)
        {
            var inputWords = input.Split(ConsoleStrings.StringDelimiters);
            var roomItemKeywords = GetAllRoomItemKeywords(currentRoom);
            var inventoryKeywords = GetAllInventoryItemKeywords(player);
            bool inputResolved = false;

            foreach (var inputWord in inputWords)
            {
                string substring;
                ItemsModel foundItem;

                switch (inputWord)
                {
                    case "pickup":
                    case "grab":
                    case "get":
                    case "take":
                    case "collect":
                    case "gather":
                        substring = CreateSubstringOfActionInput(input, inputWord);
                        foundItem = InventoryHandler.FindAnyMatchingItems(substring.Trim(), roomItemKeywords, currentRoom.RoomItems);
                        if (foundItem != null)
                        {
                            inputResolved = HandleItemAndUpdatePlayerAndRoom(ref player, ref currentRoom, foundItem);
                        }
                        break;
                    case "drop":
                    case "release":
                    case "letgo":
                        substring = CreateSubstringOfActionInput(input, inputWord);
                        foundItem = InventoryHandler.FindAnyMatchingItems(substring.Trim(), inventoryKeywords, 
                            Item.CreateItemsModel(player.CarriedItems, new List<WeaponItemModel>() { player.WeaponItem }));
                        if (foundItem != null)
                        {
                            inputResolved = HandleItemAndUpdatePlayerAndRoom(ref player, ref currentRoom, foundItem, true);
                        }
                        break;
                    case "go":
                    case "goto":
                    case "goin":
                    case "walk":
                    case "run":
                    case "enter":
                        // trying to go to another room
                        break;
                    case "item":
                    case "items":
                        string items = StringDescriptionHandler.CreateStringOfItemDescriptions(currentRoom.RoomItems.InventoryItems);
                        Console.WriteLine();
                        TypingAnimation.Animate(items == "" ? ConsoleStrings.NoItemsFound : items, Color.Aquamarine);
                        inputResolved = true;
                        break;
                    case "weapon":
                    case "weapons":
                        string weapons = StringDescriptionHandler.CreateStringOfWeaponDescriptions(currentRoom.RoomItems.WeaponItems);
                        Console.WriteLine();
                        TypingAnimation.Animate(weapons == "" ? ConsoleStrings.NoWeaponsFound : weapons, Color.Aquamarine);
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
                    case "stat":
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
            return PlayerInputActions.Redisplay;
        }

        private static bool HandleItemAndUpdatePlayerAndRoom(ref CharacterModel player, ref RoomModel currentRoom, ItemsModel foundItem, bool removeItem = false)
        {
            var updatedPlayerAndRoom = removeItem 
                ? InventoryHandler.HandleItemAddOrRemove(player, currentRoom, foundItem) 
                : InventoryHandler.HandleItemAddOrRemove(player, currentRoom, foundItem, true);

            player = updatedPlayerAndRoom.Item1;
            currentRoom = updatedPlayerAndRoom.Item2;
            return true;
        }

        private static string CreateSubstringOfActionInput(string input, string inputWord)
        {
            var matchingWordLength = inputWord.Length + 1;
            var keyword = inputWord.IndexOf(inputWord, StringComparison.OrdinalIgnoreCase);
            var substring = input.Substring(keyword + matchingWordLength);
            return substring;
        }

        private static List<string> GetAllRoomItemKeywords(RoomModel currentRoom)
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

        private static List<string> GetAllInventoryItemKeywords(CharacterModel player)
        {
            IEnumerable<string> itemKeywords = new List<string>();
            IEnumerable<string> weaponKeywords = new List<string>();
            var keywords = new List<string>();

            foreach (var item in player.CarriedItems)
            {
                itemKeywords = (item.KeywordsForPickup.Where(k => !string.IsNullOrEmpty(k)));
            }

            if (!string.IsNullOrEmpty(player.WeaponItem?.WeaponName))
            {
                weaponKeywords = player.WeaponItem.KeywordsForPickup.Where(k => !string.IsNullOrEmpty(k));
            }

            keywords.AddRange(itemKeywords);
            keywords.AddRange(weaponKeywords);
            return keywords;
        }
    }
}