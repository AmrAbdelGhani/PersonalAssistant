using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net.NetworkInformation;
namespace IntentRecognition
{
    class WindowsManager
    {
        #region localDlls
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        private const uint WM_CLOSE = 0x0010;
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        #endregion
        public static bool SetFocusToExternalApp(string strProcessName)
        {
            Process[] arrProcesses = Process.GetProcessesByName(strProcessName);
            if (arrProcesses.Length > 0)
            {

                IntPtr ipHwnd = arrProcesses[0].MainWindowHandle;
                Thread.Sleep(100);
                SetForegroundWindow(ipHwnd);
                return true;
            }
            return false;
        }
        //API-declaration
        public static void EnsureFocus(string windowName, string procName)
        {
            while (!GetActiveWindowTitle().ToLower().Contains(windowName))
            { SetFocusToExternalApp(procName); }
        }
        public static string saveScreenShot()
        {
            string procName = LaunchProcess("mspaint.exe");         
            EnsureFocus("paint", procName);
            string x;
            x = DateTime.Now.ToString();
            x = x.Replace('/', '-');
            x = x.Replace(':', '_');
            SendKeys.SendWait("^(v)");
            SendKeys.SendWait("^(s)");
            SendKeys.SendWait(@"C:\Users\Amr\Desktop\Top Secret\SpeechRecognition\ScreenShots\" + x + ".png");
            SendKeys.SendWait("{ENTER}");
            SendKeys.SendWait("%{F4}");
            return "";
        }
        private static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }
        public static void CloseActiveWindow()
        {
            const int nChars = 256;
            IntPtr handle;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = GetForegroundWindow();
            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                Console.WriteLine(Buff.ToString() + "\n");
                SendMessage(handle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }
        }
        public static string CheckInternet()
        {
            Ping myPing = new Ping();
            String host = "google.com";
            byte[] buffer = new byte[32];
            int timeout = 350;
            PingOptions pingOptions = new PingOptions();
            PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
            PingReply reply2 = myPing.Send(host, 1000, buffer, pingOptions);
            if (reply2.Status != IPStatus.Success)
                return("Sir, you have been disconnected");
            else if (reply.Status != IPStatus.Success)
                return ("Sir, you are lagging terribly");
            else return ("Sir, Your internet is fine");
        }
        #region usefulFunctiions
        public static string LaunchProcess(string msg)
        {
            Process proc = new Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = msg;
            proc.Start();
            try
            {
                Console.Write(proc.ProcessName);
                return proc.ProcessName;
            }
            catch (Exception) { return ""; }
        }
        #endregion


        #region win32
        [DllImport("User32.dll")]
        public static extern int FindWindow(string strClassName, string strWindowName);
        [DllImport("User32.dll")]
        public static extern int FindWindowEx(int hwndParent, int hwndChildAfter, string strClassName, string strWindowName);
        [DllImport("User32.dll")]
        public static extern int SendMessage(
            int hWnd,               // handle to destination window
            int Msg,                // message
            int wParam,             // first message parameter
            [MarshalAs(UnmanagedType.LPStr)] string lParam); // second message parameter

        [DllImport("User32.dll")]
        public static extern int SendMessage(
            int hWnd,               // handle to destination window
            int Msg,                // message
            int wParam,             // first message parameter
            int lParam);            // second message parameter

        #endregion
    }
}
