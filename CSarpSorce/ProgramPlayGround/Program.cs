using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ProgramPlayGround
{
    internal class Program:Form
    {
        [DllImport("user32.dll")] static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")] static extern bool SetWindowText(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] string lpstring);
        Program() { 
        
        }
        static void Main(string[] args)
        {
          var dg=  new ProcessStartInfo(@"c:\windows\regedit") { Verb="runas"};
           var d= Process.Start(dg);
            d.WaitForInputIdle();Thread.Sleep(1000); d.Refresh();
            while (true)
            {
                Console.WriteLine(d.MainWindowTitle); SetWindowText(d.MainWindowHandle, "Changed");
            }
            Thread.Sleep(1000);
           
            
        }
    }
  
}
