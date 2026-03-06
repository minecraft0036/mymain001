using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace scehed
{
    internal class Extensions
    {
        //<summary>
        //thread safe
        //</summary>

        public static async Task AnimateWriteLine(string Line,int interval)
        {
            foreach (var Write in Line)
            {
                Console.Write(Write);
                Thread.Sleep(interval);
            }
            Console.Write('\n');
        }
    }
}
