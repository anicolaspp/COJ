using System;
using System.Collections.Generic;
using System.Text;

namespace _1164___Heptadecimal_Numbers
{
    class Program
    {
        static long mParse(char x)
        {
            long tmp;
            if (x == 'A')
                tmp = 10;
            else if (x == 'B')
                tmp = 11;
            else if (x == 'C')
                tmp = 12;
            else if (x == 'D')
                tmp = 13;
            else if (x == 'E')
                tmp = 14;
            else if (x == 'F')
                tmp = 15;
            else if (x == 'G')
                tmp = 16;
            else tmp = long.Parse(x.ToString());

            return tmp;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                string[] line = Console.ReadLine().Split(' ');
                if (line[0] == "*" && line[1] == "*")
                    return;

                long x = mParse(line[0][0]);
                long y = mParse(line[1][0]);

                for (int i = 0; i < line[0].Length; i++)
                {
                    long tmp = mParse(line[0][i]);
                    x = (x * 17) + tmp;
                }

                for (int i = 0; i < line[1].Length; i++)
                {
                    long tmp = mParse(line[1][i]);
                    y = (y * 17) + tmp;
                }

                if (x == y)
                    Console.WriteLine("=");
                else if (x < y)
                    Console.WriteLine("<");
                else
                    Console.WriteLine(">");
            }
        }
    }
}
