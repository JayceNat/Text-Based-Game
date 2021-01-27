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
                    // We wouldn't normally use so many fall-throughs in an application...
                    // But for a text based game it's really handy for supporting many inputs.
                    // We don't want the user to try a word that should work and get frustrated.
                    case "pickup":
                    case "pick":
                    case "grab":
                    case "get":
                    case "take":
                    case "collect":
                    case "gather":
                        player.PersistDisplayedItems = false;
                        player.PersistDisplayedWeapons = false;
                        player.PersistDisplayedExits = false;
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
                        player.PersistDisplayedItems = false;
                        player.PersistDisplayedWeapons = false;
                        player.PersistDisplayedExits = false;
                        inventoryKeywords = InventoryHandler.GetAllInventoryItemKeywords(player);
                        substring = CreateSubstringOfActionInput(fullInput, inputWord);
                        foundItem = InventoryHandler.FindAnyMatchingItemsByKeywords(substring.Trim(), inventoryKeywords,
                            player.CarriedItems, new List<WeaponItem> { player.WeaponItem });
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
                        player.PersistDisplayedItems = false;
                        player.PersistDisplayedWeapons = false;
                        player.PersistDisplayedExits = false;
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
                    case "speak":
                    case "chat":
                    case "say":
                    case "ask":
                    case "tell":
                        player.PersistDisplayedItems = false;
                        player.PersistDisplayedWeapons = false;
                        player.PersistDisplayedExits = false;
                        if (currentRoom.RoomCharacters.Any())
                        {
                            substring = CreateSubstringOfActionInput(fullInput, inputWord);
                            var character = RoomHandler.FindAnyMatchingCharacterByKeywords(substring.Trim(), currentRoom);
                            if (character != null)
                            {
                                var characterResponse = GetCharacterResponse(character);
                                Console.WriteLine();
                                Console.WriteLine(characterResponse + "\n", Color.Gold);
                                inputResolved = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nThere is no one here to talk to...", Color.DarkOliveGreen);
                            inputResolved = true;
                        }
                        break;
                    case "give":
                    case "trade":
                    case "offer":
                    case "hand":
                    case "toss":
                        player.PersistDisplayedItems = false;
                        player.PersistDisplayedWeapons = false;
                        player.PersistDisplayedExits = false;
                        inputResolved = 
                            InventoryHandler.HandlePlayerTradingItem(fullInput, player, currentRoom, inputWord, inputResolved);
                        break;
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
                        player.PersistDisplayedItems = false;
                        player.PersistDisplayedWeapons = false;
                        player.PersistDisplayedExits = false;
                        inventoryKeywords = InventoryHandler.GetAllInventoryItemKeywords(player);
                        substring = CreateSubstringOfActionInput(fullInput, inputWord);
                        foundItem = InventoryHandler.FindAnyMatchingItemsByKeywords(substring.Trim(), inventoryKeywords,
                            player.CarriedItems, new List<WeaponItem> { player.WeaponItem });
                        if (foundItem != null)
                        {
                            inputResolved = InventoryHandler.HandleItemBeingUsed(player, foundItem, inputWord);
                        }
                        break;
                    case "item":
                    case "items":
                        player.PersistDisplayedItems = true;
                        player.PersistDisplayedWeapons = false;
                        player.PersistDisplayedExits = false;
                        inputResolved = true;
                        break;
                    case "weapon":
                    case "weapons":
                        player.PersistDisplayedItems = false;
                        player.PersistDisplayedWeapons = true;
                        player.PersistDisplayedExits = false;
                        inputResolved = true;
                        break;
                    case "exit":
                    case "exits":
                    case "leave":
                    case "door":
                    case "doors":
                    case "out":
                    case "where":
                        player.PersistDisplayedItems = false;
                        player.PersistDisplayedWeapons = false;
                        player.PersistDisplayedExits = true;
                        inputResolved = true;
                        break;
                    case "inventory":
                    case "inv":
                    case "carried":
                    case "carrying":
                    case "pockets":
                        player.PersistDisplayedItems = false;
                        player.PersistDisplayedWeapons = false;
                        player.PersistDisplayedExits = false;
                        var playerInventory = StringDescriptionBuilder.CreateStringOfPlayerInventory(player, true);
                        Console.WriteLine();
                        Console.WriteLine(playerInventory, Color.ForestGreen);
                        inputResolved = true;
                        break;
                    case "character":
                    case "status":
                    case "stat":
                    case "stats":
                        player.PersistDisplayedItems = false;
                        player.PersistDisplayedWeapons = false;
                        player.PersistDisplayedExits = false;
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
                        player.PersistDisplayedItems = false;
                        player.PersistDisplayedWeapons = false;
                        player.PersistDisplayedExits = false;
                        Console.ReplaceAllColorsWithDefaults();
                        Console.WriteLineStyled(ConsoleStrings.GameHelp, ConsoleStringStyleSheets.GameHelpStyleSheet(Color.MediumPurple));
                        inputResolved = true;
                        break;
                    case "helpoff":
                    case "helpon":
                        player.PersistDisplayedItems = false;
                        player.PersistDisplayedWeapons = false;
                        player.PersistDisplayedExits = false;
                        player.ShowInputHelp = !player.ShowInputHelp;
                        Console.WriteLine(
                            player.ShowInputHelp ? "\nInput words shown above prompt text." : "\nInput words hidden from prompt text.",
                            Color.MediumPurple);
                        Console.WriteLine();
                        inputResolved = true;
                        break;
                    case "save":
                        // This isn't really necessary, I just liked the idea of the user having to complete the tutorial first
                        if (currentRoom.RoomName == "Your Bedroom")
                        {
                            Console.WriteLine($"\nYou need to leave {currentRoom.RoomName} before you can save.", Color.DarkOrange);
                            inputResolved = true;
                            break;
                        }
                        Console.WriteLine("\nSave the game and close? (y/n)", Color.White);
                        Console.WriteLine("Note - This will overwrite any current save file!", Color.White);
                        Console.Write(">", Color.White);
                        var response = Console.ReadLine();
                        if (!string.IsNullOrEmpty(response) && response.ToLower()[0].Equals('y'))
                        {
                            return new Room.Models.Room
                            {
                                RoomName = ConsoleStrings.SaveGame
                            };
                        }
                        Console.WriteLine("\nSave cancelled.", Color.White);
                        inputResolved = true;
                        break;
                }
            }

            // We don't know what the user is trying to do at this point
            if (!inputResolved)
            {
                Console.WriteLine();
                TypingAnimation.Animate("You " + fullInput + "...", Color.Chartreuse, 40);
                TypingAnimation.Animate(". . . Nothing happens. \n", Color.Chartreuse, 40);
            }

            // Keeps the Item, Weapon, or Exit descriptions displayed for easier play
            if (!player.PersistDisplayedItems && !player.PersistDisplayedWeapons && !player.PersistDisplayedExits)
            {
                Console.WriteWithGradient(ConsoleStrings.PressEnterPrompt, Color.Yellow, Color.DarkRed, 4);
                Console.ReadLine();
            }
            
            Console.Clear();
            Console.ReplaceAllColorsWithDefaults();

            return null;
        }

        public static void PrintItemsToConsole(Models.Character player, Room.Models.Room currentRoom, bool animate = true)
        {
            var items = StringDescriptionBuilder.CreateStringOfItemDescriptions(player, currentRoom.RoomItems.InventoryItems);

            if (animate)
            {
                Console.WriteLine();
                TypingAnimation.Animate(items == "" ? ConsoleStrings.NoItemsFound + "\n" : items, Color.Aquamarine);
            }
            else
            {
                Console.WriteLine(items == "" ? ConsoleStrings.NoItemsFound + "\n" : items, Color.Aquamarine);
            }
        }

        public static void PrintWeaponsToConsole(Models.Character player, Room.Models.Room currentRoom, bool animate = true)
        {
            var weapons = StringDescriptionBuilder.CreateStringOfWeaponDescriptions(player, currentRoom.RoomItems.WeaponItems);
            
            if (animate)
            {
                Console.WriteLine();
                TypingAnimation.Animate(weapons == "" ? ConsoleStrings.NoWeaponsFound + "\n" : weapons, Color.Aquamarine);
            }
            else
            {
                Console.WriteLine(weapons == "" ? ConsoleStrings.NoWeaponsFound + "\n" : weapons, Color.Aquamarine);
            }
        }

        public static void PrintExitsToConsole(Models.Character player, Room.Models.Room currentRoom, bool animate = true)
        {
            var exits = StringDescriptionBuilder.CreateStringOfExitDescriptions(player, currentRoom.AvailableExits);

            if (animate)
            {
                Console.WriteLine();
                TypingAnimation.Animate(exits, Color.Red);
            }
            else
            {
                Console.WriteLine(exits, Color.Red);
            }
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

        private static string GetCharacterResponse(Models.Character foundCharacter)
        {
            var random = new Random();
            int randomIndex;
            if (string.IsNullOrEmpty(foundCharacter?.DesiredItem?.ItemName))
            {
                randomIndex = random.Next(0, foundCharacter.CharacterAppeasedPhrases.Count);
                return foundCharacter.CharacterAppeasedPhrases[randomIndex];
            }

            randomIndex = random.Next(0, foundCharacter.CharacterPhrases.Count);
            return foundCharacter.CharacterPhrases[randomIndex];
        }
    }
}