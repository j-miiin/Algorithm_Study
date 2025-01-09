using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class Lie
    {
        static bool[] isKnowTruth;
        static int[] parent;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int N = int.Parse(str[0]);
            int M = int.Parse(str[1]);

            isKnowTruth = new bool[N + 1];
            parent = new int[N + 1];

            for (int i = 0; i <= N; i++)
            {
                parent[i] = i;
            }

            str = Console.ReadLine().Split(" ");
            int person = int.Parse(str[0]);
            for (int i = 0; i < person; i++)
            {
                int p = int.Parse(str[i + 1]);
                isKnowTruth[p] = true;
            }

            List<List<int>> parties = new List<List<int>>();
            for (int i = 0; i < M; i++)
            {
                parties.Add(new List<int>());

                str = Console.ReadLine().Split(" ");
                int num = int.Parse(str[0]);

                for (int j = 0; j < num; j++)
                {
                    parties[i].Add(int.Parse(str[j + 1]));
                }

                for (int j = 0; j < num - 1; j++)
                {
                    Union(parties[i][j], parties[i][j + 1]);
                }
            }

            for (int i = 1; i <= N; i++)
            {
                if (isKnowTruth[i])
                {
                    isKnowTruth[Find(i)] = true;
                }
            }

            int answer = 0;
            for (int i = 0; i < parties.Count; i++)
            {
                bool isPossible = true;

                List<int> party = parties[i];
                for (int j = 0; j < party.Count; j++)
                {
                    if (isKnowTruth[Find(party[j])])
                    {
                        isPossible = false;
                        break;
                    }
                }

                if (isPossible)
                {
                    answer++;
                }
            }

            Console.WriteLine(answer);
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
                if (isKnowTruth[x] || isKnowTruth[y])
                {
                    isKnowTruth[x] = isKnowTruth[y] = true;
                } 
                parent[y] = x;
            }
        }
    }
}
