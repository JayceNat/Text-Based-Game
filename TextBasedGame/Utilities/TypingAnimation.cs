using System.Drawing;
using Console = Colorful.Console;

namespace TextBasedGame.Utilities
{
    public class TypingAnimation
    {
        public static void Animate(string text, Color color = default(Color), int delay = 30)
        {
            foreach (var character in text)
            {
                Console.Write(character, color);
                System.Threading.Thread.Sleep(delay);
            }
            System.Threading.Thread.Sleep(delay);
            Console.WriteLine();
        }
    }
}