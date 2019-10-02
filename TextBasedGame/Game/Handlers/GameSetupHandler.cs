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
            //TypingAnimation.Animate(ConsoleStrings.GameIntro, Color.DarkTurquoise);
            Console.WriteWithGradient(ConsoleStrings.PressEnterPrompt, Color.Yellow, Color.DarkRed, 4);
            Console.ReadLine();
        }

        public static void BeginAdventure(Character.Models.Character player, Room.Models.Room room)
        {
            DisplayGameIntro();
            TheAdventure(player, room, true);
        }

        // This is the main game loop, and only stops when the player enters a 'null' room
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
                else if (currentRoom.RoomName == ConsoleStrings.SaveGame)
                {
                    SaveGame();
                }
            }
        }

        public static void SaveGame()
        {
            // Serialize all objects to save the game state
            Program.RoomCreator.RemoveExitsFromAllRooms();
            using (var xmlWriter = XmlWriter.Create("TheHaunting_SavedGame.xml", new XmlWriterSettings { Indent = true }))
            {
                xmlWriter.WriteStartElement("root");

                Program.GameTitleSerializer.Serialize(xmlWriter, Program.GameTitle);

                Program.CharacterSerializer.Serialize(xmlWriter, Program.CharacterCreator.Player);
                Program.CharacterSerializer.Serialize(xmlWriter, Program.CharacterCreator.Ghoul);

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
                Console.WriteLine("A save file was found, would you like to load it? (y/n)", Color.DarkOrange);
                Console.Write(">", Color.DarkOrange);
                var response = System.Console.ReadLine();
                if (string.IsNullOrEmpty(response) || response?.ToLower()[0] == 'y')
                {
                    try
                    {
                        using (var reader = XmlReader.Create(saveFile))
                        {
                            // Skip root node
                            reader.ReadToFollowing("Character"); // Name of first class

//                            Program.GameTitle = (GameTitle) gameTitleSerializer.Deserialize(reader);

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
    }
}