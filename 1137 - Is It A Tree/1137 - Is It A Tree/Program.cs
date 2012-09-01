using System;
using System.Collections.Generic;

namespace _1137___Is_It_A_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCase = 0;
            while (true)
            {
                numberCase++;
                List<int> node = new List<int>();
                int nAristas = 0;

                while (true)
                {
                    string xLine = Console.ReadLine();
                    if (xLine == "")
                    {
                        if (node.Count == nAristas - 1)
                            Console.WriteLine("Case " + numberCase + " is a tree");
                        else
                            Console.WriteLine("Case " + numberCase + " is not a tree");
                        break;
                    }
                    string[] line = xLine.Split(' ');
                    if (int.Parse(line[0]) < 0 && int.Parse(line[1]) < 0)
                    {
                        if (node.Count == nAristas - 1)
                            Console.WriteLine("Case " + numberCase + " is a tree");
                        else
                            Console.WriteLine("Case " + numberCase + " is not a tree");
                        return;
                    }

                    for (int i = 0; i < line.Length; i++)
                    {
                        int x = int.Parse(line[i]);
                        int y = int.Parse(line[i + 1]);
                        if (x == 0 && y == 0)
                            break;

                        i++;
						bool f1 = true, f2 = true;
                        if (!node.Contains(x)) 
						{
							node.Add(x);
							f1 = false;
						}
                        if (!node.Contains(y))
						{
							node.Add(y);
							f2 = false;
						}
						if (f1 || f2)
							nAristas++;
                    }
                }
                
            }
        }
    }
}
