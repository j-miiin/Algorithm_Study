using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class NQueen
    {
        static int answer = 0;
        static int[] board;

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            board = new int[N];

            Dfs(0, N);

            Console.WriteLine(answer);
        }

        static void Dfs(int idx, int N)
        {
            if (idx >= N)
            {
                answer++;
                return;
            }

            for (int i = 0; i < N; i++)
            {
                board[idx] = i;

                if (IsValid(idx))
                {
                    Dfs(idx + 1, N);
                }
            }
        }

        static bool IsValid(int idx)
        {
            for (int i = 0; i < idx; i++)
            {
                if (board[idx] == board[i])
                {
                    return false;
                }

                if (Math.Abs(idx - i) == Math.Abs(board[idx] - board[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
