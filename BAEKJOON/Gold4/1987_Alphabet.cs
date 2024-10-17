using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class Alphabet
    {
        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };

        static int R, C;
        static int answer = 1;
        static char[,] board;
        static bool[,] visited;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            R = int.Parse(str[0]);
            C = int.Parse(str[1]);

            board = new char[R, C];
            visited = new bool[R, C];

            for (int i = 0; i < R; i++)
            {
                string s = Console.ReadLine();
                for (int j = 0; j < C; j++)
                {
                    board[i, j] = s[j];
                }
            }

            visited[0, 0] = true;
            Dfs(0, 0, new List<char> { board[0, 0] });

            Console.WriteLine(answer);
        }

        static void Dfs(int x, int y, List<char> charList)
        {
            for (int i = 0; i < dx.Length; i++)
            {
                int nextX = x + dx[i];
                int nextY = y + dy[i];

                if (nextX < 0 || nextY < 0 || nextX >= R || nextY >= C
                    || visited[nextX, nextY])
                {
                    continue;
                }

                char c = board[nextX, nextY];
                if (!charList.Contains(c))
                {
                    visited[nextX, nextY] = true;
                    charList.Add(c);

                    answer = Math.Max(answer, charList.Count);

                    Dfs(nextX, nextY, charList);

                    visited[nextX, nextY] = false;
                    charList.RemoveAt(charList.Count - 1);
                }
            }
        }
    }
}
