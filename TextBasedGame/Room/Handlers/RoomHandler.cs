using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using Colorful;
using TextBasedGame.Character.Handlers;
using TextBasedGame.Shared.Constants;
using TextBasedGame.Shared.Utilities;

namespace TextBasedGame.Room.Handlers
{
    public class RoomHandler
    {
        public static Models.Room EnterRoom(Character.Models.Character player, Models.Room room, bool firstRoomEntered = false)
        {
            var redisplayRoomDesc = false;

            while (true)
            {
                Console.Clear();
                Console.ReplaceAllColorsWithDefaults();

                if (redisplayRoomDesc)
                {
                    Console.WriteLine(room.RoomEntered ? room.GenericRoomDescription : room.InitialRoomDescription,
                        Color.Bisque);
                }
                else
                {
                    TypingAnimation.Animate(room.RoomEntered ? room.GenericRoomDescription : room.InitialRoomDescription,
                        Color.Bisque, 30);
                }

                Thread.Sleep(50);
                Console.WriteLine();

                if (firstRoomEntered)
                {
                    Console.WriteLine(ConsoleStrings.FirstRoomHelpHint, Color.MediumPurple);
                }

                Console.WriteWithGradient(ConsoleStrings.PlayerInputPrompt, Color.SpringGreen, Color.NavajoWhite, 4);
                Console.WriteLine();
                Console.Write("> ");
                var playerInput = Console.ReadLine();
                var nextRoom = PlayerActionHandler.HandlePlayerInput(playerInput.ToLower(), player, room);
                if (nextRoom == null)
                {
                    redisplayRoomDesc = true;
                }

                else
                {
                    return nextRoom;
                }
            }
        }

        public static Models.Room FindAnyMatchingRoomByKeywords(string inputSubstring, Models.Room currentRoom)
        {
            var inputWords = inputSubstring.Split(ConsoleStrings.StringDelimiters);
            foreach (var word in inputWords)
            {
                if (currentRoom.AvailableExits.NorthRoom?.KeywordsToEnter.Contains(word) != null)
                {
                    return currentRoom.AvailableExits.NorthRoom;
                }

                if (currentRoom.AvailableExits.EastRoom?.KeywordsToEnter.Contains(word) != null)
                {
                    return currentRoom.AvailableExits.EastRoom;
                }

                if (currentRoom.AvailableExits.SouthRoom?.KeywordsToEnter.Contains(word) != null)
                {
                    return currentRoom.AvailableExits.SouthRoom;
                }

                if (currentRoom.AvailableExits.WestRoom?.KeywordsToEnter.Contains(word) != null)
                {
                    return currentRoom.AvailableExits.WestRoom;
                }
            }

            return null;
        }

        public static List<string> GetAllRoomItemKeywords(Models.Room currentRoom)
        {
            IEnumerable<string> itemKeywords = new List<string>();
            IEnumerable<string> weaponKeywords = new List<string>();
            var keywords = new List<string>();

            if (currentRoom.RoomItems?.InventoryItems != null)
            {
                foreach (var item in currentRoom.RoomItems.InventoryItems)
                {
                    itemKeywords = (item.KeywordsForPickup.Where(k => !string.IsNullOrEmpty(k)));
                }
            }

            if (currentRoom.RoomItems?.WeaponItems != null)
            {
                foreach (var weapon in currentRoom.RoomItems.WeaponItems)
                {
                    weaponKeywords = weapon.KeywordsForPickup.Where(k => !string.IsNullOrEmpty(k));
                }
            }

            keywords.AddRange(itemKeywords);
            keywords.AddRange(weaponKeywords);
            return keywords;
        }
    }
}