using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class PolygonArea
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            List<long[]> points = new List<long[]>(); 
            for (int i = 0; i < N; i++)
            {
                string[] str = Console.ReadLine().Split(" ");

                long x = long.Parse(str[0]); 
                long y = long.Parse(str[1]);

                points.Add(new long[] { x, y });
            }

            double answer = 0;
            for (int i = 1; i < points.Count - 1; i++)
            {
                long v1x = points[i][0] - points[0][0];
                long v1y = points[i][1] - points[0][1];

                long v2x = points[i + 1][0] - points[0][0];
                long v2y = points[i + 1][1] - points[0][1];

                answer += v1x * v2y - v1y * v2x;
            }

            Console.WriteLine("{0:F1}", Math.Abs(answer) / 2.0d);
        }
    }
}
