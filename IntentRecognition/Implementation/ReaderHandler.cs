using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System;
namespace IntentRecognition
{
    class ReaderHandler
    {
        public static string ReaderMode()
        {
            string path = @"C:\Users\Amr\Desktop\SpeechRecognitionWF\SpeechRecognitionWF\SpeechRecognitionWF\reader.txt";
            SendKeys.SendWait("^(c)");
            WindowsManager.EnsureFocus("notepad", WindowsManager.LaunchProcess(path));
            SendKeys.SendWait("^(a)");
            SendKeys.SendWait("^(v)");
            SendKeys.SendWait("^(s)");
            SendKeys.SendWait("%{F4}");
            return 
                File.ReadAllText
                (@"C:\Users\Amr\Desktop\SpeechRecognitionWF\SpeechRecognitionWF\SpeechRecognitionWF\reader.txt");       
        }

    }
}
