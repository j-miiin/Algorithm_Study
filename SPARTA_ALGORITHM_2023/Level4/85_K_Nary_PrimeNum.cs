using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class K_Nary_PrimeNum
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution(110011, 10));
        }

        public class Solution
        {
            public static int solution(int n, int k)
            {
                int answer = 0;
                StringBuilder sb = new StringBuilder();
                while (n > 0)
                {
                    sb.Append(n % k);
                    n /= k;
                }
                if (n > 0) sb.Append(n);

                char[] tmp = sb.ToString().ToArray();
                Array.Reverse(tmp);
                string result = new string(tmp);

                string[] nums = result.Split("0");
                foreach (string num in nums)
                {
                    if (IsPrime(long.Parse(num))) answer++;
                }

                return answer;
            }

            static bool IsPrime(long num)
            {
                if (num == 0 || num == 1) return false;
                if (num == 2) return true;
                for(int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0) return false;
                }
                return true;
            }
        }
    }
}
