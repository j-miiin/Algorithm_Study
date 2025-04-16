using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmStudy.Baekjoon.Silver3
{
    class WaveSequence
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            long[] p = new long[101];
            p[1] = 1;
            p[2] = 1;
            p[3] = 1;
            p[4] = 2;
            p[5] = 2;

            for (int i = 6; i <= 100; i++)
            {
                p[i] = p[i - 1] + p[i - 5];
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < T; i++)
            {
                int n = int.Parse(Console.ReadLine());
                sb.Append(p[n]).Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
