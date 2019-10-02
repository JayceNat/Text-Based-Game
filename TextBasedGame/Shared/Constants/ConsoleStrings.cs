using System.Collections.Generic;

namespace TextBasedGame.Shared.Constants
{
    public class ConsoleStrings
    {
        // Used to split up user input into words
        public static char[] StringDelimiters =
        {
            ' ', ',', '.', ':', '\t'
        };

        public static List<char> PressEnterPrompt = new List<char>()
        {
            'P', 'r', 'e', 's', 's', ' ',
            'E', 'n', 't', 'e', 'r', ' ',
            'T', 'o', ' ',
            'C', 'o', 'n', 't', 'i', 'n', 'u', 'e',
            '.', '.', '.', ' '
        };

        public static List<char> PlayerInputPrompt = new List<char>()
        {
            'W', 'h', 'a', 't', ' ',
            'd', 'o', ' ',
            'y', 'o', 'u', ' ',
            'w', 'a', 'n', 't', ' ',
            't', 'o', ' ',
            'd', 'o', '?'
        };

        public static string SaveGame = "SAVE_GAME";

        // Printed just after the user completes trait setup, before first room entered
        public static List<string> GameIntro = new List<string>()
        {
            "It was a dark and windy night... \n",
             "So windy, in fact, that the power had been knocked out all the way from",
             "your house on the South side of town to Henry's cabin (miles North - on the outskirts of town). \n",
             "Something about tonight seems eery and unwelcoming...",
             "You'd even felt that way as you'd fallen asleep a bit earlier. \n",
             "You were jolted awake by the sounds of tree branches and debris clanking against your house.",
             "You can't get back to sleep now... You just heard haunting sounds outside your house. \n"
        };

        public static string FirstRoomHelpHint =
            "<Type 'info' at this prompt for a list of game commands>";

        public static string InputHelper =
            "=========================Inputs=========================\n" +
            "< items > < weapons > < exits > < inv > < stat > < use >\n" +
            "========================================================\n";

        public static string ItemsHints = "\tType  'items'   - view items in a room.\n" +
                                          "\tType  'weapons' - view weapons in a room.\n\n" +
                                          "\tType  'take' + <item keyword> to pick up a weapon or item.\n" +
                                          "\tType  'drop' + <item keyword> to leave a weapon or item.\n";

        public static string RoomHints = "\tType  'exits' - view all exits you have from a room.\n" +
                                         "\tType  'enter' + <room keyword> to go into a room.\n";

        public static string InfoHints = "\tType 'inventory' or 'inv' to view what you have.\n" +
                                         "\tType  'status' or 'stat' to view your player info.\n";

        public static string NoItemsFound = "You look around, but you don't see any items in the room...\n";

        public static string NoWeaponsFound = "You look around, but you don't see any weapons in the room...\n";

        public static string LackingRequirementItemDescription =
            "There seems to be some object, but you can't make out what it is...";

        public static string LackingRequirementRoomDescription =
            "There seems to be another way to go, but you can't really tell...";

        public static string GameHelp = "\nTry typing in some of these inputs: \n" +
                                        "\t - 'items' --------------- look around for items in a room\n" +
                                        "\t - 'weapons' ------------- look around for weapons in a room\n" +
                                        "\t - 'exits' --------------- see what exits there are from a room\n\n" +
                                        "\t - '(inv)entory' --------- view what you're carrying\n" +
                                        "\t - '(stat)us' ------------ view info about your character \n\n" +
                                        "\t - 'take' + <item name> -- pick up a specific item or weapon\n" +
                                        "\t - 'drop' + <item name> -- leave a specific item or weapon\n" +
                                        "\t - 'enter' + <room name> - go to a specific room or exit\n\n" +
                                        "\t - 'use' + <item name> --- use an item in your inventory\n\n" +
                                        "\t - 'helpoff/helpon' ------ toggle the input words shown above the prompt line \n" +
                                        "\t - 'save' ---------------- save the game and close (it will ask to load when re-opened)\n";
    }
}