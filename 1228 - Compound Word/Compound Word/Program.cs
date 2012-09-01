using System;
using System.Collections.Generic;

namespace Compound_Word
{
    enum Direction
    {
        Rigth, Left
    }

    public class AVL_Node<T> where T : IComparable
    {
        public T Key;
        public AVL_Node<T> Left;
        public AVL_Node<T> Rigth;

        public IEnumerable<T> InOrden()
        {
            if (Left != null)
            {
                foreach (T item in Left.InOrden())
                    yield return item;
            }

            yield return Key;

            if (Rigth != null)
            {
                foreach (T item in Rigth.InOrden())
                    yield return item;
            }
        }
        public IEnumerable<T> PreOrden()
        {
            yield return Key;
            if (Left != null)
            {
                IEnumerable<T> l = Left.PreOrden();
                foreach (T item in l)
                    yield return item;
            }
            if (Rigth != null)
            {
                IEnumerable<T> r = Rigth.PreOrden();
                foreach (T item in r)
                    yield return item;
            }
        }
        public IEnumerable<T> EmptyEnum()
        {
            return new T[0];
        }

        public int Size;
        public int Height;
        public int Balance_Factor
        {
            get
            {
                if (Left == null && Rigth == null)
                    return 0;
                if (Left == null)
                    return Rigth.Height;
                if (Rigth == null)
                    return -Left.Height;
                return Rigth.Height - Left.Height;
            }
        }
        public void Update()
        {
            if (Left == null && Rigth == null)
            {
                Height = 1;
                Size = 1;
            }
            else if (Left == null)
            {
                Height = 1 + Rigth.Height;
                Size = 1 + Rigth.Size;
            }
            else if (Rigth == null)
            {
                Height = 1 + Left.Height;
                Size = 1 + Left.Size;
            }
            else
            {
                Height = 1 + Math.Max(Left.Height, Rigth.Height);
                Size = Left.Size + Rigth.Size + 1;
            }
        }
    }

    public class AVL_Tree<T> where T : IComparable
    {
        private AVL_Node<T> Insert(AVL_Node<T> x, T item)
        {
            if (x == null)
            {
                x = new AVL_Node<T> ();
                x.Key = item;
                x.Height = 1; 
                x.Size = 1; 
                x.Left = null; 
                x.Rigth = null ;
                Count++;
            }
            else
            {
                if (item.CompareTo(x.Key) == 0) return x;

                if (item.CompareTo(x.Key) < 0)
                    x.Left = Insert(x.Left, item);
                else
                    x.Rigth = Insert(x.Rigth, item);

                x = Balance(x);
            }

            return Balance(x);
        }
        private AVL_Node<T> Balance(AVL_Node<T> x)
        {
            x.Update();

            if (x.Balance_Factor > 1)
            {
                if (x.Rigth.Balance_Factor <= 0)
                    x.Rigth = Rotate(x.Rigth, Direction.Rigth);
                x = Rotate(x, Direction.Left);
            }
            else
                if (x.Balance_Factor < -1)
                {
                    if (x.Left.Balance_Factor >= 0)
                        x.Left = Rotate(x.Left, Direction.Left);
                    x = Rotate(x, Direction.Rigth);
                }

            x.Update();
            return x;
        }
        private AVL_Node<T> Rotate(AVL_Node<T> x, Direction direction)
        {
            AVL_Node<T> y;

            if (direction == Direction.Left) // left
            {
                if (x == null || x.Rigth == null) return x;

                y = x.Rigth;
                x.Rigth = y.Left;
                y.Left = x;
            }
            else // right
            {
                if (x == null || x.Left == null) return x;

                y = x.Left;
                x.Left = y.Rigth;
                y.Rigth = x;
            }

            x.Update();
            y.Update();

            return y;
        }
        public AVL_Tree()
        {
            C_Root = null;
        }
        public AVL_Tree(params T[] data)
            : this()
        {
            foreach (T item in data)
                Add(item);
        }

        public int Count;
        public void Add(T item)
        {
            C_Root = Insert(C_Root, item);
        }
        public AVL_Node<T> Contains(T item)
        {
            AVL_Node<T> x = C_Root;
            for (; ; )
            {
                if (x == null) return null;
                if (item.CompareTo(x.Key) == 0) return x;

                x = item.CompareTo(x.Key) < 0 ? x.Left : x.Rigth;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return Count > 0 ? InOrden().GetEnumerator() : C_Root.EmptyEnum().GetEnumerator();
        }
        public T Root { get { return C_Root.Key; } }
        public AVL_Node<T> C_Root;
        public IEnumerable<T> InOrden()
        {
            return Count > 0 ? C_Root.InOrden() : C_Root.EmptyEnum();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = new List<string>();
            AVL_Tree<string> com = new AVL_Tree<string>();
            AVL_Tree<string> result = new AVL_Tree<string>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == null)
                    break;

                if (com.Contains(line) != null)
                    result.Add(line);

                for (int i = 0; i < data.Count; i++)
                {
                    string c1 = line + data[i];
                    string c2 = data[i] + line;
                    if (com.Contains(c1) != null)
                    {
                        result.Add(c1);
                    }
                    else
                        com.Add(c1);
                    if (com.Contains(c2) != null)
                    {
                        result.Add(c2);
                    }
                    else
                        com.Add(c2);
                }
                data.Add(line);
                com.Add(line);
            }

            foreach (string item in result)
                Console.WriteLine(item);
        }
    }
}
