using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmStudy.Baekjoon.Silver2
{
    class NeedFriends
    {
        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };

        static int N, M;
        static char[,] campus;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            N = int.Parse(str[0]);
            M = int.Parse(str[1]);

            campus = new char[N, M];

            int startX = 0;
            int startY = 0;

            for (int i = 0; i < N; i++)
            {
                string s = Console.ReadLine();
                for (int j = 0; j < M; j++)
                {
                    campus[i, j] = s[j];

                    if (s[j] == 'I')
                    {
                        startX = i;
                        startY = j;
                    }
                }
            }

            int result = Move(startX, startY);
            Console.WriteLine((result == 0) ? "TT" : result);
        }

        static int Move(int x, int y)
        {
            bool[,] visited = new bool[N, M];
            Queue<int[]> queue = new Queue<int[]>();

            visited[x, y] = true;
            queue.Enqueue(new int[]{ x, y });

            int result = 0;

            while (queue.Count > 0)
            {
                int[] cur = queue.Dequeue();
                int curX = cur[0];
                int curY = cur[1];

                for (int i = 0; i < dx.Length; i++)
                {
                    int nextX = curX + dx[i];
                    int nextY = curY + dy[i];

                    if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= M
                        || visited[nextX, nextY] || campus[nextX, nextY] == 'X')
                        continue;

                    if (campus[nextX, nextY] == 'P')
                        result++;

                    visited[nextX, nextY] = true;
                    queue.Enqueue(new int[] { nextX, nextY });
                }
            }

            return result;
        }
    }
}
