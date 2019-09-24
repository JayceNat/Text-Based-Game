using System;
using System.Drawing;
using Console = Colorful.Console;

namespace TextBasedGame.Shared.Utilities
{
    public class TypingAnimation
    {
        public static void Animate(string text, Color color = default(Color), int delay = 30)
        {
            var enterKeyPressed = false;
            foreach (var character in text)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        enterKeyPressed = true;
                        break;
                    }
                }
                Console.Write(character, color);
                System.Threading.Thread.Sleep(delay);
            }

            if (enterKeyPressed)
            {
                Console.WriteLine(text, color);
            }
            else
            {
                System.Threading.Thread.Sleep(delay);
            }

            Console.WriteLine();
        }
    }
}