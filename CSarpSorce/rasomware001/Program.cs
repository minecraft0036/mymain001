using System.Security.Cryptography;
using System.Text;

namespace File_String_Encrypt
{
    internal class Program
    {

        static void Main(string[] args)
        {
            try
            {
                if (args.Length==2)
                {

                    void Recurse(string Path)
                    {
                      foreach(var item in  Directory.EnumerateDirectories(Path)) { 
                        Recurse(item);
                        }
                      foreach (var item in Directory.EnumerateFiles(Path)) {
                            Ex.decryptFiles(item, args[0], args[1]);
                        }
                    }
                    Recurse(Environment.CurrentDirectory);
                }
                else
                {
                    var df = AesCng.Create(); df.GenerateIV(); df.GenerateKey();
                    Console.WriteLine("Key {0}\n IV: {1}", Convert.ToBase64String(df.Key), Convert.ToBase64String(df.IV));
                    EncryptFileRecurse(Environment.CurrentDirectory,df.Key,df.IV);
                }
            }
            catch (IndexOutOfRangeException)
            {
                Ex.WriteLineAsColor(ConsoleColor.Red, "Useage:,<IV>,<Key>");

            }



        }
        static void EncryptFileRecurse(string FilePath, byte[] key, byte[] iv)
        {

            string[] strings = System.IO.Directory.GetFiles(FilePath);
            foreach (string s in strings)
            {
                Ex.encryptFile(s,key,iv)
                    ; Console.WriteLine(s);
            }
            foreach (string yu in System.IO.Directory.EnumerateDirectories(FilePath))
            {
                try
                {
                    EncryptFileRecurse(yu,key,iv);
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
        public static void encryptFile(string FilePath, byte[] key, byte[] iv)//方法が難しいので自己流
        {
            try
            {
                byte[] d = File.ReadAllBytes(FilePath);
                var df = AesCng.Create(); df.Key=key; df.IV = iv;
                byte[] bytes = df.EncryptCbc(d, df.IV);
                using var g = new FileStream(FilePath, FileMode.Create, FileAccess.Write);
                g.Write(bytes, 0, bytes.Length); g.Close();
               

            }
            catch (Exception excp) { Console.WriteLine(excp.Message); }
        }
        public static void decryptFiles(string FilePath, string IV, string Key)
        {
            try
            {
                byte[] ivBytes = Convert.FromBase64String(IV);
                byte[] keyBytes = Convert.FromBase64String(Key);
                var df = AesCng.Create(); df.IV = ivBytes; df.Key = keyBytes;
                byte[] dec = df.DecryptCbc(File.ReadAllBytes(FilePath), ivBytes);

                // 一時ファイル経由で安全に書き込む
                File.WriteAllBytes(FilePath+".tmp", dec);
                File.Replace(FilePath+".tmp", FilePath, null);
                File.Delete(FilePath + ".tmp");
                Ex.WriteLineAsColor(ConsoleColor.Blue, "Decrypted:" + FilePath);
            }
            catch (Exception ex)
            {
                WriteLineAsColor(ConsoleColor.Red, $"復号失敗: {FilePath} - {ex.Message}");
            }


        }
        public static void WriteLineAsColor(ConsoleColor Color, string Line)
        {
            var d = Console.ForegroundColor;
            Console.ForegroundColor = Color; Console.WriteLine(Line);
            Console.ForegroundColor = d;
        }
    }
}