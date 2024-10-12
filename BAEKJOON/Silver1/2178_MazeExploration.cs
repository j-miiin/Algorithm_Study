namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver1
{
    internal class MazeExploration
    {
        static int N, M;
        static int[,] maze;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            N = int.Parse(str[0]);
            M = int.Parse(str[1]);

            maze = new int[N, M];

            for (int i = 0; i < N; i++)
            {
                string s = Console.ReadLine();
                for (int j = 0; j < s.Length; j++)
                {
                    if (s[j] == '1')
                    {
                        maze[i, j] = 1;
                    } else
                    {
                        maze[i, j] = 0;
                    }
                }
            }

            Console.WriteLine(Bfs());
        }

        static int Bfs()
        {
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            int[,] visited = new int[N, M];
            Queue<int[]> queue = new Queue<int[]>();
            visited[0, 0] = 1;
            queue.Enqueue(new int[] { 0, 0 });

            while (queue.Count >0)
            {
                int[] cur = queue.Dequeue();
                int curX = cur[0];
                int curY = cur[1];

                if (curX == N - 1 && curY == M - 1)
                {
                    break;
                }

                for (int i = 0; i < dx.Length; i++)
                {
                    int nextX = curX + dx[i];
                    int nextY = curY + dy[i];

                    if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= M
                        || visited[nextX, nextY] != 0 || maze[nextX, nextY] == 0)
                    {
                        continue;
                    }

                    visited[nextX, nextY] = visited[curX, curY] + 1;
                    queue.Enqueue(new int[] { nextX, nextY });
                }
            }

            return visited[N - 1, M - 1];
        }
    }
}
