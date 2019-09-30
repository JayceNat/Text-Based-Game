using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TextBasedGame.Item.Handlers;
using TextBasedGame.Item.Models;
using TextBasedGame.Room.Handlers;
using TextBasedGame.Shared.Constants;
using TextBasedGame.Shared.Utilities;
using Console = Colorful.Console;

namespace TextBasedGame.Character.Handlers
{
    public class PlayerActionHandler
    {
        // This handles any input the player enters inside a room,
        // and returns the next Room when the player decides to leave the current one
        public static Room.Models.Room HandlePlayerInput(string fullInput, Models.Character player, Room.Models.Room currentRoom)
        {
            var inputWords = fullInput.Split(ConsoleStrings.StringDelimiters);

            var inputResolved = false;
            foreach (var inputWord in inputWords)
            {
                string substring;
                List<string> inventoryKeywords;
                Items foundItem;

                switch (inputWord)
                {
                    case "pickup":
                    case "pick":
                    case "grab":
                    case "get":
                    case "take":
                    case "collect":
                    case "gather":
                        var roomItemKeywords = RoomHandler.GetAllRoomItemKeywords(currentRoom);
                        substring = CreateSubstringOfActionInput(fullInput, inputWord);
                        foundItem = InventoryHandler.FindAnyMatchingItemsByKeywords(substring.Trim(), roomItemKeywords,
                            currentRoom.RoomItems.InventoryItems, currentRoom.RoomItems.WeaponItems);
                        if (foundItem != null)
                        {
                            InventoryHandler.HandleItemAddOrRemove(player, currentRoom, foundItem, true);
                            inputResolved = true;
                        }
                        break;
                    case "drop":
                    case "release":
                    case "letgo":
                        inventoryKeywords = InventoryHandler.GetAllInventoryItemKeywords(player);
                        substring = CreateSubstringOfActionInput(fullInput, inputWord);
                        foundItem = InventoryHandler.FindAnyMatchingItemsByKeywords(substring.Trim(), inventoryKeywords,
                            player.CarriedItems, new List<WeaponItem>() { player.WeaponItem });
                        if (foundItem != null)
                        {
                            if (InventoryHandler.PickupOrDropItemIsOk(player, foundItem, false))
                            {
                                InventoryHandler.HandleItemAddOrRemove(player, currentRoom, foundItem);
                                inputResolved = true;
                            }
                            else
                            {
                                Console.WriteLine();
                                TypingAnimation.Animate("You cannot drop the " + foundItem.InventoryItems?.First()?.ItemName +
                                                        " until you drop other items. \n" +
                                                        "(The item you're trying to drop would decrease your inventory space) \n", Color.DarkOliveGreen);
                                inputResolved = true;
                            }
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
                            if (RoomHandler.DoesPlayerMeetRequirementsToEnter(player, currentRoom, foundRoom))
                            {
                                return foundRoom;
                            }

                            inputResolved = true;
                        }
                        break;
                    case "talk":
                    case "ask":
                    case "buy":
                        // TODO: Implement a conversation/purchase system with a character in a room
                    case "fight":
                    case "kill":
                    case "attack":
                        // TODO: Implement the combat system if an enemy is in the room...
                        break;
                    case "use":
                    case "consume":
                    case "eat":
                    case "drink":
                    case "read":
                    case "look at":
                    case "open":
                    case "swing":
                    case "shoot":
                    case "fire":
                        inventoryKeywords = InventoryHandler.GetAllInventoryItemKeywords(player);
                        substring = CreateSubstringOfActionInput(fullInput, inputWord);
                        foundItem = InventoryHandler.FindAnyMatchingItemsByKeywords(substring.Trim(), inventoryKeywords, 
                            player.CarriedItems, new List<WeaponItem>{ player.WeaponItem });
                        if (foundItem != null)
                        {
                            inputResolved = InventoryHandler.HandleItemBeingUsed(player, foundItem, inputWord);
                        }
                        break;
                    case "item":
                    case "items":
                        var items = StringDescriptionBuilder.CreateStringOfItemDescriptions(player, currentRoom.RoomItems.InventoryItems);
                        Console.WriteLine();
                        TypingAnimation.Animate(items == "" ? ConsoleStrings.NoItemsFound : items, Color.Aquamarine);
                        inputResolved = true;
                        break;
                    case "weapon":
                    case "weapons":
                        var weapons = StringDescriptionBuilder.CreateStringOfWeaponDescriptions(player, currentRoom.RoomItems.WeaponItems);
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
                        var exits = StringDescriptionBuilder.CreateStringOfExitDescriptions(player, currentRoom.AvailableExits);
                        Console.WriteLine();
                        TypingAnimation.Animate(exits, Color.Red);
                        inputResolved = true;
                        break;
                    case "inventory":
                    case "inv":
                    case "carried":
                    case "carrying":
                    case "pockets":
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
                        Console.ReplaceAllColorsWithDefaults();
                        Console.WriteLineStyled(ConsoleStrings.GameHelp, ConsoleStringStyleSheets.GameHelpStyleSheet(Color.MediumPurple));
                        inputResolved = true;
                        break;
                    case "helpoff":
                    case "helpon":
                        player.ShowInputHelp = !player.ShowInputHelp;
                        Console.WriteLine(
                            player.ShowInputHelp ? "\nInput words shown above prompt text." : "\nInput words hidden from prompt text.",
                            Color.MediumPurple);
                        Console.WriteLine();
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

        // This returns a substring of remaining words in a player input that followed the first word
        public static string CreateSubstringOfActionInput(string input, string inputWord)
        {
            var matchingWordLength = inputWord.Length + 1;
            if (matchingWordLength > input.Length)
            {
                return "";
            }
            var keyword = inputWord.IndexOf(inputWord, StringComparison.OrdinalIgnoreCase);
            var substring = input.Substring(keyword + matchingWordLength);
            return substring;
        }
    }
}