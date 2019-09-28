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

        // Printed just after the user completes trait setup, before first room entered
        public static string GameIntro = "It was a dark and windy night... \n\n" +
                                         "So windy, in fact, that the power had been knocked out all the way from \n" +
                                         "your house on the South side of town to Henry's cabin (miles North - on the outskirts of town). \n\n" +
                                         "Something about tonight seems eery and unwelcoming... \n" +
                                         "You'd even felt that way as you'd fallen asleep a bit earlier. \n\n" +
                                         "You were jolted awake by the sounds of tree branches and debris clanking against your house. \n" +
                                         "You can't get back to sleep now... You just heard haunting sounds outside your house. \n\n";

        public static string FirstRoomHelpHint =
            "<Type 'help' for info on where you are, available exits, and commands>";

        public static string NoItemsFound = "You look around, but you don't see any items in the room...\n";

        public static string NoWeaponsFound = "You look around, but you don't see any weapons in the room...\n";

        public static string GameHelp = "Hint: Try typing in some of these inputs: \n" +
                                        "\t - 'take' + <item name>: pick up a specific item or weapon\n" +
                                        "\t - 'drop' + <item name>: drop a specific item or weapon\n" +
                                        "\t - 'enter' + <room/exit name>: go to a specific room or exit\n" +
                                        "\t - 'items': look around for items in a room\n" +
                                        "\t - 'weapons': look around for weapons in a room\n" +
                                        "\t - 'exits': see what exits there are from a room\n" +
                                        "\t - '(inv)entory': view your character's carried items\n" +
                                        "\t - '(stat)us': view stats about your character \n";
    }
}