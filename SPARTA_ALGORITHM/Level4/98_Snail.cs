using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class Snail
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Solution.solution(4)));
        }

        public class Solution
        {
            public static int[] solution(int n)
            {
                int[,] snail = new int[n, n];

                int[] dx = { 1, 0, -1 };
                int[] dy = { 0, 1, -1 };

                int x = 0, y = 0;
                int dir = 0;
                int curNum = 1;
                while (true)
                {
                    snail[x, y] = curNum++;

                    int nextX = x + dx[dir];
                    int nextY = y + dy[dir];

                    if (nextX == n || nextY == n || snail[nextX, nextY] != 0)
                    {
                        dir = (dir + 1) % 3;
                        nextX = x + dx[dir];
                        nextY = y + dy[dir];

                        if (nextX == n || nextY == n || snail[nextX, nextY] != 0) break;
                    }

                    x = nextX;
                    y = nextY;
                }

                int[] answer = new int[curNum-1];

                int idx = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        answer[idx++] = snail[i, j];
                    }
                }

                return answer;
            }
        }
    }
}
