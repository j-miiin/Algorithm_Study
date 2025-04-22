using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmStudy.Baekjoon.Silver2
{
    class Minecraft
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int N = int.Parse(str[0]);
            int M = int.Parse(str[1]);
            int B = int.Parse(str[2]);

            int[,] ground = new int[N, M];

            for (int i = 0; i < N; i++)
            {
                str = Console.ReadLine().Split(" ");
                for (int j = 0; j < M; j++)
                {
                    ground[i, j] = int.Parse(str[j]);
                }
            }

            int minTime = int.MaxValue;
            int resultHeight = -1;

            for (int i = 256; i >= 0; i--)
            {
                int inventory = B;
                int time = 0;

                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < M; k++)
                    {
                        int curHeight = ground[j, k];

                        if (curHeight < i)
                        {
                            time += (i - curHeight);
                            inventory -= (i - curHeight);
                        }
                        else if (curHeight > i)
                        {
                            time += (curHeight - i) * 2;
                            inventory += (curHeight - i);
                        }
                    }
                }

                if (inventory >= 0 && time < minTime)
                {
                    minTime = time;
                    resultHeight = i;
                } else if (inventory >= 0 && time == minTime && i >= resultHeight)
                {
                    minTime = time;
                    resultHeight = i;
                }
            }

            Console.WriteLine($"{minTime} {resultHeight}");
        }
    }
}
