using System;
using System.Collections.Generic;
using System.Text;

namespace Group_Reverse
{
    class Program
    {
        static IEnumerable<char> Reverse(string x)
        {
            for (int i = x.Length - 1; i >= 0; i--)
                yield return x[i];
        }

        static void Main(string[] args)
        {
            int t = 0;
            while (true)
            {
                string[] line = Console.ReadLine().Split(' ');
                if (line[0] == "0") break;
                t = int.Parse(line[0]);
                string cad = line[1];
                int i = 0;
                while (i < cad.Length)
                {
                    string s = cad.Substring(i, t);
                    s = new string(new List<char>(Reverse(s)).ToArray());
                    Console.Write(s);
                    i += t;
                }
                Console.WriteLine();
            }
        }
    }
}
