using System.Collections.Generic;

namespace TextBasedGame.Constants
{
    public class ConsoleStrings
    {
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

        public static string NoItemsFound = "You look around, but you don't see any items in the room...\n";

        public static string NoWeaponsFound = "You look around, but you don't see any weapons in the room...\n";

        public static string GameHelp = "Hint: Try typing in some of these inputs: \n" +
                                        "\t - 'pickup' + <item name>: pick up a specific item or weapon\n" +
                                        "\t - 'drop' + <item name>: drop a specific item or weapon\n" +
                                        "\t - 'goto' + <room/exit name>: go to a specific room or exit\n" +
                                        "\t - 'items': look around for items in a room\n" +
                                        "\t - 'weapons': look around for weapons in a room\n" +
                                        "\t - 'exits': see what exits there are from a room\n" +
                                        "\t - 'inventory': view your character's carried items\n" +
                                        "\t - 'status': view stats about your character \n";
    }
}