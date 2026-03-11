using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;

namespace Fileuril
{
    internal class Program
    {
        static void Setreg()
        {

        }
        static void Main(string[] args)
        {

            Thread.GetDomain().SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            var pri = (WindowsPrincipal)Thread.CurrentPrincipal;

            //管理者権限以外での起動なら, 別プロセスで本アプリを起動する
            if (!pri.IsInRole(WindowsBuiltInRole.Administrator))
            {
                var proc = new ProcessStartInfo()
                {
                    FileName=Environment.ProcessPath,
                    Verb = "RunAs"
                };
                Process.Start(proc);
                return;




            }
            Console.WriteLine("Hello!");
            Console.ReadLine();
        }
            static void WriteTitle(string name, ConsoleColor color, ConsoleColor textcolor)
            {
                var oldcolor = Console.BackgroundColor;
                var textold = Console.ForegroundColor;
                Console.ForegroundColor = textcolor;
                Console.BackgroundColor = color;
                Console.WriteLine(name);
                Console.ForegroundColor = textold;
                Console.BackgroundColor = oldcolor;
            }
            static void AnimateEriteLine(string text, ConsoleColor color, int duration)
            {
                var textold = Console.ForegroundColor;
                Console.ForegroundColor = color;
                foreach (var item in text)
                {
                    Console.Write(item);
                    Thread.Sleep(duration);
                }
                Console.ForegroundColor = textold;
            }
        
    }
}