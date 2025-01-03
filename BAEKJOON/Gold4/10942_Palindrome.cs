using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class Palindrome
    {
        static int[] nums;

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            nums = new int[N];

            string[] str = Console.ReadLine().Split(" ");
            for (int i = 0; i < N; i++)
            {
                nums[i] = int.Parse(str[i]);
            }

            int M = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < M; i++)
            {
                str = Console.ReadLine().Split(" ");

                int start = int.Parse(str[0]);
                int end = int.Parse(str[1]);

                if (IsPalindrome(start, end))
                {
                    sb.Append("1").Append("\n");
                } else
                {
                    sb.Append("0").Append("\n");
                }
            }

            Console.WriteLine(sb.ToString());
        }

        static bool IsPalindrome(int s, int e)
        {
            if (s == e)
            {
                return true;
            }

            int front = s - 1;
            int back = e - 1;

            while (front < back)
            {
                if (nums[front] == nums[back])
                {
                    front++;
                    back--;
                } else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
