using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
namespace IntentRecognition
{
    class MusicManager
    {
        public const int WM_COMMAND = 0x111;
        private static int iHandle=0;
        public static void Stop()
        {

            WindowsManager.SendMessage(iHandle, WM_COMMAND, 0x00004979, 0x00000000);
        }
        public static void VolUp(int count)
        { 
            for(int i=0;i<count;i++)
            WindowsManager.SendMessage(iHandle, WM_COMMAND, 0x0000497F, 0x00000000);
        }
        public static void VolDown(int count)
        {
            for (int i = 0; i < count; i++)
                WindowsManager.SendMessage(iHandle, WM_COMMAND, 0x00004980, 0x00000000);
        }
        public static void Next()
        {
            WindowsManager.SendMessage(iHandle, WM_COMMAND, 0x0000497B, 0x00000000);
        }
        public static void Previous()
        {
            WindowsManager.SendMessage(iHandle, WM_COMMAND, 0x0000497A, 0x00000000);
        }
        public static void Play_Pause()
        {

            WindowsManager.SendMessage(iHandle, WM_COMMAND, 0x00004978, 0x00000000);
        }
        public static void Repeat()
        {
            WindowsManager.SendMessage(iHandle, WM_COMMAND, 0x0000499B, 0x00000000);
        }
        public static void Mute()
        {
            WindowsManager.SendMessage(iHandle, WM_COMMAND, 0x00004981, 0x00000000);
        }
        public static void  getHandle()
        {
            iHandle = WindowsManager.FindWindow("WMPlayerApp", "Windows Media Player");
        }

    }
}
