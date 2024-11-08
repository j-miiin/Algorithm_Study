using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class GoldbachsConjecture
    {
        static List<int> primeList = new List<int>();

        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            int[] nums = new int[T];
            int max = -1;
            for (int i = 0; i < T; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
                if (nums[i] > max)
                {
                    max = nums[i];
                }
            }

            SetPrimeList(max);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < nums.Length; i++)
            {
                int[] result = GetGoldbachPartition(nums[i]);
                sb.Append(result[0]).Append(" ").Append(result[1]).Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }

        static void SetPrimeList(int max)
        {
            bool[] prime = new bool[max + 1];
            Array.Fill(prime, true);

            for (int i = 2; i * i <= max; i++)
            {
                if (prime[i])
                {
                    for (int j = i * i; j <= max; j += i)
                    {
                        prime[j] = false;
                    }
                }
            }

            for (int i = 2; i <= max; i++)
            {
                if (prime[i])
                {
                    primeList.Add(i);
                }
            }
        }

        static int[] GetGoldbachPartition(int n)
        {
            int result1 = 0;
            int result2 = 0;

            int front = 0;
            int back = 0;

            for (int i = 0; i < primeList.Count; i++)
            {
                if (primeList[i] > n)
                {
                    back = i - 1;
                    break;
                }
            }

            if (back == 0)
            {
                back = primeList.Count - 1;
            }

            int minDiff = primeList.Count;
            while (front < primeList.Count && back >= 0 && front <= back)
            {
                int sum = primeList[front] + primeList[back];
                if (sum == n)
                {
                    if (back - front < minDiff)
                    {
                        result1 = front;
                        result2 = back;
                        minDiff = back - front;
                    } else
                    {
                        front++;
                    }
                } else if (sum < n)
                {
                    front++;
                } else
                {
                    back--;
                }
            }

            return new int[] { primeList[result1], primeList[result2] };
        }
    }
}
