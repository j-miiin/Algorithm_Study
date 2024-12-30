using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class PrintStar11
    {
        static int N;
        static char[,] star;

        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());

            star = new char[3072, 6144];
            
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < 2 * N - 1; j++)
                {
                    star[i, j] = ' ';
                }
            }

            Fill(N, 0, N - 1);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < 2 * N - 1; j++)
                {
                    sb.Append(star[i, j]);
                }
                sb.Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }

        static void Fill(int n, int x, int y)
        {
            if (n == 3)
            {
                star[x, y] = '*';

                star[x + 1, y - 1] = '*';
                star[x + 1, y + 1] = '*';

                for (int i = 0; i < 5; i++)
                {
                    star[x + 2, y - 2 + i] = '*';
                }

                return;
            }

            Fill(n / 2, x, y);
            Fill(n / 2, x + n / 2, y - n / 2);
            Fill(n / 2, x + n / 2, y + n / 2);
        }
    }
}
