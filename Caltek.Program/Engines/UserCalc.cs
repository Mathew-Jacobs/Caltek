using Caltek.Program.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caltek.Program.Engines
{
    public class UserCalc
    {
        public static void Calc(UserData user)
        {
            var path = Path.GetFullPath("text.txt");
            var words = path.Split(char.Parse(@"\"));
            var name = words[2];
            var names = user.NameDatabase;

            if (names.Contains(name))
            {
                user.Recognized = true;
            }
            else
            {
                List<string> closestGuesses = new List<string>();
                int currentLevenshtein = 1000;
                for (int i = 0; i < names.Length; i++)
                {
                    var num = 0;
                    if (names[i].Substring(0, Math.Min(name.Length, names[i].Length)).ToUpper() == name.ToUpper())
                    {
                        num = Levenshtein.Compute(names[i].ToUpper(), name.ToUpper()) - 3;
                    }
                    else if (names[i].ToUpper().Contains(name.ToUpper()))
                    {
                        num = Levenshtein.Compute(names[i].ToUpper(), name.ToUpper()) - 1;
                    }
                    else if (name.ToUpper().Contains(names[i].ToUpper()))
                    {
                        num = Levenshtein.Compute(names[i].ToUpper(), name.ToUpper()) - 3;
                    }
                    else
                    {
                        num = Levenshtein.Compute(name.ToUpper(), names[i].ToUpper());
                    }
                    if (num == currentLevenshtein)
                    {
                        closestGuesses.Add(names[i]);
                    }
                    else if (num < currentLevenshtein)
                    {
                        closestGuesses.Clear();
                        closestGuesses.Add(names[i]);
                        currentLevenshtein = num;
                    }
                }
                foreach (var item in closestGuesses)
                {
                }
            }
        }
    }
}
