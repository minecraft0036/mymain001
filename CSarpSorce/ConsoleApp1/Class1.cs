using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
namespace Extensions
{
    enum codes:uint
    {
        MOUSEEVENTF_LEFTDOWN =  0x0002
        , MOUSEEVENTF_LEFTUP = 0x0004
            , MOUSEEVENTF_RIGHTDOWN = 0x0008
            , MOUSEEVENTF_RIGHTUP = 0x0010
            , MOUSEEVENTF_MOVE = 0x0001
    }

    public class MyClass
    {
        public const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        public const uint MOUSEEVENTF_LEFTUP = 0x0004;
        public const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        public const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        public const uint MOUSEEVENTF_MOVE = 0x0001;
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);//click info,move px,move,hoill:0,0
    }
   public class Storage: IDisposable //on This Program Dispose = finish or clear. I Just want to use "using directive" and I want to use cool interface!
    {
        public void Dispose()
        {
            
        }
        public Storage(string name,bool IsPassAutogen)
        {
            this.Name = name;
            if (IsPassAutogen)
            {
                var va=RandomNumberGenerator.GetBytes(32);
                this.Encrypted = Convert.ToBase64String(va);
                this.Name = name;
                this.ID = Guid.NewGuid().ToString();
            }
        }
        public Storage(string name,string pass,string ID) { this.Encrypted = pass;this.Name = name;this.ID = ID; }
        public string Encrypted { get; init { field = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(field))); } }
        public string Name { init; get; }
        public string ID { get; init; }
    }
}
