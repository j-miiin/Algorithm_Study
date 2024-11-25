using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class GoingTravel
    {
        static int[] parent;

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            parent = new int[N + 1];
            for (int i = 1; i <= N; i++)
            {
                parent[i] = i;  
            }

            int M = int.Parse(Console.ReadLine());
            string[] str;
            for (int i = 0; i < N; i++)
            {
                str = Console.ReadLine().Split(" ");

                for (int j = 0; j < N; j++)
                {
                    if (i == j || int.Parse(str[j]) != 1)
                    {
                        continue;
                    }

                    if (!IsSameParent(i + 1, j + 1))
                    {
                        Union(i + 1, j + 1);
                    }
                }
            }

            str = Console.ReadLine().Split(" ");
            for (int i = 0; i < M - 1; i++)
            {
                int cur = int.Parse(str[i]);
                int next = int.Parse(str[i + 1]);

                if (!IsSameParent(cur, next))
                {
                    Console.WriteLine("NO");
                    return;
                }
            }

            Console.WriteLine("YES");
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
