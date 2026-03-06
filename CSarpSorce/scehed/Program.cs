using System.Net.Http.Headers;

namespace scehed
{

    class Program
    {
        static void Main(string[] args)
        {
            var s = Directory.EnumerateFiles(@"c:\");
            foreach (var fs in s.Where((s) => s.EndsWith(".txt")))
            {
                Console.WriteLine(fs);
            }
           
        }

    }
    class gen<type>
    {
        gen(type type)
        {
            var d=typeof(type);
        }
    }
  
}
