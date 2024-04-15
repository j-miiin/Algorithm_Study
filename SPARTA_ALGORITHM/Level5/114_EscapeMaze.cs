using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level5
{
    internal class EscapeMaze
    {
        public class Solution
        {
            const int EMPTY = 0;
            const int WALL = 1;

            static int[] dx = { -1, 1, 0, 0 };
            static int[] dy = { 0, 0, -1, 1 };
            static int[,] maze;
            static int[,] visited;
            static int N, M;
            static int time;

            public int solution(string[] maps)
            {
                int startX = 0, startY = 0;
                int leverX = 0, leverY = 0;
                int exitX = 0, exitY = 0;

                N = maps.Length;
                M = maps[0].Length;
                maze = new int[N, M];
                visited = new int[N, M];
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < M; j++) visited[i, j] = -1;

                for (int i = 0; i < maps.Length; i++)
                {
                    string s = maps[i];
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (s[j] == 'X') maze[i, j] = WALL;
                        else if (s[j] == 'S')
                        {
                            startX = i;
                            startY = j;
                        }
                        else if (s[j] == 'L')
                        {
                            leverX = i;
                            leverY = j;
                        }
                        else if (s[j] == 'E')
                        {
                            exitX = i;
                            exitY = j;
                        }
                    }
                }

                int answer = 0;
                if (bfs(startX, startY, leverX, leverY))
                {
                    answer += time;
                    time = 0;
                    for (int i = 0; i < N; i++)
                        for (int j = 0; j < M; j++) visited[i, j] = -1;
                }
                else return -1;

                if (bfs(leverX, leverY, exitX, exitY)) return answer + time;
                else return -1;
            }

            static bool bfs(int x, int y, int desX, int desY)
            {
                visited[x, y] = 0;
                Queue<int[]> queue = new Queue<int[]>();
                queue.Enqueue(new int[] { x, y });

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
                            || visited[nextX, nextY] != -1
                            || maze[nextX, nextY] == WALL) continue;

                        visited[nextX, nextY] = visited[curX, curY] + 1;
                        if (nextX == desX && nextY == desY)
                        {
                            time = visited[nextX, nextY];
                            return true;
                        }

                        queue.Enqueue(new int[] { nextX, nextY });
                    }
                }

                return false;
            }
        }
    }
}
