using System;
using System.Collections.Generic;
using System.Drawing;
using TextBasedGame.Item.Handlers;
using TextBasedGame.Item.Interfaces;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Handlers;
using TextBasedGame.Room.Interfaces;
using TextBasedGame.Shared.Constants;
using TextBasedGame.Shared.Utilities;
using Console = Colorful.Console;

namespace TextBasedGame.Character.Handlers
{
    public class PlayerActionHandler
    {
        private static readonly IRoomCreator RoomCreator = new Room.Implementations.RoomCreator();
        private static readonly IItem Item = new Item.Implementations.Item();

        public static Room.Models.Room HandlePlayerInput(string fullInput, Models.Character player, Room.Models.Room currentRoom)
        {
            var inputWords = fullInput.Split(ConsoleStrings.StringDelimiters);
            
            var inputResolved = false;
            foreach (var inputWord in inputWords)
            {
                string substring;
                Items foundItem;

                switch (inputWord)
                {
                    case "pickup":
                    case "grab":
                    case "get":
                    case "take":
                    case "collect":
                    case "gather":
                        var roomItemKeywords = RoomHandler.GetAllRoomItemKeywords(currentRoom);
                        substring = CreateSubstringOfActionInput(fullInput, inputWord);
                        foundItem = InventoryHandler.FindAnyMatchingItemsByKeywords(substring.Trim(), roomItemKeywords, currentRoom.RoomItems);
                        if (foundItem != null)
                        {
                            inputResolved = InventoryHandler.HandleItemAndUpdatePlayerAndRoom(player, currentRoom, foundItem);
                        }
                        break;
                    case "drop":
                    case "release":
                    case "letgo":
                        var inventoryKeywords = InventoryHandler.GetAllInventoryItemKeywords(player);
                        substring = CreateSubstringOfActionInput(fullInput, inputWord);
                        foundItem = InventoryHandler.FindAnyMatchingItemsByKeywords(substring.Trim(), inventoryKeywords,
                            Item.CreateItemsModel(player.CarriedItems, new List<WeaponItem>() {player.WeaponItem}));
                        if (foundItem != null)
                        {
                            inputResolved = InventoryHandler.HandleItemAndUpdatePlayerAndRoom(player, currentRoom, foundItem, true);
                        }
                        break;
                    case "go":
                    case "goto":
                    case "goin":
                    case "walk":
                    case "run":
                    case "enter":
                        substring = CreateSubstringOfActionInput(fullInput, inputWord);
                        var foundRoom = RoomHandler.FindAnyMatchingRoomByKeywords(substring.Trim(), currentRoom);
                        if (foundRoom != null)
                        {
                            Console.WriteLine();
                            TypingAnimation.Animate("You go into " + foundRoom.RoomName + "... \n", Color.Chartreuse, 40);
                            Console.WriteWithGradient(ConsoleStrings.PressEnterPrompt, Color.Yellow, Color.DarkRed, 4);
                            Console.ReadLine();
                            if (!currentRoom.RoomEntered)
                            {
                                RoomCreator.UpdateRoom(currentRoom, true);
                            }
                            return foundRoom;
                        }
                        break;
                    case "item":
                    case "items":
                        var items = StringDescriptionBuilder.CreateStringOfItemDescriptions(currentRoom.RoomItems.InventoryItems);
                        Console.WriteLine();
                        TypingAnimation.Animate(items == "" ? ConsoleStrings.NoItemsFound : items, Color.Aquamarine);
                        inputResolved = true;
                        break;
                    case "weapon":
                    case "weapons":
                        var weapons = StringDescriptionBuilder.CreateStringOfWeaponDescriptions(currentRoom.RoomItems.WeaponItems);
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
                        var exits = StringDescriptionBuilder.CreateStringOfExitDescriptions(currentRoom.AvailableExits);
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
                        var playerInventory = StringDescriptionBuilder.CreateStringOfPlayerInventory(player, true);
                        Console.WriteLine();
                        Console.WriteLine(playerInventory, Color.ForestGreen);
                        inputResolved = true;
                        break;
                    case "character":
                    case "status":
                    case "stat":
                    case "stats":
                        var characterInfo = StringDescriptionBuilder.CreateStringOfPlayerInfo(player);
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
                        var exitDescriptions = StringDescriptionBuilder.CreateStringOfExitDescriptions(currentRoom.AvailableExits);
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
                TypingAnimation.Animate("You " + fullInput + "...", Color.Chartreuse, 40);
                TypingAnimation.Animate(". . . Nothing happens. \n", Color.Chartreuse, 40);
            }

            Console.WriteWithGradient(ConsoleStrings.PressEnterPrompt, Color.Yellow, Color.DarkRed, 4);
            Console.ReadLine();
            Console.Clear();
            Console.ReplaceAllColorsWithDefaults();

            return null;
        }

        private static string CreateSubstringOfActionInput(string input, string inputWord)
        {
            var matchingWordLength = inputWord.Length + 1;
            var keyword = inputWord.IndexOf(inputWord, StringComparison.OrdinalIgnoreCase);
            var substring = input.Substring(keyword + matchingWordLength);
            return substring;
        }
    }
}