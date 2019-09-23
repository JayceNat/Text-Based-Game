using System.Drawing;
using System.Threading;
using Colorful;
using TextBasedGame.Character.Models;
using TextBasedGame.Constants;
using TextBasedGame.Room.Interfaces;
using TextBasedGame.Room.Models;
using TextBasedGame.Utilities;

namespace TextBasedGame.Handlers
{
    public class RoomActionHandler
    {
        private static readonly IRoom Room = new Room.Implementations.Room();

        public static RoomModel EnterRoom(CharacterModel player, RoomModel room, bool firstRoomEntered = false)
        {
            RoomModel nextRoom = null;
            bool redisplayRoomDesc = false;

            bool roomExited = false;
            while (!roomExited)
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
                        Color.Bisque, 35);
                }

                Thread.Sleep(50);
                Console.WriteLine();
                Console.WriteLine(ConsoleStrings.FirstRoomHelpHint, Color.MediumPurple);
                Console.WriteWithGradient(ConsoleStrings.PlayerInputPrompt, Color.SpringGreen, Color.NavajoWhite, 4);
                Console.WriteLine();
                Console.Write("> ");
                var playerInput = Console.ReadLine();
                var action = PlayerActionHandler.HandlePlayerInput(playerInput.ToLower(), player, room);
                if (action == PlayerInputActions.Redisplay)
                {
                    redisplayRoomDesc = true;
                }
            }

            return nextRoom;
        }
    }
}