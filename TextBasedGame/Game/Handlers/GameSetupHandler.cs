using System;
using System.Drawing;
using System.IO;
using System.Xml;
using Colorful;
using TextBasedGame.Game.Models;
using TextBasedGame.Room.Handlers;
using TextBasedGame.Shared.Constants;
using TextBasedGame.Shared.Utilities;
using Console = Colorful.Console;

namespace TextBasedGame.Game.Handlers
{
    public class GameSetupHandler
    {
        public static void DisplayGameTitle(GameTitle gameTitle)
        {
            var font = FigletFont.Default;
            var figlet = new Figlet(font);

            Console.ReplaceAllColorsWithDefaults();
            Console.WriteLine(figlet.ToAscii(gameTitle.Title), gameTitle.TitleTextColor);
            Console.WriteLine();
            Console.WriteLine("\t-- Written by " + gameTitle.Author + "--", gameTitle.AuthorTextColor);
            Console.WriteLine("\n\n");
            Console.WriteWithGradient(ConsoleStrings.PressEnterPrompt, Color.Yellow, Color.DarkRed, 4);
            Console.ReadLine();
            Console.ReplaceAllColorsWithDefaults();
            Console.Clear();
        }

        // This displays after the user assigns their traits and begins the game
        public static void DisplayGameIntro()
        {
            Console.ReplaceAllColorsWithDefaults();

            var enterKeyPressed = false;
            var r = 255;
            var g = 255;
            var b = 255;
            foreach (var line in ConsoleStrings.GameIntro)
            {
                if (enterKeyPressed)
                {
                    Console.WriteLine(line, Color.FromArgb(r, g, b));
                }
                else
                {
                    enterKeyPressed = TypingAnimation.Animate(line, Color.FromArgb(r, g, b));
                }

                g -= 25;
                b -= 25;
            }
            
            Console.WriteWithGradient(ConsoleStrings.PressEnterPrompt, Color.Yellow, Color.DarkRed, 4);
            Console.ReadLine();
        }

        // Kind of a goofy method... but allows us to skip displaying the intro if we need to
        public static void BeginAdventure(Character.Models.Character player, Room.Models.Room room)
        {
            DisplayGameIntro();
            TheAdventure(player, room, true);
        }

        // This is the main game loop, and only stops when the player goes into a 'null' room (or saves)
        public static void TheAdventure(Character.Models.Character player, Room.Models.Room room, bool firstRoomEntered)
        {
            var firstRoom = firstRoomEntered;
            var currentRoom = room;
            while (true)
            {
                currentRoom = RoomHandler.EnterRoom(player, currentRoom, firstRoom);
                firstRoom = false;
                if (currentRoom == null)
                {
                    break;
                }

                if (currentRoom.RoomName == ConsoleStrings.SaveGame)
                {
                    SaveGame();
                    break;
                }
            }
        }

        // Serialize all objects to save the game state
        public static void SaveGame()
        {
            // This is needed to prevent a circular dependency (our roomExits are Room Models which have roomExits which are Room Models...)
            Program.RoomCreator.RemoveExitsFromAllRooms();
            
            // This will create a file in the same directory as the .exe since we didn't specify a path
            using (var xmlWriter = XmlWriter.Create("TheHaunting_SavedGame.xml", new XmlWriterSettings { Indent = true }))
            {
                xmlWriter.WriteStartElement("root");

                // We only need to serialize the biggest objects; all the other ones are children of them

                // Characters
                Program.CharacterSerializer.Serialize(xmlWriter, Program.CharacterCreator.Player);
                Program.CharacterSerializer.Serialize(xmlWriter, Program.CharacterCreator.Ghoul);
                // Rooms
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.YourBedroom);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.YourLivingRoom);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.YourKitchen);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.YourBasement);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.YourFrontEntryway);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.YourFrontPorch);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.YourShed);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.YourDriveway);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.RoadConnectingYourHouseToTown);
            }
        }

        public static bool TryLoadGame()
        {
            const string saveFile = "TheHaunting_SavedGame.xml";
            if (File.Exists(saveFile) && File.ReadAllText(saveFile).Length != 0)
            {
                TypingAnimation.Animate("A save file was found, would you like to load it? (y/n)", Color.DarkOrange);
                Console.Write(">", Color.DarkOrange);
                var response = System.Console.ReadLine();
                if (string.IsNullOrEmpty(response) || response?.ToLower()[0] == 'y')
                {
                    try
                    {
                        using (var reader = XmlReader.Create(saveFile))
                        {
                            // Skip root node
                            reader.ReadToFollowing("C"); // Name of first class, we serialize Character as "C" for XML sneakiness :)

                            Program.CharacterCreator.Player = (Character.Models.Character)Program.CharacterSerializer.Deserialize(reader);
                            Program.CharacterCreator.Ghoul = (Character.Models.Character)Program.CharacterSerializer.Deserialize(reader);

                            Program.RoomCreator.YourBedroom = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.YourLivingRoom = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.YourKitchen = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.YourBasement = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.YourFrontEntryway = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.YourFrontPorch = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.YourShed = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.YourDriveway = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.RoadConnectingYourHouseToTown = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                        }

                        Console.Clear();
                        // Important that we add all the room exits back to the rooms, or we can't go anywhere!
                        Program.RoomCreator.AddExitsToAllRooms();
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.Write("\nSomething went wrong loading the file :( ...", Color.Red);
                        Console.ReadLine();
                        Console.Clear();
                        return false;
                    }
                }
            }

            Console.Clear();
            return false;
        }

        // This method is needed in order to place the player in the proper room object after the exits have been re-added,
        // otherwise we would place the player in a room object with no exits 
        public static Room.Models.Room GetCurrentRoomFromRoomName(string playerCurrentLocation)
        {
            if (playerCurrentLocation == Program.RoomCreator.YourBedroom.RoomName)
            {
                return Program.RoomCreator.YourBedroom;
            }

            if (playerCurrentLocation == Program.RoomCreator.YourLivingRoom.RoomName)
            {
                return Program.RoomCreator.YourLivingRoom;
            }

            if (playerCurrentLocation == Program.RoomCreator.YourKitchen.RoomName)
            {
                return Program.RoomCreator.YourKitchen;
            }

            if (playerCurrentLocation == Program.RoomCreator.YourBasement.RoomName)
            {
                return Program.RoomCreator.YourBasement;
            }

            if (playerCurrentLocation == Program.RoomCreator.YourFrontEntryway.RoomName)
            {
                return Program.RoomCreator.YourFrontEntryway;
            }

            if (playerCurrentLocation == Program.RoomCreator.YourFrontPorch.RoomName)
            {
                return Program.RoomCreator.YourFrontPorch;
            }

            if (playerCurrentLocation == Program.RoomCreator.YourShed.RoomName)
            {
                return Program.RoomCreator.YourShed;
            }

            if (playerCurrentLocation == Program.RoomCreator.YourDriveway.RoomName)
            {
                return Program.RoomCreator.YourDriveway;
            }

            if (playerCurrentLocation == Program.RoomCreator.RoadConnectingYourHouseToTown.RoomName)
            {
                return Program.RoomCreator.RoadConnectingYourHouseToTown;
            }

            return Program.RoomCreator.YourBedroom;
        }
    }
}