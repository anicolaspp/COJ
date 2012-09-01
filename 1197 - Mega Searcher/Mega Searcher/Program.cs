using System;

namespace Mega_Searcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split('.');
            string[] b = Console.ReadLine().Split('.');

            long x = long.Parse(a[0]), y = long.Parse(b[0]);

            for (int i = 1; i < a.Length; i++)
            {
                x = (x * 256) + long.Parse(a[i]);
                y = (y * 256) + long.Parse(b[i]);
            }

            Console.WriteLine(x - y + 1);
        }
    }
}
