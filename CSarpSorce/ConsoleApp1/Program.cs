using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ConsoleApp1.Properties;
using Extensions;
namespace ConsoleApp1
{
    internal class Program
    {
        public static async Task test()
        {
           
        }
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);
        [STAThread]
        static void Main(string[] args)//Write Program Finish up
        {
            var mi = Cursor;
            Thread thread = new Thread(new ThreadStart(Cursor)  );
            Console.Beep(1000, 1000); thread.Start();
            Console.WriteLine("wait");
            Console.ReadLine();
            Console.WriteLine(typeof(StringWriter));
            return;
        }
        public static void Cursor()
        {
            Stopwatch watch = new Stopwatch();
            for (watch.Start();watch.ElapsedMilliseconds/1000<10;)
            {
                Extensions.MyClass.mouse_event((uint)codes.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
               Extensions.MyClass.mouse_event((uint)Extensions.codes.MOUSEEVENTF_MOVE, 1, 0, 0, 0);
            }
            return;
        }
    }
}
