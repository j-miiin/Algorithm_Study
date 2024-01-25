using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class MakePrimeNum
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution(new int[] { 1, 2, 7, 6, 4 }));
        }

        class Solution
        {
            static int[] numArr;
            static bool[] visisted;
            static int result;
            public static int solution(int[] nums)
            {
                numArr = nums;
                visisted = new bool[numArr.Length];
                result = 0;

                dfs(0, 0, 0);

                int answer = result;
                return answer;
            }

            static void dfs(int start, int depth, int sum)
            {
                if (depth == 3)
                {
                    if (isPrime(sum)) result++;
                    return;
                }

                for (int i = start; i < numArr.Length; i++)
                {
                    if (!visisted[i])
                    {
                        visisted[i] = true;
                        dfs(i + 1, depth + 1, sum + numArr[i]);
                        visisted[i] = false;
                    }
                }
            }

            static bool isPrime(int num)
            {
                if (num == 0 || num == 1) return false;
                if (num == 2) return true;
                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0) return false;
                }
                return true;
            }
        }
    }
}
