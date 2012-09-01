using System;
using System.Collections.Generic;

namespace Words
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> dict = new List<string>();

            int t = int.Parse(Console.ReadLine());
            for (int j = 0; j < t; j++)
            {
                int max = 0;
                int p = int.Parse(Console.ReadLine());
                for (int k = 0; k < p; k++)
                {
                    string w = Console.ReadLine();
                    int n = dict.Count;
                    for (int i = 0; i < n; i++)
                    {
                        if (dict[i][dict[i].Length - 1] == w[0])
                        {
                            dict.Add(dict[i] + w);
                            max = Math.Max(max, (dict[i] + w).Length);
                        }
                        if (dict[i][0] == w[w.Length - 1])
                        {
                            dict.Add(w + dict[i]);
                            max = Math.Max(max, (dict[i] + w).Length);
                        }
                    }
                    dict.Add(w);
                    max = Math.Max(max, w.Length);
                }
                Console.WriteLine(max);
            }
        }
    }
}
