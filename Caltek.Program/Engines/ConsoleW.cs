using Caltek.Program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Caltek.Program.Engines
{
    public class ConsoleW
    {
        //  "Color
        //  `
        //  PauseTime
        //  _
        //  Message
        //  ~
        //  Color2
        //  `
        //  PauseTime2
        //  _
        //  Message2"
        public static void WriteText(string formattedText)
        {
            Console.Write(" ");
            var split = SplitFormattedText(formattedText);
            var lineLength = 0;
            foreach (var section in split)
            {
                switch (section.Color)
                {
                    case "Black":
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case "Blue":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case "Cyan":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "DarkBlue":
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;
                    case "DarkCyan":
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    case "DarkGray":
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case "DarkGreen":
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case "DarkMagenta":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        break;
                    case "DarkRed":
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                    case "DarkYellow":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case "Gray":
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case "Green":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "Magenta":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case "Red":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "White":
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "Yellow":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                var words = section.Text.Split(' ');
                foreach (var word in words)
                {
                    if (word.Length + lineLength > 50)
                    {
                        Console.Write("\n ");
                        lineLength = 0 + word.Length;
                    }
                    else
                    {
                        lineLength += word.Length;
                    }
                    foreach (var letter in word)
                    {
                        if (letter == '\n')
                        {
                            lineLength = 0 + word.Length;
                        }
                        Console.Write(letter);
                        if (section.PauseTime > 0)
                        {
                            Thread.Sleep(section.PauseTime);
                        }
                    }
                    Console.Write(" ");
                }
                if (section.PauseTime > 0)
                {
                    Thread.Sleep(section.PauseTime * 2);
                }
            }
            Console.Write("\n");
        }

        private static List<FormattedText> SplitFormattedText(string formattedTextRaw)
        {
            List<FormattedText> formattedText = new List<FormattedText>();
            var sectionSplit = formattedTextRaw.Split('~');
            foreach (var section in sectionSplit)
            {
                var formattedSplit = section.Split(new char[] { '`', '_' });
                FormattedText text = new FormattedText(formattedSplit[0], int.Parse(formattedSplit[1]), formattedSplit[2]);
                formattedText.Add(text);
            }
            return formattedText;
        }
    }
}
