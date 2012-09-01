using System;
using System.Collections.Generic;
using System.Text;

namespace _1189___Skew_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "0")
                    return;

                long x = long.Parse(line[0].ToString());

                for (int i = 1; i < line.Length; i++)
                    x = (x * 4) + long.Parse(line[i].ToString());

                Console.WriteLine(x);
            }
        }
    }
}
