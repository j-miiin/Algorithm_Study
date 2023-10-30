using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class SubSequenceSum
    {
        public class Solution
        {
            static void Main(string[] args)
            {
                Console.WriteLine(string.Join(", ", Solution.solution(new int[] { 2, 2, 2, 2, 2 }, 6)));
            }
            public static int[] solution(int[] sequence, int k)
            {
                if (sequence[0] == k) return new int[] { 0, 0 };

                int[] prefixSum = new int[sequence.Length + 1];
                for (int i = 1; i <= sequence.Length; i++)
                {
                    prefixSum[i] = prefixSum[i - 1] + sequence[i - 1];
                }

                int start = 0, end = 1;
                int minStart = 0, minEnd = prefixSum.Length;
                int sum = 0;
                while (start <= end && end < prefixSum.Length)
                {
                    sum = prefixSum[end] - prefixSum[start];

                    if (sum > k) start++;
                    else if (sum < k) end++;
                    else
                    {
                        if ((end - start) < (minEnd - minStart))
                        {
                            minStart = start;
                            minEnd = end;
                        }
                        end++;
                    }
                }

                int[] answer = new int[] { minStart, minEnd - 1 };
                return answer;
            }
        }
    }
}
