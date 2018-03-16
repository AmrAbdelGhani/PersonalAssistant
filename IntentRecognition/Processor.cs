#region using directives
using System;
using System.Windows.Forms;
#endregion
namespace IntentRecognition
{
    class Processor
    {
        public static string mandoob = "";
        public static string Opener(string app)
        {
            string[] w = new string[Reference.appProcesses.Length];
            for (int i = 0; i < Reference.appProcesses.Length; i++)
            {
                w = Reference.appProcesses[i].Split('|');
                if (w[0] == app)
                { break; }
            }
            WindowsManager.LaunchProcess(w[1]);
            return GetRandom(Reference.opener);
        }
        public static string RandomNum(string numOne, string numTwo)
        {
            int num1 = int.Parse(numOne);
            int num2 = int.Parse(numTwo);
            Random rand = new Random();
            int result = rand.Next(num1, num2);
            return result.ToString();
        }
        public static string Search(string msg)
        {
            string googleprompt = "https://www.google.com.eg/search?rct=j&q=";
            WindowsManager.LaunchProcess(googleprompt + msg);
            return "Search Complete";
        }
        public static string RandomGame()
        {
            return GetRandom(Reference.randomgame) + GetRandom(Reference.gameList);
        }
        public static string Greeting()
        {
            string msg = "";
            if (DateTime.Now.Hour < 12)
                msg = ("Good Morning sir. ");
            else if (DateTime.Now.Hour > 12 & DateTime.Now.Hour < 18)
                msg = ("Good Afternoon sir. ");
            else msg = ("Good Evening sir. ");
            return msg + GetRandom(Reference.greeting);
        }
        public static string Farewell()
        {
            Driver.ByeJarvis = 1;
            return GetRandom(Reference.farewell);
        }
        public static string ShowTime()
        {
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            string ampm = "";
            if (hour == 0) { hour = 12; ampm = "am"; }
            else if (hour > 12) { hour -= 12; ampm = "pm"; } else ampm = "a.m.";
            string msg = "";
            if (minute < 10)
             msg = hour.ToString() + " " + "O" + minute.ToString() + " " + ampm;
            else 
                msg = hour.ToString() + " " +  minute.ToString() + " " + ampm;
            return GetRandom(Reference.showtime) + msg;
        }
        public static string Complement()
        {
            return GetRandom(Reference.complement);
        }
        public static string Screenshot()
        {
            SendKeys.SendWait("%{PRTSC}"); WindowsManager.saveScreenShot();
            return GetRandom(Reference.screenshot);
        }
        public static string Reader()
        {
            return ReaderHandler.ReaderMode();
        }
        public static string CheckInternet()
        {
            return WindowsManager.CheckInternet();
        }            
        public static string KeyboardCommand(string msg)
        {  
            switch (msg)
            {
                case "copy": SendKeys.SendWait("^(c)"); return "Copied";
                case "paste": SendKeys.SendWait("^(v)");  break;
                case "select all": SendKeys.SendWait("^(a)");  break;
                case "delete selection": SendKeys.SendWait("{DEL}"); break;
                case "open new": SendKeys.SendWait("^(o)"); break;
                case "enter": SendKeys.SendWait("{ENTER}"); break;
                case "close": SendKeys.SendWait("%{F4}"); break;
                case "save": SendKeys.SendWait("^(s)"); return "File saved";
                case "tab": SendKeys.SendWait("{tab}"); break;
            }
            return "";
        }
        public static string Converter(string e, string num)
        {
            if(e.Contains("hexadecimal"))
            {
                return ConverterHandler.ToHexaConversion(num);
            }
            else if(e.Contains("decimal"))
            {
                return ConverterHandler.ToDecimalConversion(num);
            }
            else
            {
                return "Binary still needs implementation";
            }
        }
        public static string Friday()
        {
            return GetRandom(Reference.calling);
        }
        public static void Type(string msg)
        {
            SendKeys.SendWait(msg);
        }
        public static string PlaySong()
        {
            string song = GetRandom(Reference.mySongs);
            WindowsManager.LaunchProcess(Reference.musicFile + song + ".mp3");
            MusicManager.getHandle();

            return "Playing: " + song;
        }
        public static string PlayList()
        {
            WindowsManager.LaunchProcess(Reference.playlist);
            MusicManager.getHandle();
            return "Starting Playlist";
        }
        public static string MusicCommand(string msg)
        {
            Console.Write("|" + msg + "|");
            switch (msg)
            {
                case "stop music":
                case "pause":
                case "pause music":
                case "resume": MusicManager.Play_Pause(); break;
                case "next":
                case "next song": 
                case "change song": MusicManager.Next(); break;
                case "previous":
                case "last song": MusicManager.Previous(); break;
                case "mute":
                case "unmute": MusicManager.Mute(); break;
                case "lower volume":
                case "down":
                case "volume down": MusicManager.VolDown(2);break;
                case "increase volume":
                case "up":
                case "volume up": MusicManager.VolUp(2); break;
                case "playback":
                case "repeat": MusicManager.Repeat();break;
            }
            return "";
        }
        public static string  Weather(string city)
        {
            string[] b = WeatherHandler.GetWeather(city);
            string rsp = b[1] + " degrees Celsius ,and goes down to " + b[0] + " degrees";
            return GetRandom(Reference.weather) + rsp;
        }
        #region useful functions
        private static string GetRandom(string[] choices)
        {
            Random rand = new Random();
            int i = rand.Next(choices.Length - 1);
            return choices[i];
        }
        
        #endregion

    }

}
