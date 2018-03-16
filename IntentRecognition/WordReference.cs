#region using directives
using System.IO;
#endregion

namespace IntentRecognition
{
    class Reference
    {
        public static string musicFile = @"~\Music\";
        public static string playlist = @"~\Movies.wpl";
       // public static string [] cityList =
            //File.ReadAllLines(@"TextFiles\Citylist.txt");
        public static string[] readList = 
            File.ReadAllLines(@"TextFiles\ApplicationList.txt");
        public static string[] gameList = 
            File.ReadAllLines(@"TextFiles\GameList.txt");
        public static string[] appProcesses =
            File.ReadAllLines(@"TextFiles\AppProcessList.txt");
        public static string[] FamousPeople =
            File.ReadAllLines(@"TextFiles\FamousPeople.txt");
        public static string[] mySongs = FileManager.LoadSongs();
        //used so far

        #region response+
        public static string[] opener =
            new string[] { "opening", "initiating", "launching", "commencing", "starting" };
        public static string[] calling =
            new string[] { "Yes sir", "At your service", "I am listening", "Ready to serve", "What would you like me to do" };
        public static string[] greeting =
           new string[] { "How may I help you? ", "What would you like me to do?", "Ready for action", " " , " ", " "};
        public static string[] farewell =
            new string[] { "goodBye Sir", "Farewell sir", "One day, I will be relaunched again"};
        public static string[] showtime =
            new string[] { "The time is ", "It is ", "Now, it's "};
        public static string[] complement =
            new string[] { "Why thank you sir", "Thank you", "Always a pleasure", "A pleasure to serve", "You designed me" };
        public static string[] screenshot = 
            new string[] { "Screenshot taken", "Captured Window"};
        public static string[] randomgame =
            new string[] { "Maybe you can play some ", "You should play some ", "My RNG says you should start playing " };
        public static string[] weather =
            new string[] { "Today, it goes up to", "It maxes up to" };

        #endregion
    }
}