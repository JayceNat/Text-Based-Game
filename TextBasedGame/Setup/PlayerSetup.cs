using System.Drawing;
using Colorful;
using TextBasedGame.Character.Interfaces;
using TextBasedGame.Character.Models;
using TextBasedGame.Utilities;

namespace TextBasedGame.Setup
{
    public class PlayerSetup
    {
        private static readonly ICharacter Character = new Character.Implementations.Character();
        private static readonly IAttribute Attributes = new Character.Implementations.Attribute();

        public static CharacterModel InstantiatePlayer()
        {
            CharacterAttributeModel playerAttributes = Attributes.CreateCharacterAttributes();
            CharacterModel player = Character.CreateCharacter(playerAttributes);

            return player;
        }

        public static CharacterModel WelcomePlayer(CharacterModel player)
        {
            string input;
            while (player.Name == null)
            {
                TypingAnimation.Animate("Please enter a Player name: ", Color.DarkOrange);
                Console.Write("> ", Color.DarkOrange);
                input = Console.ReadLine().Trim();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    player.Name = input[0].ToString().ToUpper() + input.Substring(1);
                }
                Console.Clear();
            }

            var welcomePlayer = "Hello, {0}!";
            Formatter playerName = new Formatter(player.Name, Color.Gold);

            Console.Clear();
            Console.WriteLineFormatted(welcomePlayer, Color.YellowGreen, playerName);
            Console.WriteLine();

            TypingAnimation.Animate(
                "Press <Enter> to spend your (" + player.Attributes.AvailablePoints + ") available Player Trait points...", 
                Color.DarkOrange);
            Console.ReadLine();
            Console.Clear();

            return player;
        }

        public static CharacterModel SetPlayerTraits(CharacterModel player)
        {
            bool displayInfo = false;
            bool playerReady = false;
            while (!playerReady)
            {
                string input;
                while (player.Attributes.AvailablePoints > 0)
                {
                    TypingAnimation.Animate(
                        player.Name + ", you have (" + player.Attributes.AvailablePoints + ") points to spend.",
                        Color.Chartreuse,
                        20);
                    Console.WriteLine();
                    Console.WriteLine("Current trait values:", Color.DarkOrange);
                    Console.WriteLine("\t1. Defense \t= " + player.Attributes.Defense, Color.AliceBlue);
                    if (displayInfo)
                    {
                        Console.WriteLine("\t - How resilient your character is to damage.", Color.Gray);
                        Console.WriteLine();
                    }

                    Console.WriteLine("\t2. Dexterity \t= " + player.Attributes.Dexterity, Color.AliceBlue);
                    if (displayInfo)
                    {
                        Console.WriteLine("\t - How agile or evasive your character is.", Color.Gray);
                        Console.WriteLine();
                    }

                    Console.WriteLine("\t3. Luck \t= " + player.Attributes.Luck, Color.AliceBlue);
                    if (displayInfo)
                    {
                        Console.WriteLine("\t - How fortunate your character will be in their adventure.", Color.Gray);
                        Console.WriteLine();
                    }

                    Console.WriteLine("\t4. Stamina \t= " + player.Attributes.Stamina, Color.AliceBlue);
                    if (displayInfo)
                    {
                        Console.WriteLine("\t - How many overall Hit Points your character can have.", Color.Gray);
                        Console.WriteLine();
                    }

                    Console.WriteLine("\t5. Strength \t= " + player.Attributes.Strength, Color.AliceBlue);
                    if (displayInfo)
                    {
                        Console.WriteLine("\t - How strong your character is; how much damage they can do.", Color.Gray);
                        Console.WriteLine();
                    }

                    Console.WriteLine("\t6. Wisdom \t= " + player.Attributes.Wisdom, Color.AliceBlue);
                    if (displayInfo)
                    {
                        Console.WriteLine("\t - How knowledgeable, sensible, or perceptive your character is " +
                                          "\n\t   in regard to situations or their surroundings.", Color.Gray);
                        Console.WriteLine();
                    }

                    Console.WriteLine("\t?. Info - Toggle info on what each trait does...", Color.Gray);
                    Console.WriteLine();
                    Console.WriteLine("Enter the trait name or number you'd like to add (1) point to.", Color.OrangeRed);
                    Console.Write("> ", Color.DarkOrange);
                    input = Console.ReadLine().ToLower();
                    if (input == "?" || input == "info")
                    {
                        displayInfo = !displayInfo;
                        Console.Clear();
                        continue;
                    }
                    player.Attributes = UpdateCharacterAttributes(player.Attributes, input);
                    Console.Clear();
                }
                TypingAnimation.Animate(player.Name + ", here are your final trait values:", Color.Red);
                Console.WriteLine("\tDefense \t= " + player.Attributes.Defense, Color.AliceBlue);
                Console.WriteLine("\tDexterity \t= " + player.Attributes.Dexterity, Color.AliceBlue);
                Console.WriteLine("\tLuck \t\t= " + player.Attributes.Luck, Color.AliceBlue);
                Console.WriteLine("\tStamina \t= " + player.Attributes.Stamina, Color.AliceBlue);
                Console.WriteLine("\tStrength \t= " + player.Attributes.Strength, Color.AliceBlue);
                Console.WriteLine("\tWisdom \t\t= " + player.Attributes.Wisdom, Color.AliceBlue);
                Console.WriteLine();
                Console.WriteLine("Do you want to begin your adventure? (y/n)", Color.AntiqueWhite);
                Console.Write("> ", Color.DarkOrange);
                input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "n":
                    case "no":
                        player.Attributes = new CharacterAttributeModel();
                        Console.Clear();
                        Console.ReplaceAllColorsWithDefaults();
                        break;
                    default:
                        playerReady = true;
                        Console.Clear();
                        break;
                }
            }

            Character.UpdateCharacter(player, increaseMaximumHealth: 15 * (player.Attributes.Stamina - 3));
            return player;
        }

        private static CharacterAttributeModel UpdateCharacterAttributes(CharacterAttributeModel attributes, string userInput)
        {
            bool validInput = true;
            switch (userInput)
            {
                case "1":
                case "def":
                case "defense":
                    attributes.Defense += 1;
                    break;
                case "2":
                case "dex":
                case "dext":
                case "dexterity":
                    attributes.Dexterity += 1;
                    break;
                case "3":
                case "luck":
                    attributes.Luck += 1;
                    break;
                case "4":
                case "stam":
                case "stamina":
                    attributes.Stamina += 1;
                    break;
                case "5":
                case "strn":
                case "stren":
                case "strength":
                    attributes.Strength += 1;
                    break;
                case "6":
                case "wis":
                case "wisdom":
                    attributes.Wisdom += 1;
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Entered value '{0}' not recognized!", userInput, Color.Brown);
                    Console.Write("Press <Enter> to continue...", Color.White);
                    Console.ReadLine();
                    Console.ReplaceAllColorsWithDefaults();
                    validInput = false;
                    break;
            }

            if (validInput)
            {
                attributes.AvailablePoints -= 1;
            }
            return attributes;
        }
    }
}