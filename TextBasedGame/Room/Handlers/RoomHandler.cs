using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using Colorful;
using TextBasedGame.Character.Handlers;
using TextBasedGame.Room.Constants;
using TextBasedGame.Shared.Constants;
using TextBasedGame.Shared.Models;
using TextBasedGame.Shared.Utilities;

namespace TextBasedGame.Room.Handlers
{
    public class RoomHandler
    {
        // This is the logic for prompting the user for input continuously
        // until the user enters keywords to get to another room.
        // (Calls into a separate method to act on the input)
        public static Models.Room EnterRoom(Character.Models.Character player, Models.Room room, bool firstRoomEntered = false)
        {
            var redisplayRoomDesc = false;
            Models.Room nextRoom = null;
            Program.CharacterCreator.Player.CurrentRoomName = room.RoomName;
            
            while (nextRoom == null)
            {
                Console.Clear();
                Console.ReplaceAllColorsWithDefaults();

                // Print out the current Room description to the console (animate the first time)
                if (redisplayRoomDesc)
                {
                    Console.WriteLine(room.RoomEntered ? room.GenericRoomDescription : room.InitialRoomDescription,
                        Color.Bisque);

                    if (player.PersistDisplayedItems)
                    {
                        PlayerActionHandler.PrintItemsToConsole(player, room);
                    }

                    else if (player.PersistDisplayedWeapons)
                    {
                        PlayerActionHandler.PrintWeaponsToConsole(player, room);
                    }

                    else if (player.PersistDisplayedExits)
                    {
                        PlayerActionHandler.PrintExitsToConsole(player, room);
                    }

                    else
                    {
                        Console.WriteLine();
                    }
                }
                else
                {
                    TypingAnimation.Animate(room.RoomEntered ? room.GenericRoomDescription : room.InitialRoomDescription,
                        Color.Bisque);
                    Console.WriteLine();
                }

                Thread.Sleep(50);

                if (firstRoomEntered)
                {
                    Console.Write("TUTORIAL: ", Color.MediumPurple);

                    if (player.CarriedItems.Count == 0 || string.IsNullOrEmpty(player.WeaponItem.WeaponName))
                    {
                        Console.WriteLine("Collect the item and weapon in this room\n", Color.Aquamarine);
                        Console.WriteLineStyled(ConsoleStrings.ItemsHints, ConsoleStringStyleSheets.GameHelpStyleSheet(Color.AliceBlue));
                        Console.WriteLineStyled(ConsoleStrings.InfoHints, ConsoleStringStyleSheets.GameHelpStyleSheet(Color.AliceBlue));
                    }
                    else
                    {
                        Console.WriteLine("Exit this room\n", Color.Red);
                        Console.WriteLineStyled(ConsoleStrings.RoomHints, ConsoleStringStyleSheets.GameHelpStyleSheet(Color.AliceBlue));
                    }

                    Console.WriteLine(ConsoleStrings.FirstRoomHelpHint, Color.MediumPurple);
                }
                if (player.ShowInputHelp && !firstRoomEntered)
                {
                    Console.WriteLineStyled(ConsoleStrings.InputHelper, RoomStyleSheets.InputHelperStyleSheet());
                }

                Console.WriteWithGradient(ConsoleStrings.PlayerInputPrompt, Color.SpringGreen, Color.NavajoWhite, 4);
                Console.WriteLine();
                Console.Write("> ");
                var playerInput = Console.ReadLine();
                nextRoom = PlayerActionHandler.HandlePlayerInput(playerInput.ToLower(), player, room);

                redisplayRoomDesc = true;
            }

            return nextRoom;
        }

        public static bool DoesPlayerMeetRequirementsToEnter(Character.Models.Character player, Models.Room currentRoom, Models.Room foundRoom)
        {
            Console.WriteLine();
            var meetsRequirements = foundRoom?.AttributeRequirementToEnter == null && foundRoom?.ItemRequirementToEnter == null;
            if (!meetsRequirements)
            {
                if (foundRoom?.AttributeRequirementToEnter != null 
                    && CanPlayerEnterRoom(player, foundRoom, attrReq: foundRoom.AttributeRequirementToEnter))
                {
                    Console.WriteLine($"<{foundRoom.AttributeRequirementToEnter.RequirementName}>! \n", Color.Gold);
                    meetsRequirements = true;
                }

                if (foundRoom?.ItemRequirementToEnter != null
                    && CanPlayerEnterRoom(player, foundRoom, foundRoom.ItemRequirementToEnter))
                {
                    if (foundRoom.ItemRequirementToEnter.RelevantItem == Program.ItemCreator.Flashlight && Program.ItemCreator.Flashlight.ItemTraits.First().TraitValue == 0)
                    {
                        Console.WriteLine($"It's too dark. Your flashlight battery is dead... \nPut in a new battery to enter {foundRoom.RoomName}.\n", Color.DarkGoldenrod);
                        return false;
                    }
                    Console.WriteLine($"Carrying: <{foundRoom.ItemRequirementToEnter.RequirementName}>! \n", Color.Gold);
                    meetsRequirements = true;
                }
            }

            if (meetsRequirements)
            {
                TypingAnimation.Animate("You go to " + foundRoom.RoomName + "... \n", Color.Chartreuse, 40);

                if (foundRoom.ItemRequirementToEnter?.RelevantItem == Program.ItemCreator.Flashlight)
                {
                    var light = Program.ItemCreator.Flashlight;
                    var batteryBefore = light.ItemTraits.First().TraitValue;
                    FlashlightBatteryUpdate.FlashlightBatteryChange(light, batteryBefore, 2);
                    TypingAnimation.Animate("Used Flashlight: battery dropped by 2 \n", Color.Chartreuse, 40);
                }

                Console.WriteWithGradient(ConsoleStrings.PressEnterPrompt, Color.Yellow, Color.DarkRed, 4);
                Console.ReadLine();
                if (!currentRoom.RoomEntered)
                {
                    currentRoom.RoomEntered = true;
                }

                foundRoom.AttributeRequirementToEnter = null;
                foundRoom.AttributeRequirementToSee = null;
                foundRoom.ItemRequirementToEnter = null;
                foundRoom.ItemRequirementToSee = null;
            }

            return meetsRequirements;
        }

        private static bool CanPlayerEnterRoom(Character.Models.Character player, Models.Room foundRoom, ItemRequirement itemReq = null, AttributeRequirement attrReq = null)
        {
            if (itemReq != null)
            {
                foreach (var item in player.CarriedItems)
                {
                    if (item.ItemName == itemReq.RelevantItem.ItemName)
                    {
                        return true;
                    }
                }

                Console.WriteLine($"You need: <{itemReq.RequirementName}> to enter {foundRoom.RoomName}. \n", Color.DarkGoldenrod);
            }

            if (attrReq != null)
            {
                if (PlayerAttributeComparer.ComparePlayerTraitsToAttributeRequirement(player, attrReq))
                {
                    return true;
                }
                Console.WriteLine($"You need: <{attrReq.RequirementName}> to enter {foundRoom.RoomName}. \n", Color.DarkGoldenrod);
            }

            return false;
        }

        // Returns a Room that matches the players input keyword
        public static Models.Room FindAnyMatchingRoomByKeywords(string inputSubstring, Models.Room currentRoom)
        {
            if (inputSubstring.Length == 0)
            {
                return null;
            }
            var inputWords = inputSubstring.Split(ConsoleStrings.StringDelimiters);
            foreach (var word in inputWords)
            {
                if (currentRoom.AvailableExits.NorthRoom?.KeywordsToEnter != null
                    && (currentRoom.AvailableExits.NorthRoom.KeywordsToEnter.Contains(word) 
                        || word == "forward" || word == "ahead" || word == "north"))
                {
                    return currentRoom.AvailableExits.NorthRoom;
                }

                if (currentRoom.AvailableExits.EastRoom?.KeywordsToEnter != null
                    && (currentRoom.AvailableExits.EastRoom.KeywordsToEnter.Contains(word)
                        || word == "right" || word == "east"))
                {
                    return currentRoom.AvailableExits.EastRoom;
                }

                if (currentRoom.AvailableExits.SouthRoom?.KeywordsToEnter != null
                    && (currentRoom.AvailableExits.SouthRoom.KeywordsToEnter.Contains(word)
                        || word == "behind" || word == "south"))
                {
                    return currentRoom.AvailableExits.SouthRoom;
                }

                if (currentRoom.AvailableExits.WestRoom?.KeywordsToEnter != null
                    && (currentRoom.AvailableExits.WestRoom.KeywordsToEnter.Contains(word)
                        || word == "left" || word == "west"))
                {
                    return currentRoom.AvailableExits.WestRoom;
                }
            }

            return null;
        }

        // Returns an item in a room matching by the users input keyword
        public static List<string> GetAllRoomItemKeywords(Models.Room currentRoom)
        {
            var keywords = new List<string>();

            if (currentRoom.RoomItems?.InventoryItems != null)
            {
                foreach (var item in currentRoom.RoomItems.InventoryItems)
                {
                    keywords.AddRange(item.KeywordsForPickup.Where(k => !string.IsNullOrEmpty(k)));
                }
            }

            if (currentRoom.RoomItems?.WeaponItems != null)
            {
                foreach (var weapon in currentRoom.RoomItems.WeaponItems)
                {
                    keywords.AddRange(weapon.KeywordsForPickup.Where(k => !string.IsNullOrEmpty(k)));
                }
            }

            return keywords;
        }
    }
}