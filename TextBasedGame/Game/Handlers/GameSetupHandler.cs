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
            Console.WriteLine("\t\t-- Written by " + gameTitle.Author + "--", gameTitle.AuthorTextColor);
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

                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.ForestLake);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.ForestLakeTent);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.EastForest);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.EastForestLowerClearing);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.EastForestUpperClearing);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.DeepEastForest);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.DeepEastForestLowerRiver);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.DeepEastForestUpperRiver);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.DeepEastForestUpperRiverCave);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.EastForestCampground);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.PathBetweenCampAndEastRoad);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.EastRoadToTown);

                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.TownSouthEntrance);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.TownNorthEntrance);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.TownEastEntrance);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.TownWestEntrance);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.AshburySouthSquare);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.AshburyNorthSquare);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.AshburyEastSquare);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.AshburyWestSquare);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.AshburySouthMainStreet);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.AshburyNorthMainStreet);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.AshburyEastPlaza);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.AshburyWestPlaza);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.AshburyTownCenter);
                // South Side
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.AshburySouthSquareEastAlley);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.AshburySouthEastVeterinaryClinic);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.AshburySouthEastCornerLot);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.AshburySouthEastDurrowHouse);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.AshburySouthEastAviary);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.AshburySouthEastWell);
                Program.RoomSerializer.Serialize(xmlWriter, Program.RoomCreator.AshburySouthSquareWestAlley);
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

                            // Characters
                            Program.CharacterCreator.Player = (Character.Models.Character)Program.CharacterSerializer.Deserialize(reader);
                            Program.CharacterCreator.Ghoul = (Character.Models.Character)Program.CharacterSerializer.Deserialize(reader);

                            // Rooms
                            Program.RoomCreator.YourBedroom = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.YourLivingRoom = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.YourKitchen = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.YourBasement = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.YourFrontEntryway = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.YourFrontPorch = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.YourShed = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.YourDriveway = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.RoadConnectingYourHouseToTown = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);

                            Program.RoomCreator.ForestLake = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.ForestLakeTent = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.EastForest = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.EastForestLowerClearing = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.EastForestUpperClearing = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.DeepEastForest = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.DeepEastForestLowerRiver = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.DeepEastForestUpperRiver = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.DeepEastForestUpperRiverCave = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.EastForestCampground = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.PathBetweenCampAndEastRoad = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.EastRoadToTown = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);

                            Program.RoomCreator.TownSouthEntrance = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.TownNorthEntrance = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.TownEastEntrance = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.TownWestEntrance = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.AshburySouthSquare = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.AshburyNorthSquare = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.AshburyEastSquare = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.AshburyWestSquare = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.AshburySouthMainStreet = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.AshburyNorthMainStreet = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.AshburyEastPlaza = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.AshburyWestPlaza = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.AshburyTownCenter = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            // South Side
                            Program.RoomCreator.AshburySouthSquareEastAlley = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.AshburySouthEastVeterinaryClinic = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.AshburySouthEastCornerLot = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.AshburySouthEastDurrowHouse = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.AshburySouthEastAviary = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.AshburySouthEastWell = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
                            Program.RoomCreator.AshburySouthSquareWestAlley = (Room.Models.Room)Program.RoomSerializer.Deserialize(reader);
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
                        Environment.Exit(0);
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
            // Your House
            #region Your House

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

            #endregion

            // Forest
            #region Forest

            if (playerCurrentLocation == Program.RoomCreator.ForestLake.RoomName)
            {
                return Program.RoomCreator.ForestLake;
            }

            if (playerCurrentLocation == Program.RoomCreator.ForestLakeTent.RoomName)
            {
                return Program.RoomCreator.ForestLakeTent;
            }

            if (playerCurrentLocation == Program.RoomCreator.EastForest.RoomName)
            {
                return Program.RoomCreator.EastForest;
            }

            if (playerCurrentLocation == Program.RoomCreator.EastForestLowerClearing.RoomName)
            {
                return Program.RoomCreator.EastForestLowerClearing;
            }

            if (playerCurrentLocation == Program.RoomCreator.EastForestUpperClearing.RoomName)
            {
                return Program.RoomCreator.EastForestUpperClearing;
            }

            if (playerCurrentLocation == Program.RoomCreator.DeepEastForest.RoomName)
            {
                return Program.RoomCreator.DeepEastForest;
            }

            if (playerCurrentLocation == Program.RoomCreator.DeepEastForestLowerRiver.RoomName)
            {
                return Program.RoomCreator.DeepEastForestLowerRiver;
            }

            if (playerCurrentLocation == Program.RoomCreator.DeepEastForestUpperRiver.RoomName)
            {
                return Program.RoomCreator.DeepEastForestUpperRiver;
            }

            if (playerCurrentLocation == Program.RoomCreator.DeepEastForestUpperRiverCave.RoomName)
            {
                return Program.RoomCreator.DeepEastForestUpperRiverCave;
            }

            if (playerCurrentLocation == Program.RoomCreator.EastForestCampground.RoomName)
            {
                return Program.RoomCreator.EastForestCampground;
            }

            if (playerCurrentLocation == Program.RoomCreator.PathBetweenCampAndEastRoad.RoomName)
            {
                return Program.RoomCreator.PathBetweenCampAndEastRoad;
            }

            if (playerCurrentLocation == Program.RoomCreator.EastRoadToTown.RoomName)
            {
                return Program.RoomCreator.EastRoadToTown;
            }

            #endregion

            // Town
            #region Town

            if (playerCurrentLocation == Program.RoomCreator.TownSouthEntrance.RoomName)
            {
                return Program.RoomCreator.TownSouthEntrance;
            }

            if (playerCurrentLocation == Program.RoomCreator.TownNorthEntrance.RoomName)
            {
                return Program.RoomCreator.TownNorthEntrance;
            }

            if (playerCurrentLocation == Program.RoomCreator.TownEastEntrance.RoomName)
            {
                return Program.RoomCreator.TownEastEntrance;
            }

            if (playerCurrentLocation == Program.RoomCreator.TownWestEntrance.RoomName)
            {
                return Program.RoomCreator.TownWestEntrance;
            }

            if (playerCurrentLocation == Program.RoomCreator.AshburySouthSquare.RoomName)
            {
                return Program.RoomCreator.AshburySouthSquare;
            }

            if (playerCurrentLocation == Program.RoomCreator.AshburyNorthSquare.RoomName)
            {
                return Program.RoomCreator.AshburyNorthSquare;
            }

            if (playerCurrentLocation == Program.RoomCreator.AshburyEastSquare.RoomName)
            {
                return Program.RoomCreator.AshburyEastSquare;
            }

            if (playerCurrentLocation == Program.RoomCreator.AshburyWestSquare.RoomName)
            {
                return Program.RoomCreator.AshburyWestSquare;
            }

            if (playerCurrentLocation == Program.RoomCreator.AshburySouthMainStreet.RoomName)
            {
                return Program.RoomCreator.AshburySouthMainStreet;
            }

            if (playerCurrentLocation == Program.RoomCreator.AshburyNorthMainStreet.RoomName)
            {
                return Program.RoomCreator.AshburyNorthMainStreet;
            }

            if (playerCurrentLocation == Program.RoomCreator.AshburyEastPlaza.RoomName)
            {
                return Program.RoomCreator.AshburyEastPlaza;
            }

            if (playerCurrentLocation == Program.RoomCreator.AshburyWestPlaza.RoomName)
            {
                return Program.RoomCreator.AshburyWestPlaza;
            }

            if (playerCurrentLocation == Program.RoomCreator.AshburyTownCenter.RoomName)
            {
                return Program.RoomCreator.AshburyTownCenter;
            }

            //************** SOUTH SIDE **************

            if (playerCurrentLocation == Program.RoomCreator.AshburySouthSquareEastAlley.RoomName)
            {
                return Program.RoomCreator.AshburySouthSquareEastAlley;
            }

            if (playerCurrentLocation == Program.RoomCreator.AshburySouthEastVeterinaryClinic.RoomName)
            {
                return Program.RoomCreator.AshburySouthEastVeterinaryClinic;
            }

            if (playerCurrentLocation == Program.RoomCreator.AshburySouthEastCornerLot.RoomName)
            {
                return Program.RoomCreator.AshburySouthEastCornerLot;
            }

            if (playerCurrentLocation == Program.RoomCreator.AshburySouthEastDurrowHouse.RoomName)
            {
                return Program.RoomCreator.AshburySouthEastDurrowHouse;
            }

            if (playerCurrentLocation == Program.RoomCreator.AshburySouthEastAviary.RoomName)
            {
                return Program.RoomCreator.AshburySouthEastAviary;
            }

            if (playerCurrentLocation == Program.RoomCreator.AshburySouthEastWell.RoomName)
            {
                return Program.RoomCreator.AshburySouthEastWell;
            }

            if (playerCurrentLocation == Program.RoomCreator.AshburySouthSquareWestAlley.RoomName)
            {
                return Program.RoomCreator.AshburySouthSquareWestAlley;
            }

            #endregion

            return Program.RoomCreator.YourBedroom;
        }
    }
}