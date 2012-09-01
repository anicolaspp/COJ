using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finding_Secret_Santa
{
    class Pair : IComparable<Pair>
    {
        public string x, y;
        public Pair(string x, string y)
        {
            this.x = x;
            this.y = y;
        }

        public int CompareTo(Pair other)
        {
            if (x.CompareTo(other.x) == 0 && y.CompareTo(other.y) == 0)
                return 0;
            return -1;
        }
    }

    class Program
    {
        static string Adj(string v, List<Pair> names)
        {
            foreach (Pair item in names)
            {
                if (item.x == v)
                    return item.y;
            }
            return "";//nunca pasa
        }

        static int index(Pair p, List<Pair> names)
        {
            for (int i = 0; i < names.Count; i++)
            {
                if (p.CompareTo(names[i]) == 0)
                    return i;
            }
            return -1;
        }

        static void D(List<Pair> names, string v)
        {
            if (names.Count == 0)
                return;
            else
            {
                string dst = Adj(v, names);
                int idx = index(new Pair(v, dst), names);
                if (idx < 0)
                    return;
                names.RemoveAt(idx);
                D(names, dst);
            }
        }

        static void Main(string[] args)
        {
            int k = 1;
            while (true)
            {
                int t = int.Parse(Console.ReadLine());
                if (t == 0) return;

                List<Pair> names = new List<Pair>();
                for (int i = 0; i < t; i++)
                {
                    string[] line = Console.ReadLine().Split(' ');
                    names.Add(new Pair(line[0], line[1]));
                }

                int count = 0;
                while (names.Count > 0)
                {
                    D(names, names[0].x);
                    count++;
                }

                Console.WriteLine(k.ToString() + " " + count);
                k++;
            }

        }
    }
}
