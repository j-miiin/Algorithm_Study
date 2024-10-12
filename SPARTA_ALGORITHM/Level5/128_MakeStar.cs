using System;
using System.Collections.Generic;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level5
{
    internal class MakeStar
    {
        public class Solution
        {
            static void Main(string[] args)
            {
                string[] s = solution(new int[,]
                {
                    { 2, -1, 4},
                    { -2, -1, 4},
                    { 0, -1, 1},
                    { 5, -8, -12},
                    { 5, 8, 12}
                    //{ 0, 1, -1 }, {1, 0, -1 }, {1, 0, 1 }
                    //{ 1, -1, 0 }, { 2, -1, 0 }
                    //{ 1, -1, 0 }, { 2, -1, 0 }, { 4, -1, 0 }
                });

                foreach (string str in s)
                {
                    Console.WriteLine(str);
                }
            }

            public static string[] solution(int[,] line)
            {
                List<long[]> points = new List<long[]>();

                long minX = long.MaxValue;
                long maxX = long.MinValue;
                long minY = long.MaxValue;
                long maxY = long.MinValue;

                for (int i = 0; i < line.GetLength(0); i++)
                {
                    for (int j = i + 1; j < line.GetLength(0); j++)
                    {
                        long a = line[i, 0];
                        long b = line[i, 1];
                        long e = line[i, 2];
                        long c = line[j, 0];
                        long d = line[j, 1];
                        long f = line[j, 2];

                        if (a * d - b * c == 0)
                        {
                            continue;
                        }

                        long denominator = a * d - b * c;
                        long xNumerator = b * f - e * d;
                        long yNumerator = e * c - a * f;                        

                        if (xNumerator % denominator != 0 || yNumerator % denominator != 0)
                        {
                            continue;
                        }

                        long x = xNumerator / denominator;
                        long y = yNumerator / denominator;

                        points.Add(new long[] { x, y });

                        if (x < minX)
                        {
                            minX = x;
                        }

                        if (x > maxX)
                        {
                            maxX = x;
                        }

                        if (y < minY)
                        {
                            minY = y;
                        }

                        if (y > maxY)
                        {
                            maxY = y;
                        }
                    }
                }

                long xLength = maxY - minY + 1;
                long yLength = maxX - minX + 1;

                int[,] board = new int[xLength, yLength];
                for (int i = 0; i < points.Count; i++)
                {
                    long x = points[i][1] - minY;
                    long y = points[i][0] - minX;

                    board[x, y] = 1;
                }

                string[] answer = new string[xLength];
                for (int i = 0; i < xLength; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < yLength; j++)
                    {
                        if (board[i, j] == 0)
                        {
                            sb.Append(".");
                        } else
                        {
                            sb.Append("*");
                        }
                    }
                    answer[i] = sb.ToString();
                }

                Array.Reverse(answer);
                return answer;
            }
        }
    }
}
