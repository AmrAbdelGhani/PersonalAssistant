#region using directives
using System.Speech.Recognition;
using System.IO;
using System;
using System.Collections.Generic;
#endregion

namespace IntentRecognition
{
    class GBLibrary
    {
        #region locals
        private Choices numbers = new Choices();
        Choices friday = new Choices(new string[] { "Friday", " " });
        private static Choices myApps = new Choices(Reference.readList);
        private Choices myGames = new Choices();
        private Choices People = new Choices();
        #endregion
        #region ctor
        public GBLibrary()
        {
            try {
            for (int i = 0; i < 1000; i++) numbers.Add(i.ToString());
            foreach (string e in Reference.FamousPeople) if(e!="") People.Add(e);
        }
        catch(Exception e)
            {
                Console.Write(e.ToString());
            }
        }
        #endregion
        #region grammarReference
        #region random
        public Grammar RandomNum()
        {
 
                
            Choices request = new Choices(new string[] { "give me a", "i need a", "pick a"});
            Choices randomNum = new Choices(new string[] { "number", "random number"});
            Choices loc = new Choices(new string[] { "from", "between", "within" });
            Choices btw = new Choices(new string[] { "and", "to" });
            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append(request);
            findServices.Append(randomNum);
            findServices.Append(loc);
            findServices.Append(numbers);
            findServices.Append(btw);
            findServices.Append(numbers);

            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);

            servicesGrammar.Name = "randomnum";
            return servicesGrammar;
        }
        public Grammar RandomGame()
        {
            Choices request = new Choices(
                new string[] { "what should I play", "give me a game to play", "pick a game", "pick a game for me to play"});
            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append(request);

            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);

            servicesGrammar.Name = "randomgame";
            return servicesGrammar;
        }
        #endregion
        #region search
        public Grammar Search()
        {           
            Choices request = new Choices(new string[] 
            { "search google for: ", "search for: ", "look for: "});
            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append(friday);
            findServices.Append(request);
            findServices.AppendDictation();
            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);
            servicesGrammar.Name = "search";
            return servicesGrammar;
        }
        public Grammar WhoIs()
        {           
            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append(friday);
            findServices.Append("who is: ");
            findServices.Append(People);
            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);
            servicesGrammar.Name = "whois";
            return servicesGrammar;
        }
        #endregion
        #region conversation
        public Grammar Greeting()
        {
            Choices greeting = new Choices(new string[] { "hello ", "good morning ", "good afternoon ", "good evening ",
                "Wakey wakey ","greetings " });

            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append(greeting);
            findServices.Append(friday);

            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);

            servicesGrammar.Name = "greeting";
            return servicesGrammar;
        }
        public Grammar Farewell()
        {

            Choices farewell = new Choices(new string[] { "goodbye", "farewell", "you have got to go", "power down", "bye bye" });
            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append(farewell);
            findServices.Append(friday);
            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);
            servicesGrammar.Name = "farewell";
            return servicesGrammar;
        }
        public Grammar Complement()
        {

            Choices comp = new Choices(new string[]
                { "thanks", "thank you", "good job","nice job","well done","great job","nice", "you're great"});
            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append(comp);
            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);
            servicesGrammar.Name = "complement";
            return servicesGrammar;
        }
        #endregion
        #region music
        public Grammar PlaySong()
        {
            Choices fill = new Choices(new string[]
                { "a","a random", "some", " "});
            Choices music = new Choices(new string[]
                { "song","soundtrack","something", "music"});
            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append("Play");
            findServices.Append(fill);
            findServices.Append(music);
            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);
            servicesGrammar.Name = "music";
            return servicesGrammar;
        }
        public Grammar PlayList()
        {
            Choices play = new Choices(new string[]
                { "start","play", "begin"});
            Choices fill = new Choices(new string[]
                { "my"," "});
            Choices music = new Choices(new string[]
                { "playlist","album","songs"});
            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append(play);
            findServices.Append(fill);
            findServices.Append(music);
            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);
            servicesGrammar.Name = "playlist";
            return servicesGrammar;
        }
        public Grammar MusicCommand()
        {

            Choices mcommand = new Choices(new string[]
                { "playback", "previous", "repeat", "last song", "pause", "pause music","resume","next","next song","change song","stop music",
                    "up", "down", "mute", "lower volume", "volume up", "volume down", "unmute", "increase volume"});
            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append(mcommand);
            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);
            servicesGrammar.Name = "musiccommand";
            return servicesGrammar;
        }
        #endregion
        public Grammar Opener()
        {
            
            Choices request = new Choices(new string[] { "open", "initiate", "launch","begin","commence","start" });
            Choices plead = new Choices(new string[] { "please", "can you", "can you please", "i need you to", " "});
            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append(friday);
            findServices.AppendDictation();
            findServices.Append(plead);
            findServices.Append(request);
            findServices.Append(myApps);
            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);
            servicesGrammar.Name = "opener";
            return servicesGrammar;
        }
        public Grammar Converter()
        {
            
            Choices request = new Choices(new string[] { "Find", "give me", "What's"});
            Choices digitrep = new Choices(new string[] { "hexadecimal", "decimal", "binary" });
            GrammarBuilder findServices = new GrammarBuilder(); 
            findServices.Append(request);
            findServices.Append("the");
            findServices.Append(digitrep);
            findServices.Append("of");
            findServices.AppendDictation();
            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);
            servicesGrammar.Name = "converter";
            return servicesGrammar;
        }
        
        
        public Grammar ShowTime()
        {
            
            Choices time = new Choices(new string[] { "is the time", "time is it", "is the hour on the clock", "hour is it" });
            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append(friday);
            findServices.Append("what");
            findServices.Append(time);
            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);
            servicesGrammar.Name = "showtime";
            return servicesGrammar;
        }
        public Grammar KeyboardCommand()
        {
            
            Choices kcommand = new Choices(new string[]
                { "copy","paste","select all","delete selection","open new","enter", "close", "save", "tab"});
            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append(kcommand);
            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);
            servicesGrammar.Name = "keyboardcommand";
            return servicesGrammar;
        }
        public Grammar CheckInternet()
        {
             
            Choices question = new Choices(new string[]
                { "am I lagging","check my internet","how's my internet",
                    "did i disconnect","I'm lagging","what is this lag"});
            Choices connection = new Choices(new string[]
                { "connection"," "});
            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append(friday);
            findServices.Append(question);
            findServices.Append(connection);
            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);
            servicesGrammar.Name = "checkinternet";
            return servicesGrammar;
        }
        public Grammar Type()
        {
            
            Choices type = new Choices(new string[]
                { "type this","write this"});
            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append(type);
            findServices.AppendDictation();
            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);
            servicesGrammar.Name = "type";
            return servicesGrammar;
        }        
        public Grammar Screenshot()
        {
            Choices comp = new Choices(new string[]
                { "capture","capture screen","screenshot window","take a screenshot","capture this"});
            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append(comp);
            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);
            servicesGrammar.Name = "screenshot";
            return servicesGrammar;
        }
        public Grammar Reader()
        {
            
            Choices read = new Choices(new string[]
                { "can you read it","read this","read selection","read","read it","what does it say","narrate it"});
            Choices forme = new Choices(new string[] { "for me", " " });
            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append(read);
            findServices.Append(forme);
            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);
            servicesGrammar.Name = "reader";
            return servicesGrammar;
        }
        public Grammar Friday()
        {
            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append("Friday");
            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);
            servicesGrammar.Name = "friday";
            return servicesGrammar;
        }
        
        public Grammar Weather()
        {
            Choices question = new Choices(new string[]
                { "what","how","is" });
            Choices p2 = new Choices(new string[]
                { "is the weather like","is the weather:","cold is it","hot is it","it raining","it cold", "it hot" });
            GrammarBuilder findServices = new GrammarBuilder();
            findServices.Append(question);
            findServices.Append(p2);
            // Create a Grammar object from the GrammarBuilder and load it to the recognizer.
            Grammar servicesGrammar = new Grammar(findServices);
            servicesGrammar.Name = "weather";
            return servicesGrammar;
        }
        #endregion
    }
}