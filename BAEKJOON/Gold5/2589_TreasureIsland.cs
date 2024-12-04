using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class TreasureIsland
    {
        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };

        static int N, M;
        static int[,] map;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            N = int.Parse(str[0]);    
            M = int.Parse(str[1]);
            map = new int[N, M];

            for (int i = 0; i < N; i++)
            {
                string s = Console.ReadLine();
                for (int j = 0; j < M; j++)
                {
                    map[i, j] = (s[j] == 'L') ? 0 : 1;
                }
            }

            int answer = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (map[i, j] == 0)
                    {
                        answer = Math.Max(answer, Move(i, j));
                    }
                }
            }

            Console.WriteLine(answer);
        }

        static int Move(int x, int y)
        {
            int result = 0;

            bool[,] visited = new bool[N, M];
            Queue<int[]> queue = new Queue<int[]>();

            visited[x, y] = true;
            queue.Enqueue(new int[] { x, y, 0 });

            while (queue.Count > 0)
            {
                int[] cur = queue.Dequeue();
                int curX = cur[0];
                int curY = cur[1];
                int curTime = cur[2];

                result = Math.Max(result, curTime);

                for (int i = 0; i < dx.Length; i++)
                {
                    int nextX = curX + dx[i];
                    int nextY = curY + dy[i];

                    if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= M
                        || visited[nextX, nextY] || map[nextX, nextY] == 1)
                    {
                        continue;
                    }

                    visited[nextX, nextY] = true;
                    queue.Enqueue(new int[] { nextX, nextY, curTime + 1 });
                }
            }

            return result;
        }
    }
}
