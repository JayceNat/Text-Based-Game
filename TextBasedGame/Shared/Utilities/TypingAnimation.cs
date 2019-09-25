using System;
using System.Drawing;
using Console = Colorful.Console;

namespace TextBasedGame.Shared.Utilities
{
    public class TypingAnimation
    {
        public static void Animate(string text, Color color = default(Color), int delay = 30)
        {
            string printedText = "";
            string remainingText = text;
            var enterKeyPressed = false;
            foreach (var character in text)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.Write(printedText, color);
                        enterKeyPressed = true;
                        break;
                    }
                }

                Console.Write(character, color);

                if (character == '\n')
                {
                    printedText = "";
                }
                else
                {
                    printedText += character;
                }
                
                remainingText = remainingText.Remove(0, 1);
                System.Threading.Thread.Sleep(delay);
            }

            if (enterKeyPressed)
            {
                Console.Write(remainingText, color);
            }
            else
            {
                System.Threading.Thread.Sleep(delay);
            }

            Console.WriteLine();
        }
    }
}