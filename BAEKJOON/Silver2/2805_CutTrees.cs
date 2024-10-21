using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class CutTrees
    {
        static long N, M;
        static long[] trees;

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            N = long.Parse(str[0]);
            M = long.Parse(str[1]);

            trees = new long[N];
            str = Console.ReadLine().Split(" ");
            long max = long.MinValue;
            for (int i = 0; i < N; i++)
            {
                trees[i] = long.Parse(str[i]);

                if (trees[i] > max)
                {
                    max = trees[i];
                }
            }

            Console.WriteLine(BinarySearch(0, max));
        }

        static long BinarySearch(long low, long high)
        {
            long mid = (low + high) / 2;

            if (low > high)
            {
                return high;
            }

            long value = GetTrees(mid);
            
            if (value < M)
            {
                return BinarySearch(low, mid - 1);
            } else
            {
                return BinarySearch(mid + 1, high);
            }
        }

        static long GetTrees(long height)
        {
            long result = 0;

            for (int i = 0; i < trees.Length; i++)
            {
                if (trees[i] <= height)
                {
                    continue;
                }

                result += trees[i] - height;
            }

            return result;
        }
    }
}
