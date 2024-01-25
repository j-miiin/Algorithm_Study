using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class FibonacciNum
    {
        public class Solution
        {
            static int[] dp;
            public int solution(int n)
            {
                dp = new int[n + 1];

                dp[0] = 0;
                dp[1] = 1;

                int answer = Fibonacci(n);
                return answer;
            }
            static int Fibonacci(int n)
            {
                if (n == 0) return dp[n];
                if (n == 1) return dp[n];

                if (dp[n] > 0) return dp[n];

                dp[n] = (Fibonacci(n - 1) + Fibonacci(n - 2)) % 1234567;

                return dp[n];
            }
        }
    }
}
