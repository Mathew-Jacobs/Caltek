using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caltek.Program.Models
{
    public class FormattedText
    {
        public FormattedText(string color, int pauseTime, string text)
        {
            Color = color;
            PauseTime = pauseTime;
            Text = text;
        }

        public string Color { get; set; }
        public int PauseTime { get; set; }
        public string Text { get; set; }
    }
}
