using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class ExpressionOfSet
    {
        static int[] parent;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int n = int.Parse(str[0]);
            int m = int.Parse(str[1]);

            parent = new int[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                parent[i] = i;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < m; i++)
            {
                str = Console.ReadLine().Split(" ");
                int operation = int.Parse(str[0]);
                int a = int.Parse(str[1]);
                int b = int.Parse(str[2]);

                if (operation == 1)
                {
                    sb.Append(IsSameParent(a, b) ? "YES" : "NO").Append("\n");
                } else
                {
                    if (!IsSameParent(a,b))
                    {
                        Union(a, b);
                    }
                }
            }

            Console.Write(sb.ToString());
        }

        static int Find(int x)
        {
            if (x == parent[x])
            {
                return x;
            }

            return parent[x] = Find(parent[x]);
        }

        static void Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);

            if (x != y)
            {
                if (x < y)
                {
                    parent[y] = x;
                } else
                {
                    parent[x] = y;
                }
            }
        }

        static bool IsSameParent(int x, int y)
        {
            x = Find(x);
            y = Find(y);

            return x == y;
        }
    }
}
