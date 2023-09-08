using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class ArrangeScreen
    {
        public class Solution
        {
            const int EMPTY = 0;
            const int FILE = 1;

            static int[] dx = { -1, 1, 0, 0 };
            static int[] dy = { 0, 0, -1, 1 };

            static int[,] screen;
            static bool[,] visited;

            static Queue<int[]> queue;

            static int minStartX = 50, minStartY = 50;
            static int maxStartX = 0, maxStartY = 0;

            public int[] solution(string[] wallpaper)
            {
                screen = new int[wallpaper.Length, wallpaper[0].Length];
                visited = new bool[wallpaper.Length, wallpaper[0].Length];

                queue = new Queue<int[]>();

                for (int i = 0; i < wallpaper.Length; i++)
                {
                    for (int j = 0; j < wallpaper[i].Length; j++)
                    {
                        char c = wallpaper[i][j];
                        if (c == '.') screen[i, j] = EMPTY;
                        else screen[i, j] = FILE;
                    }
                }

                BFS(0, 0);

                int[] answer = new int[] {minStartX, minStartY, maxStartX + 1, maxStartY + 1};
                return answer;
            }

            static void BFS(int x, int y)
            {
                visited[x, y] = true;
                queue.Enqueue(new int[] {x, y});

                while (queue.Count > 0)
                {
                    int[] cur = queue.Dequeue();
                    int curX = cur[0];
                    int curY = cur[1];

                    if (screen[curX, curY] == FILE)
                    {
                        if (curX < minStartX) minStartX = curX;
                        if (curX > maxStartX) maxStartX = curX;

                        if (curY < minStartY) minStartY = curY;
                        if (curY > maxStartY) maxStartY = curY;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        int nextX = curX + dx[i];
                        int nextY = curY + dy[i];

                        if (nextX < 0 || nextY < 0 || nextX >= screen.GetLength(0) || nextY >= screen.GetLength(1)) continue;

                        if (!visited[nextX, nextY])
                        {
                            visited[nextX, nextY] = true;
                            queue.Enqueue(new int[] { nextX, nextY });
                        }
                    }
                }
            }
        }
    }
}
