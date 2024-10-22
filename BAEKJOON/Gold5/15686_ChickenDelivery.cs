using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class ChickenDelivery
    {
        static int N, M;

        static List<int[]> homeList;
        static List<int[]> chickenList;

        static int answer;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            N = int.Parse(str[0]);
            M = int.Parse(str[1]);

            homeList = new List<int[]>();
            chickenList = new List<int[]>();

            for (int i = 0; i < N; i++)
            {
                str = Console.ReadLine().Split(" ");
                for (int j = 0; j < N; j++)
                {
                    int cur = int.Parse(str[j]);
                    if (cur == 1)
                    {
                        homeList.Add(new int[] { i, j });
                    } else if (cur == 2)
                    {
                        chickenList.Add(new int[] { i, j });
                    }
                }
            }

            answer = int.MaxValue;

            SelectChickenStore(0, 0, new List<int[]>());

            Console.WriteLine(answer);
        }

        static void SelectChickenStore(int start, int count, List<int[]> leftChickenList)
        {
            if (count == M)
            {
                answer = Math.Min(answer, GetDistance(leftChickenList));
                return;
            }

            for (int i = start; i < chickenList.Count; i++)
            {
                leftChickenList.Add(new int[]
                    { chickenList[i][0], chickenList[i][1] });
                SelectChickenStore(i + 1, count + 1, leftChickenList);
                leftChickenList.RemoveAt(leftChickenList.Count - 1);
            }
        }

        static int GetDistance(List<int[]> leftChickenList)
        {
            int distance = 0;

            for (int i = 0; i < homeList.Count; i++)
            {
                int tmpD = int.MaxValue;

                for (int j = 0; j < leftChickenList.Count; j++)
                {
                    int d = Math.Abs(homeList[i][0] - leftChickenList[j][0])
                        + Math.Abs(homeList[i][1] - leftChickenList[j][1]);

                    tmpD = Math.Min(tmpD, d);
                }

                distance += tmpD;
            }

            return distance;
        }
    }
}
