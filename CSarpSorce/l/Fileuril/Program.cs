using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using Fileuril.Properties;
using Microsoft.Win32;
namespace Fileuril
{
    internal class Program
    {
        static void Setreg()
        {

        }
        static void Main(string[] args)
        {
            Console.WriteLine(Registry.LocalMachine.GetValue(@"SOFTWARE\Classes\AllFilesystemObjects\shell\FileInfo") == null ? "nullptr" : "");
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
            static void AnimateWriteLine(string text, ConsoleColor color, int duration)
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