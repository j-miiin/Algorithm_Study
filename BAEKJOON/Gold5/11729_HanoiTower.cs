using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class HanoiTower
    {
        static List<int[]> answerList;
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int hanoiNum = 1;
            for (int i = 2; i <= N; i++)
            {
                hanoiNum = hanoiNum * 2 + 1;
            }

            answerList = new List<int[]>(hanoiNum);

            Hanoi(N, 1, 3, 2);

            Console.WriteLine(hanoiNum);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < answerList.Count; i++)
            {
                sb.Append(answerList[i][0]).Append(" ").Append(answerList[i][1]).Append("\n");
            }
            Console.WriteLine(sb.ToString());
        }

        static void Hanoi(int n, int start, int end, int mid)
        {
            if (n == 1)
            {
                answerList.Add(new int[] { start, end });
                return;
            }

            Hanoi(n - 1, start, mid, end);
            answerList.Add(new int[] { start, end });
            Hanoi(n - 1, mid, end, start);
        }
    }
}
