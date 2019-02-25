using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caltek.Program.Models
{
    public class UserData
    {
        public UserData()
        {
            StartTime = DateTime.Now;
            LastLog = new DateTime(1985, 10, 22);
            UserName = "Denning";
            NameDatabase = ConfigFiles();
        }

        public DateTime StartTime { get; set; }
        public DateTime LastLog { get; set; }
        public string UserName { get; set; }
        public string[] NameDatabase { get; set; }

        private string[] ConfigFiles()
        {
            string line;
            var words = new List<string>();
            StreamReader file = new StreamReader(@"../../Dependency/CMN2940/MN2940.txt");

            while ((line = file.ReadLine()) != null)
            {
                words.Add(line);
            }

            return words.ToArray();
        }
    }
}
