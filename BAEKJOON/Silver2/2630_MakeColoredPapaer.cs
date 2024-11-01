using System;
using System.Collections.Generic;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class MakeColoredPapaer
    {
        static int[,] paper;

        static int[] answer = new int[2];

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            paper = new int[N, N];

            string[] str;
            for (int i = 0; i < N; i++)
            {
                str = Console.ReadLine().Split(" ");
                for (int j = 0; j < N; j++)
                {
                    paper[i, j] = int.Parse(str[j]);
                }
            }

            CutPapaer(N, 0, 0);

            Console.WriteLine(answer[0] + "\n" + answer[1]);
        }

        static void CutPapaer(int size, int x, int y)
        {
            if (size == 1 || IsAllSame(size, x, y))
            {
                answer[paper[x, y]]++;
                return;
            }

            int half = size / 2;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    CutPapaer(half, x + (half * i), y + (half * j));
                }
            }
        }

        static bool IsAllSame(int size, int minX, int minY)
        {
            int cur = paper[minX, minY];
            for (int i = minX; i < minX + size; i++)
            {
                for (int j = minY; j < minY + size; j++)
                {
                    if (cur != paper[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
