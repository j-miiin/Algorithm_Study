using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class CCW
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int p1x = int.Parse(str[0]);
            int p1y = int.Parse(str[1]);

            str = Console.ReadLine().Split(" ");
            int p2x = int.Parse(str[0]);
            int p2y = int.Parse(str[1]);

            str = Console.ReadLine().Split(" ");
            int p3x = int.Parse(str[0]);
            int p3y = int.Parse(str[1]);

            int comp = (p2y - p1y) * (p3x - p2x) - (p3y - p2y) * (p2x - p1x);

            if (comp == 0)
            {
                Console.WriteLine(0);
            } else
            {
                Console.WriteLine((comp > 0) ? -1 : 1);
            }
        }
    }
}
