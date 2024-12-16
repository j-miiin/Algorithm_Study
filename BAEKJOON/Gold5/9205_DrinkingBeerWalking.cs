using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class DrinkingBeerWalking
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(Console.ReadLine());

                List<int[]> positions = new List<int[]>();

                string[] str = Console.ReadLine().Split(" ");
                int startX = int.Parse(str[0]);
                int startY = int.Parse(str[1]);
                positions.Add(new int[] { startX, startY });

                for (int j = 0; j < n; j++)
                {
                    str = Console.ReadLine().Split(" ");
                    int x = int.Parse(str[0]);
                    int y = int.Parse(str[1]);
                    positions.Add(new int[] { x, y });
                }

                str = Console.ReadLine().Split(" ");
                int endX = int.Parse(str[0]);
                int endY = int.Parse(str[1]);
                positions.Add(new int[] { endX, endY });

                if (Walking(positions))
                {
                    sb.Append("happy").Append("\n");
                } else
                {
                    sb.Append("sad").Append("\n");
                }
            }

            Console.WriteLine(sb.ToString());
        }

        static bool Walking(List<int[]> positions)
        {
            bool[] visited = new bool[positions.Count];
            Queue<int> queue = new Queue<int>();

            visited[0] = true;
            queue.Enqueue(0);

            while (queue.Count > 0)
            {
                int idx = queue.Dequeue();

                if (idx == positions.Count - 1)
                {
                    return true;
                }

                int curX = positions[idx][0];
                int curY = positions[idx][1];

                for (int i = 0; i < positions.Count; i++)
                {
                    if (visited[i])
                    {
                        continue;
                    }

                    int nextX = positions[i][0];
                    int nextY = positions[i][1];

                    if (Math.Abs(nextX - curX) + Math.Abs(nextY - curY) <= 1000)
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
                    }
                }
            }

            return false;
        }
    }
}
