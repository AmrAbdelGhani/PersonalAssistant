#region using directives
using System;
using System.Speech.Recognition; // capture voice 
#endregion


namespace IntentRecognition
{

    class Driver
    {
        public static GBLibrary gbLib = new GBLibrary();
        public static GBExtractor gbEX = new GBExtractor();
        public static Reference reference = new Reference();
        public static int ByeJarvis = 0;
        SpeechRecognitionEngine speechRecognitionEngine = null;
        #region start

        public void Start()
        {
            try
            {
                // create the engine
                speechRecognitionEngine = createSpeechEngine("en-US");

                // hook to event
                speechRecognitionEngine.SpeechRecognized += 
                    new EventHandler<SpeechRecognizedEventArgs>(engine_SpeechRecognized);

                // load dictionary
                loadGrammarAndCommands();
                // use the system's default microphone
                speechRecognitionEngine.SetInputToDefaultAudioDevice();
                SpeechHandler.InitiateSynth();
                // start listening
                speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Voice recognition failed " + ex.Message);
            }

            //Keeps the command prompt going until you say jarvis quit
            while (ByeJarvis != 2)
            {
            }
        }

        #endregion

        #region internal functions and methods
        private SpeechRecognitionEngine createSpeechEngine(string preferredCulture)
        {
            foreach (RecognizerInfo config in SpeechRecognitionEngine.InstalledRecognizers())
            {
                if (config.Culture.ToString() == preferredCulture)
                {
                    speechRecognitionEngine = new SpeechRecognitionEngine(config);
                    break;
                }
            }

            // if the desired culture is not found, then load default
            if (speechRecognitionEngine == null)
            {
                Console.WriteLine("The desired culture is not installed on this machine, the speech-engine will continue using "
                    + SpeechRecognitionEngine.InstalledRecognizers()[0].Culture.ToString() + " as the default culture.",
                    "Culture " + preferredCulture + " not found!");
                speechRecognitionEngine = new SpeechRecognitionEngine(SpeechRecognitionEngine.InstalledRecognizers()[0]);
            }

            return speechRecognitionEngine;
        }

        private void loadGrammarAndCommands()
        {
            #region loadgrammars
            speechRecognitionEngine.LoadGrammarAsync(gbLib.RandomNum());
            speechRecognitionEngine.LoadGrammarAsync(gbLib.RandomGame());
            speechRecognitionEngine.LoadGrammarAsync(gbLib.Search());
            speechRecognitionEngine.LoadGrammarAsync(gbLib.WhoIs());
            speechRecognitionEngine.LoadGrammarAsync(gbLib.Opener());
            speechRecognitionEngine.LoadGrammarAsync(gbLib.Converter());
            speechRecognitionEngine.LoadGrammarAsync(gbLib.Greeting());
            speechRecognitionEngine.LoadGrammarAsync(gbLib.Farewell());
            speechRecognitionEngine.LoadGrammarAsync(gbLib.ShowTime());
            speechRecognitionEngine.LoadGrammarAsync(gbLib.KeyboardCommand());
            speechRecognitionEngine.LoadGrammarAsync(gbLib.CheckInternet());
            speechRecognitionEngine.LoadGrammarAsync(gbLib.Type());
            speechRecognitionEngine.LoadGrammarAsync(gbLib.Complement());
            speechRecognitionEngine.LoadGrammarAsync(gbLib.Screenshot());
            speechRecognitionEngine.LoadGrammarAsync(gbLib.Reader());
            speechRecognitionEngine.LoadGrammarAsync(gbLib.PlaySong());
            speechRecognitionEngine.LoadGrammarAsync(gbLib.PlayList());
            speechRecognitionEngine.LoadGrammarAsync(gbLib.MusicCommand());
            speechRecognitionEngine.LoadGrammarAsync(gbLib.Weather());
            #endregion
            DictationGrammar dict = new DictationGrammar();
                speechRecognitionEngine.LoadGrammar(dict);
        }

        #endregion
        void engine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result == null) return;
            //Console.WriteLine(e.Result.Text + "\n");
            //Console.WriteLine(e.Result.Grammar.Name + "\n");
            gbEX.ExecutionHandler(e);
            Console.Write(SpeechHandler.UtterResponse()+"\n");
            SpeechHandler.speechSynthesizer.SpeakAsync(SpeechHandler.UtterResponse());
            SpeechHandler.SetResponse("");
            if (ByeJarvis == 1)
                ByeJarvis=2;
        }
    }
}
