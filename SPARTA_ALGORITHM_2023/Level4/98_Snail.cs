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
                if (n == 1) return new int[]{ 1 };

                int length = (n * n + n) / 2;

                int[,] snail = new int[n, n];

                int[] dx = { 1, 0, -1 };
                int[] dy = { 0, 1, -1 };

                int dir = 0;
                int startX = 0, startY = 0;
                int curX = startX, curY = startY;

                int cnt = 0;
                int curLength = n - 1;
                int curNum = 1;
                while (curNum <= length)
                {
                    Console.WriteLine($"curX {curX}, curY {curY}");
                    Console.WriteLine($"curNum {curNum}");
                    snail[curX, curY] = curNum++;

                    cnt++;
                    Console.WriteLine($"cnt {cnt}, curLength {curLength}");

                    if (cnt % curLength == 0)
                    {
                        cnt = 0;
                        dir = (dir + 1) % 3;
                        Console.WriteLine($"dir {dir}");

                        if (dir % 3 == 0)
                        {
                            curLength -= 2;

                            startX += 2;
                            startY += 1;
                            curX = startX;
                            curY = startY;
                        }
                    }

                    curX += dx[dir];
                    curY += dy[dir];
                }

                Console.WriteLine();

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        Console.Write($"{snail[i, j]} ");
                    }
                    Console.WriteLine();
                }

                int[] answer = new int[length];

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
