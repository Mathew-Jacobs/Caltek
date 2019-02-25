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
        public static void WriteText(string formattedText)
        {
            var split = SplitFormattedText(formattedText);
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
                
                foreach(var letter in section.Text)
                {
                    Console.Write(letter);
                    Thread.Sleep(section.PauseTime);
                }
                Thread.Sleep(section.PauseTime * 2);
            }
        }

        private static List<FormattedText> SplitFormattedText(string formattedTextRaw)
        {
            List<FormattedText> formattedText = new List<FormattedText>();
            var sectionSplit = formattedTextRaw.Split( '~' );
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
