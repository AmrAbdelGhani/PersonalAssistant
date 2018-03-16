#region using directives
using System.Speech.Recognition;
using System;
#endregion

namespace IntentRecognition
{
    //GrammarBuilderExtractor
    class GBExtractor
    {
        public void ExecutionHandler(SpeechRecognizedEventArgs e)
        {
            RecognitionResult msg = e.Result;
            switch (e.Result.Grammar.Name)
            {
                case "type": Type(msg); break;
                case "keyboardcommand": KeyboardCommand(msg); break;
                case "search": Search(msg); break;
                case "opener": Opener(msg); break;
                case "converter": Converter(msg); break;
                case "randomnum": RandomNum(msg); break;
                case "randomgame": RandomGame(); break;
                case "greeting": Greeting(); break;
                case "farewell": Farewell(); break;
                case "showtime": ShowTime(); break;
                case "checkinternet": CheckInternet();  break;
                case "complement": Complement(); break;
                case "screenshot": Screenshot(); break;
                case "reader": Reader(); break;
                case "friday": Friday(); break;
                case "whois": Search(msg); break;
                case "music": PlaySong(); break;
                case "playlist": PlayList(); break;
                case "musiccommand": MusicCommand(msg); break;
                case "weather": Weather(); break;
            }

        }
        #region extraction
        public void Opener(RecognizedPhrase e)
        {
            int len = e.Words.Count;
            string app = e.Words[len - 1].Text;
            try
            {
                SpeechHandler.SetResponse(Processor.Opener(app) + app);
            }
            catch (Exception)
            {
                SpeechHandler.Invalid();
            }
        }
        public void RandomNum(RecognizedPhrase e)
        {
            int len = e.Words.Count;
            string numOne = e.Words[len - 3].Text;
            string numTwo = e.Words[len - 1].Text;
            try
            {
                SpeechHandler.SetResponse(Processor.RandomNum(numOne, numTwo));
            }
            catch(Exception)
            {
                SpeechHandler.Invalid();
            }
        }
        public void Search(RecognizedPhrase e)
        {
            int len = e.Words.Count;
            string searchprompt = e.Text.Substring(e.Text.IndexOf(":") + 1);
            try
            {
                SpeechHandler.SetResponse(Processor.Search(searchprompt));
            }
            catch (Exception)
            {
                SpeechHandler.Invalid();
            }
        }
        public void Type(RecognizedPhrase e)
        {
            string tobeTyped = e.Text.Substring(e.Text.IndexOf("this") + 4);
            try
            {
                Processor.Type(tobeTyped);
            }
            catch (Exception)
            {
                SpeechHandler.Invalid();
            }
        }
        public void KeyboardCommand(RecognizedPhrase e)
        {    
            try
            {
                SpeechHandler.SetResponse(Processor.KeyboardCommand(e.Text));
            }
            catch (Exception)
            {
                SpeechHandler.Invalid();
            }
        }
        public void RandomGame()
        {
            try
            {
                SpeechHandler.SetResponse(Processor.RandomGame());
            }
            catch (Exception)
            {
                SpeechHandler.Invalid();
            }
        }
        public void Greeting()
        {
            try
            {
                SpeechHandler.SetResponse(Processor.Greeting());
            }
            catch (Exception)
            {
                SpeechHandler.Invalid();
            }
        }
        public void Farewell()
        {
            try
            {
                SpeechHandler.SetResponse(Processor.Farewell());
            }
            catch (Exception)
            {
                SpeechHandler.Invalid();
            }
        }
        public void ShowTime()
        {
            try
            {
                SpeechHandler.SetResponse(Processor.ShowTime());
            }
            catch (Exception)
            {
                SpeechHandler.Invalid();
            }
        }
        public void Complement()
        {
            try
            {
                SpeechHandler.SetResponse(Processor.Complement());
            }
            catch (Exception)
            {
                SpeechHandler.Invalid();
            }
        }
        public void Screenshot()
        {
            try
            {
                SpeechHandler.SetResponse(Processor.Screenshot());
            }
            catch (Exception)
            {
                SpeechHandler.Invalid();
            }
        }
        public void Reader()
        {
            try
            {
                SpeechHandler.SetResponse(Processor.Reader());
            }
            catch (Exception)
            {
                SpeechHandler.Invalid();
            }
        }
        public void CheckInternet()
        {
            try
            {
                SpeechHandler.SetResponse(Processor.CheckInternet());
            }
            catch (Exception)
            {
                SpeechHandler.Invalid();
            }
        }
        public void Converter(RecognizedPhrase e)
        {
            string num = e.Words[e.Words.Count - 1].Text;
            try
            {
                SpeechHandler.SetResponse(Processor.Converter(e.Text, num));
            }
            catch (Exception)
            {
                SpeechHandler.Invalid();
            }
        }
        public void Friday()
        {
            try
            {
                SpeechHandler.SetResponse(Processor.Friday());
            }
            catch (Exception)
            {
                SpeechHandler.Invalid();
            }
        }
        public void PlaySong()
        {
            try
            {
                SpeechHandler.SetResponse(Processor.PlaySong());
            }
            catch (Exception)
            {
                SpeechHandler.Invalid();
            }
        }
        public void PlayList()
        {
            try
            {
                SpeechHandler.SetResponse(Processor.PlayList());
            }
            catch (Exception)
            {
                SpeechHandler.Invalid();
            }
        }
        public void MusicCommand(RecognizedPhrase e)
        {
            try
            {
                SpeechHandler.SetResponse(Processor.MusicCommand(e.Text));
            }
            catch (Exception)
            {
                SpeechHandler.Invalid();
            }
        }
        public void Weather()
        {
            try
            {
                string home = "Cairo";
                SpeechHandler.SetResponse(Processor.Weather(home));
            }
            catch (Exception)
            {
                SpeechHandler.Invalid();
            }
        }

        #endregion
    }
}
