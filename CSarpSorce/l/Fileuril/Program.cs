namespace Fileuril
{
    internal class Program
    {
        static void Setreg()
        {

        }
        static void Main(string[] args)
        {
            
            WriteTitle("Extractor",ConsoleColor.DarkGreen,ConsoleColor.DarkRed);Console.Title = "extractor";Console.CursorVisible = false;
            AnimateEriteLine("minecraft", ConsoleColor.Blue, 80);
            Console.Title = "Extractor";

        }
        static void WriteTitle(string name,ConsoleColor color,ConsoleColor textcolor)
        {
            var oldcolor = Console.BackgroundColor;
            var textold = Console.ForegroundColor;
            Console.ForegroundColor = textcolor;
            Console.BackgroundColor=color;
            Console.WriteLine(name);
            Console.ForegroundColor = textold;
            Console.BackgroundColor = oldcolor;
        }
        static void AnimateEriteLine(string text,ConsoleColor color,int duration)
        {
            var textold = Console.ForegroundColor;
            Console.ForegroundColor=color;
            foreach (var item in text)
            {
                Console.Write(item);
                Thread.Sleep(duration);
            }
            Console.ForegroundColor = textold;
        }
    }
}
