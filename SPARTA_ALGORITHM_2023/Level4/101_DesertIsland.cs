using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class DesertIsland
    {
        public class Solution
        {
            const int SEA = 0;
            static int N, M;
            static int[] dx = { -1, 1, 0, 0 };
            static int[] dy = { 0, 0, -1, 1 };

            static int[,] island;
            static bool[,] visited;
            public int[] solution(string[] maps)
            {
                N = maps.Length;
                M = maps[0].Length;
                island = new int[N, M];
                visited = new bool[N, M];

                for (int i = 0; i < N; i++)
                {
                    string s = maps[i];
                    for (int j = 0; j < M; j++)
                    {
                        string cur = $"{s[j]}";
                        if (cur == "X")
                        {
                            island[i, j] = SEA;
                        } else
                        {
                            int food = int.Parse(cur);
                            island[i, j] = food;
                        }
                    }
                }

                List<int> list = new List<int>();
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (!visited[i, j] && island[i, j] != SEA)
                        {
                            int cur = bfs(i, j);
                            if (cur != 0) list.Add(cur);
                        }
                    }
                }

                int[] answer;
                if (list.Count == 0) answer = new int[] { -1 };
                else
                {
                    list.Sort();
                    answer = list.ToArray();
                }

                return answer;
            }

            static int bfs(int x, int y)
            {
                int foods = 0;

                visited[x, y] = true;

                Queue<int[]> queue = new Queue<int[]>();
                queue.Enqueue(new int[] { x, y });

                while (queue.Count > 0)
                {
                    int[] cur = queue.Dequeue();
                    int curX = cur[0];
                    int curY = cur[1];
                    foods += island[curX, curY];

                    for (int i = 0; i < 4; i++)
                    {
                        int nextX = curX + dx[i];
                        int nextY = curY + dy[i];

                        if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= M
                            || visited[nextX, nextY]
                            || island[nextX, nextY] == SEA) continue;

                        visited[nextX, nextY] = true;
                        queue.Enqueue(new int[] {nextX, nextY});
                    }
                }

                return foods;
            }
        }
    }
}
