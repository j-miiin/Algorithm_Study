using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class LongJump
    {
        public class Solution
        {
            public long solution(int n)
            {
                if (n == 1) return 1;
                long[] dp = new long[n + 1];
                dp[1] = 1;
                dp[2] = 2;

                for (int i = 3; i <= n; i++)
                {
                    dp[i] = (dp[i - 1] + dp[i - 2]) % 1234567;
                }

                long answer = dp[n];
                return answer;
            }
        }
    }
}
