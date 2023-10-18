using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class FindPrimeNum
    {
        public class Solution
        {
            static HashSet<int> numSet;
            static bool[] visited;
            public int solution(string numbers)
            {
                char[] numChars = numbers.ToCharArray();
                numSet = new HashSet<int>();
                visited = new bool[numChars.Length];

                MakeNum(numChars, "", 0);

                int answer = 0;

                foreach (int n in numSet)
                {
                    if (isPrime(n)) answer++;
                }
                return answer;
            }

            static void MakeNum(char[] numChars, string curStr, int depth)
            {
                if (curStr.Length > 0) numSet.Add(int.Parse(curStr));

                if (depth == numChars.Length) return;

                for (int i = 0; i < numChars.Length; i++)
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        MakeNum(numChars, curStr + numChars[i], depth + 1);
                        visited[i] = false;
                    }
                }
            }

            static bool isPrime(int num)
            {
                if (num == 0 || num == 1) return false;
                if (num == 2) return true;

                for (int i = 2; i * i <= num; i++)
                {
                    if (num % i == 0) return false;
                }
                return true;
            }
        }
    }
}
