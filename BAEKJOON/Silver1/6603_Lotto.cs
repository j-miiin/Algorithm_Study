using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver1
{
    internal class Lotto
    {
        static StringBuilder sb = new StringBuilder();

        static void Main(string[] args)
        {
            while (true)
            {
                string[] str = Console.ReadLine().Split(" ");

                if (str[0] == "0")
                {
                    break;
                }

                int k = int.Parse(str[0]);
                int[] nums = new int[k];

                for (int i = 0; i < k; i++)
                {
                    nums[i] = int.Parse(str[i + 1]);
                }

                GetCombination(0, 0, k, nums, new int[6]);

                sb.Append("\n");
            }

            Console.Write(sb.ToString());
        }

        static void GetCombination(int curIdx, int start, int k, int[] nums, int[] result)
        {
            if (curIdx == 6)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    sb.Append(result[i]).Append(" ");
                }
                sb.Append("\n");

                return;
            }

            for (int i = start; i < k; i++)
            {
                result[curIdx] = nums[i];
                GetCombination(curIdx + 1, i + 1, k, nums, result);
                result[curIdx] = 0;
            }
        }
    }
}
