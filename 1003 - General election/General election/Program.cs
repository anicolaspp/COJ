using System;

namespace General_election
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                string[] l = Console.ReadLine().Split(' ');
                long n = long.Parse(l[0]), m = long.Parse(l[1]);

                long[] result = new long[n];
                int x = 0;
                long y = 0;

                for (int j = 0; j < m; j++)
                {
                    l = Console.ReadLine().Split(' ');
                    for (int k = 0; k < n; k++)
                    {
                        result[k] += long.Parse(l[k]);
                        if (result[k] > y)
                        {
                            x = k;
                            y = result[k];
                        }
                    }
                }

                Console.WriteLine(x + 1);
            }
        }
    }
}
