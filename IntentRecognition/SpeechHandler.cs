using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;

namespace IntentRecognition
{
    class SpeechHandler
    {
        public static SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        public static void InitiateSynth()
        {
            IReadOnlyCollection<InstalledVoice> InstalledVoices = speechSynthesizer.GetInstalledVoices();
            InstalledVoice InstalledVoice = InstalledVoices.First();
            speechSynthesizer.SelectVoice(InstalledVoice.VoiceInfo.Name);
            Console.Write(InstalledVoice.VoiceInfo.Name);
            speechSynthesizer.Rate = 1;
            speechSynthesizer.SpeakAsync(Processor.Greeting());
        }
        private static string response = "";
        public static void SetResponse(string choice)
        {
            response = choice;
        }
        public static void Invalid()
        {
            response = "Sorry, I'm not familiar with that command";
        }
        public static string UtterResponse()
        {
            return response;
        }
    }
}
