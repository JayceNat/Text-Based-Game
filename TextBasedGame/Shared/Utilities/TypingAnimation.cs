using System;
using System.Drawing;
using Console = Colorful.Console;

namespace TextBasedGame.Shared.Utilities
{
    public class TypingAnimation
    {
        // Simple loop to iterate over characters and delay printing each one to console
        public static void Animate(string text, Color color = default(Color), int delay = 30)
        {
            string printedText = "";
            string remainingText = text;
            var enterKeyPressed = false;
            foreach (var character in text)
            {
                // If enter key is pressed while looping,
                // we want to complete the text and end loop
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

                // We don't want to write a line that has already ended,
                // as it would be duplicated
                if (character == '\n')
                {
                    printedText = "";
                }
                else
                {
                    printedText += character;
                }
                
                // Store what we haven't printed yet in case user pressed enter
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