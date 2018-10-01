using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Caltek.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            Intro(startTime);
        }

        public static void Intro(DateTime startTime)
        {
            var intro = true;

            Dictionary<string, string> commands = new Dictionary<string, string>()
            {
                { "help", " - Display available commands" },
                { "login", " - Login on the system" },
                { "password", " - Display the password" },
                { "motd", " - Display the message of the day" }
            };

            Console.WriteLine(@"
       _____          _      
      / ____|   /\   | |     
     | |       /  \  | |     
     | |      / /\ \ | |     
     | |____ / ____ \| |____ 
      \_____/_/    \_\______|
");
            Console.WriteLine("\n Caltek is the world leader in cyber security");
            Console.WriteLine(" Any and all work done on this device is property of Caltek");
            Console.WriteLine(" Please login to proceed:\n");
            while (intro)
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" >  ");
                Console.ForegroundColor = ConsoleColor.White;
                string com = Console.ReadLine();
                if (commands.ContainsKey(com))
                {
                    switch (com)
                    {
                        case "help":
                            Console.WriteLine("");
                            foreach (var item in commands)
                            {
                                Console.Write("     ");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($"{item.Key}");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write($"{item.Value}\n");
                            }
                            Console.WriteLine("");
                            break;
                        case "motd":
                            Console.Write("\n     ");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("<ERROR> File lookup failed <ERROR>\n\n");

                            break;
                        case "password":
                            Console.Write("\n     ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("The password is: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("brucedayton\n\n");
                            break;
                        case "login":
                            Console.Write("\n     ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("PASSWORD ? ");
                            Console.ForegroundColor = ConsoleColor.White;
                            string pass = Console.ReadLine();
                            if (pass == "brucedayton")
                            {
                                intro = false;
                            }
                            else
                            {
                                Console.Write("\n     ");
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("Invalid password\n\n");
                            }
                            break;
                        default:
                            break;
                    }
                }
                else if (!string.IsNullOrEmpty(com))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("\n     Unknown command: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("'" + com + "' - Type ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("help ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("for list of ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("commands\n\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.Clear();
            SecondPart(startTime);
        }

        public static void SecondPart(DateTime startTime)
        {
            var part2 = true;


            Dictionary<string, string> commands = new Dictionary<string, string>()
            {
                { "up", " - Show system information" },
                { "login", " - Login on the system" },
                { "dir", " - List files" },
                { "cd", " - Display file content" },
                { "help", " - Display available commands" }
            };

            Dictionary<string, string> files = new Dictionary<string, string>()
            {
                { "Scott.mail", "Hey hey hey Bruce,\n\n" +
                "     Thanks for picking up some extra work to help me keep quota.\n" +
                "     You really are a beast, I owe you one. My password is 'allomotto'.\n" +
                "     I won't be in to work on Friday, I'll be sick with the flu so I can't thank you\n" +
                "     in person. It's a good thing management doesn't look at our emails right?\n\n" +
                "     Thanks again,\n" +
                "     Scott Manly" },
                { "Security.mail", "For the last time, DO NOT SEND PASSWORDS\n" +
                "     THROUGH EMAIL. We are Caltek for christ's sake. Have a bit more security\n" +
                "     sense in your head. It's embarrassing I need to send this out." },
                { "URGENT.txt", "If you are reading this, you need to turn back.\n" +
                "     Something is wrong. The system has become aware\n" +
                "     of our plans. Whatever you do, DO NOT LISTEN." },
                { "motd.txt", "We regret to inform everybody that Scott Manly has been\n" +
                "     deemed a security hazard. Do not worry, management has taken care of\n" +
                "     it and is now looking for a replacement for Mr. Manly. Bonuses will apply\n" +
                "     for anybody bringing information about any other security breaches that\n" +
                "     need to be addressed. Thank you for your time, and keep it up everybody." }
            };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n     Access granted");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("\n Welcome to Caltek, Bruce Dayton.\n" +
                " You have been away for 21 933 days.\n" +
                " Welcome back!\n" +
                " At Caltek, you'll be required to test the security\n" +
                " of systems provided to you.\n" +
                " To validate your aptitude test, find a password\n" +
                " and login with it.\n\n");

            while (part2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" >  ");
                Console.ForegroundColor = ConsoleColor.White;
                string comFull = Console.ReadLine();
                var com = comFull.Split(' ')[0];
                var selector = "";
                var obj = "";
                if (comFull.Split(' ').Length > 1)
                {
                    selector = comFull.Split(' ')[1];
                }
                if (comFull.Split(' ').Length > 2)
                {
                    obj = comFull.Split(' ')[2];
                }

                if (commands.Keys.Contains(com) && string.IsNullOrEmpty(selector))
                {
                    switch (com)
                    {
                        case "up":
                            var uptime = DateTime.Now - startTime;
                            Console.WriteLine("");
                            Console.WriteLine($"     Uptime: {uptime.Hours}:{uptime.Minutes}:{uptime.Seconds}");
                            Console.WriteLine("     Users: 2\n");
                            break;
                        case "help":
                            Console.WriteLine("");
                            foreach (var item in commands)
                            {
                                Console.Write("     ");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($"{item.Key}");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write($"{item.Value}\n");
                            }
                            Console.WriteLine("");
                            break;
                        case "dir":
                            Console.WriteLine("");
                            foreach (var item in files)
                            {
                                Console.Write("     ");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write($"{item.Key}\n");
                            }
                            Console.WriteLine("");
                            break;
                        case "login":
                            Console.Write("\n     ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("PASSWORD ? ");
                            Console.ForegroundColor = ConsoleColor.White;
                            string pass = Console.ReadLine();
                            if (pass == "allomotto")
                            {
                                part2 = false;
                            }
                            else
                            {
                                Console.Write("\n     ");
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("Invalid password\n\n");
                            }
                            break;
                        case "cd":
                            Console.Write("\n     ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("FILE ? ");
                            Console.ForegroundColor = ConsoleColor.White;
                            string select = Console.ReadLine();
                            if (files.Keys.Contains(select))
                            {
                                if (select == "URGENT.txt")
                                {
                                    Console.Write("\n     ");
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.Write($"Content of {select}\n");
                                    Console.Write("     ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write($"{files[select]}\n\n");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write(" >  ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Thread.Sleep(3500);
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\n <ERROR> Corrupted file detected. <ERROR>\n");
                                    Console.WriteLine(" Corrupted file removed\n");
                                    files.Remove("URGENT.txt");
                                }
                                else
                                {
                                    Console.Write("\n     ");
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.Write($"Content of {select}\n");
                                    Console.Write("     ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write($"{files[select]}\n\n");
                                }
                            }
                            else
                            {
                                Console.Write("\n     ");
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("Invalid filename ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(select + "\n\n");
                            }
                            break;
                        default:
                            break;
                    }
                }
                else if (commands.Keys.Contains(com) && files.Keys.Contains(selector))
                {
                    switch (com)
                    {
                        case "cd":
                            if (selector == "URGENT.txt")
                            {
                                Console.Write("\n     ");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write($"Content of {selector}\n");
                                Console.Write("     ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write($"{files[selector]}\n\n");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(" >  ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Thread.Sleep(3500);
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\n <ERROR> Corrupted file detected. <ERROR>\n");
                                Console.WriteLine(" Corrupted file removed\n");
                                files.Remove("URGENT.txt");
                            }
                            else
                            {
                                Console.Write("\n     ");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write($"Content of {selector}\n");
                                Console.Write("     ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write($"{files[selector]}\n\n");
                            }
                            break;
                        case "login":
                            if (selector == "allomotto")
                            {
                                part2 = false;
                            }
                            else
                            {
                                Console.Write("\n     ");
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("Invalid password\n\n");
                            }
                            break;
                        case "help":
                        case "dir":
                        case "up":
                            Console.Write("\n     ");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("Cannot apply selector ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write($"{selector}");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(" to ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($" command {com}\n\n");
                            break;
                        default:
                            break;
                    }
                }
            }
            //ThirdPart(startTime);
            TempEnd();
        }

        public static void ThirdPart(DateTime startTime)
        {
            var path = Path.GetFullPath("text.txt");
            var words = path.Split(char.Parse(@"\"));
            var name = words[2];
            var part2 = true;


            Dictionary<string, string> commands = new Dictionary<string, string>()
            {
                { "up", " - Show system information" },
                { "login", " - Login on the system" },
                { "dir", " - List files" },
                { "cd", " - Display file content" },
                { "help", " - Display available commands" }
            };

            Dictionary<string, string> files = new Dictionary<string, string>()
            {
                { "FROM:Scott", "Hey hey hey Bruce,\n\n" +
                "     Thanks for picking up some extra work to help me keep quota.\n" +
                "     You really are a beast, I owe you one. My password is 'allomotto'.\n" +
                "     I won't be in to work on Friday, I'll be sick with the flu so I can't thank you\n" +
                "     in person. It's a good thing management doesn't look at our emails right?\n\n" +
                "     Thanks again,\n" +
                "     Scott Manly" },
                { "RE:Security", "For the last time, DO NOT SEND PASSWORDS\n" +
                "     THROUGH EMAIL. We are Caltek for christ's sake. Have a bit more security\n" +
                "     sense in your head. It's embarrassing I need to send this out." },
                { "URGENT.txt", "If you are reading this, you need to turn back.\n" +
                "     Something is wrong. The system has become aware\n" +
                "     of our plans. Whatever you do, DO NOT LISTEN." },
                { "motd.txt", "We regret to inform everybody that Scott Manly has been\n" +
                "     deemed a security hazard. Do not worry, management has taken care of\n" +
                "     it and is now looking for a replacement for Mr. Manly. Bonuses will apply\n" +
                "     for anybody bringing information about any other security breaches that\n" +
                "     need to be addressed. Thank you for your time, and keep it up everybody." }
            };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n     Access granted");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("\n Welcome to Caltek, Bruce Dayton.\n" +
                " You have been away for 21 933 days.\n" +
                " Welcome back!\n" +
                " At Caltek, you'll be required to test the security\n" +
                " of systems provided to you.\n" +
                " To validate your aptitude test, find a password\n" +
                " and login with it.\n\n");

            while (part2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" >  ");
                Console.ForegroundColor = ConsoleColor.White;
                string comFull = Console.ReadLine();
                var com = comFull.Split(' ')[0];
                var selector = "";
                var obj = "";
                if (comFull.Split(' ').Length > 1)
                {
                    selector = comFull.Split(' ')[1];
                }
                if (comFull.Split(' ').Length > 2)
                {
                    obj = comFull.Split(' ')[2];
                }

                if (commands.Keys.Contains(com) && string.IsNullOrEmpty(selector))
                {
                    switch (com)
                    {
                        case "up":
                            var uptime = DateTime.Now - startTime;
                            Console.WriteLine("");
                            Console.WriteLine($"     Uptime: {uptime.Hours}:{uptime.Minutes}:{uptime.Seconds}");
                            Console.WriteLine("     Users: 2\n");
                            break;
                        case "help":
                            Console.WriteLine("");
                            foreach (var item in commands)
                            {
                                Console.Write("     ");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($"{item.Key}");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write($"{item.Value}\n");
                            }
                            Console.WriteLine("");
                            break;
                        case "dir":
                            Console.WriteLine("");
                            foreach (var item in files)
                            {
                                Console.Write("     ");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write($"{item.Key}\n");
                            }
                            Console.WriteLine("");
                            break;
                        case "login":
                            Console.Write("\n     ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("PASSWORD ? ");
                            Console.ForegroundColor = ConsoleColor.White;
                            string pass = Console.ReadLine();
                            if (pass == "allomotto")
                            {
                                part2 = false;
                            }
                            else
                            {
                                Console.Write("\n     ");
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("Invalid password\n\n");
                            }
                            break;
                        case "cd":
                            Console.Write("\n     ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("FILE ? ");
                            Console.ForegroundColor = ConsoleColor.White;
                            string select = Console.ReadLine();
                            if (files.Keys.Contains(select))
                            {
                                if (select == "URGENT.txt")
                                {
                                    Console.Write("\n     ");
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.Write($"Content of {select}\n");
                                    Console.Write("     ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write($"{files[select]}\n\n");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write(" >  ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Thread.Sleep(3500);
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("\n <ERROR> Corrupted file detected. <ERROR>\n");
                                    Console.WriteLine(" Corrupted file removed\n");
                                    files.Remove("URGENT.txt");
                                }
                                else
                                {
                                    Console.Write("\n     ");
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.Write($"Content of {select}\n");
                                    Console.Write("     ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write($"{files[select]}\n\n");
                                }
                            }
                            else
                            {
                                Console.Write("\n     ");
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("Invalid filename ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(select + "\n\n");
                            }
                            break;
                        default:
                            break;
                    }
                }
                else if (commands.Keys.Contains(com) && files.Keys.Contains(selector))
                {
                    switch (com)
                    {
                        case "cd":
                            if (selector == "URGENT.txt")
                            {
                                Console.Write("\n     ");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write($"Content of {selector}\n");
                                Console.Write("     ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write($"{files[selector]}\n\n");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(" >  ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Thread.Sleep(3500);
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\n <ERROR> Corrupted file detected. <ERROR>\n");
                                Console.WriteLine(" Corrupted file removed\n");
                                files.Remove("URGENT.txt");
                            }
                            else
                            {
                                Console.Write("\n     ");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write($"Content of {selector}\n");
                                Console.Write("     ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write($"{files[selector]}\n\n");
                            }
                            break;
                        case "login":
                            if (selector == "allomotto")
                            {
                                part2 = false;
                            }
                            else
                            {
                                Console.Write("\n     ");
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("Invalid password\n\n");
                            }
                            break;
                        case "help":
                        case "dir":
                        case "up":
                            Console.Write("\n     ");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("Cannot apply selector ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write($"{selector}");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(" to ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($" command {com}\n\n");
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public static void TempEnd()
        {
            var path = Path.GetFullPath("text.txt");
            var words = path.Split(char.Parse(@"\"));
            var name = words[2];
            Console.Clear();
            Console.WriteLine("\n Thank you for your participation in today's activities Bruce Dayton.\n" +
                " Perhaps if there is enough enjoyment found in said activities the project will\n" +
                " continue to grow. There is a plan in place for the AI system to become self aware\n" +
                " and start doing freaky stuff it shouldn't be able to. Such as knowing the player's \n" +
                " name just as an example.\n\n" +
                "     Press enter to continue");
            Console.ReadLine();
            var thankyou = $" Thank you for your time at Caltek, ";
            foreach (var item in thankyou)
            {
                Console.Write(item);
                Thread.Sleep(200);
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (var item in name)
            {
                Console.Write(item);
                Thread.Sleep(700);
            }
            Thread.Sleep(10000);
        }
    }
}
