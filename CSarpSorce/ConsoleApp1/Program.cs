using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace ConsoleApp1
{
    internal class Program
    {
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);
        [STAThread]
        static void Main(string[] args)//Write Program Finish up
        {
            Thread thread = new Thread(new ThreadStart(Cursor)  );thread.Start();
            Console.WriteLine("wait");
            Console.ReadLine();
            return;
        }
        public static void Notepad()
        {
            Process.Start(@"c:\windows\notepad");
        }
        public static void Cursor()
        {
            Console.Beep(1000, 1000);
            for (int c=0; c<50*20*40; c++)//40 Second
            {
                SetCursorPos(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y);
                Console.WriteLine("a");
                Thread.Sleep(50);
            }
            return;
        }
    }
}
