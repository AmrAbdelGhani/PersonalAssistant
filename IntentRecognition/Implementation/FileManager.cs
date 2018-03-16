using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentRecognition
{
    class FileManager
    {
        public static string [] LoadSongs()
        {
            string filepath = Reference.musicFile;
            DirectoryInfo d = new DirectoryInfo(filepath);
            List<string> songs  = new List<string>();
            foreach (var file in d.GetFiles())
            {
                string q = file.Name.Substring(0,file.Name.Length - ".mp3".Length);
                if(file.Name.Contains(".mp3"))
                songs.Add(q);
            }
            return songs.ToArray();    
        }
    }
}
