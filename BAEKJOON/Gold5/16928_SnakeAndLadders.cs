using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class SnakeAndLadders
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int N = int.Parse(str[0]);
            int M = int.Parse(str[1]);

            int[] board = new int[101];
            for (int i = 0; i <= 100; i++)
            {
                board[i] = i;
            }

            for (int i = 0; i < N; i++)
            {
                str = Console.ReadLine().Split(" ");
                int src = int.Parse(str[0]);
                int des = int.Parse(str[1]);

                board[src] = des;
            }
            
            for (int i = 0; i < M; i++)
            {
                str = Console.ReadLine().Split(" ");
                int src = int.Parse(str[0]);
                int des = int.Parse(str[1]);

                board[src] = des;
            }

            Console.WriteLine(RollDice(board));
        }

        static int RollDice(int[] board)
        {
            int result = 0;

            bool[] visited = new bool[101];
            Queue<int[]> queue = new Queue<int[]>();

            visited[1] = true;
            queue.Enqueue(new int[] { 1, 0 });

            while (queue.Count > 0)
            {
                int[] cur = queue.Dequeue();
                int curIdx = cur[0];
                int curCount = cur[1];

                if (curIdx == 100)
                {
                    result = curCount;
                    break;
                }

                if (board[curIdx] != curIdx)
                {
                    curIdx = board[curIdx];
                }

                for (int i = 1; i <= 6; i++)
                {
                    if (curIdx + i <= 100 && !visited[curIdx + i])
                    {
                        visited[curIdx + i] = true;
                        queue.Enqueue(new int[] { curIdx + i, curCount + 1 });
                    }
                }
            }

            return result;
        }
    }
}
