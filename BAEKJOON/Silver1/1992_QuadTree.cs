using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver1
{
    internal class QuadTree
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[,] video = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                string s = Console.ReadLine();
                for (int j = 0; j < N; j++)
                {
                    video[i, j] = (s[j] == '1') ? 1 : 0;
                }
            }

            StringBuilder sb = new StringBuilder();

            Compress(0, 0, N, video, sb);

            Console.WriteLine(sb.ToString());
        }

        static void Compress(int x, int y, int size, int[,] video, StringBuilder sb)
        {
            if (size == 1)
            {
                sb.Append(video[x, y]);
                return;
            }

            if (IsPossibleToCompress(x, y, size, video))
            {
                sb.Append(video[x, y]);
                return;
            }

            int div = size / 2;

            sb.Append("(");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Compress(x + (i * div), y + (j * div), div, video, sb);
                }
            }
            sb.Append(")");
        }

        static bool IsPossibleToCompress(int x, int y, int size, int[,] video)
        {
            int cur = video[x, y];

            for (int i = x; i < x + size; i++)
            {
                for (int j = y; j < y + size; j++)
                {
                    if (video[i, j] != cur)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
