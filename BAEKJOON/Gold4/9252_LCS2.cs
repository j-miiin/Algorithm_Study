using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold4
{
    internal class LCS2
    {
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            int N = str1.Length;
            int M = str2.Length;
            int[,] dp = new int[N + 1, M + 1];

            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= M; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    } else if (str1[i - 1] == str2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    } else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            int answer = dp[N, M];
            Console.WriteLine(answer);

            if (answer > 0)
            {
                Stack<char> stack = new Stack<char>();
                int cur = answer;
                for (int i = N; i > 0; i--)
                {
                    for (int j = M; j > 0; j--)
                    {
                        if (str1[i - 1] == str2[j - 1]
                            && dp[i, j] == cur && cur > 0)
                        {
                            stack.Push(str1[i - 1]);
                            cur--;
                            break;
                        }
                    }
                }

                StringBuilder sb = new StringBuilder();
                while (stack.Count > 0)
                {
                    sb.Append(stack.Pop());
                }

                Console.WriteLine(sb.ToString());
            }
        }
    }
}
