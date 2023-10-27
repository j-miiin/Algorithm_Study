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
                Console.WriteLine(Solution.solution(new int[] { 1, 2, 3, 4, 5 }, 7));
            }
            public static int[] solution(int[] sequence, int k)
            {
                int[] prefixSum = new int[sequence.Length];
                prefixSum[0] = sequence[0];
                for (int i = 1; i < sequence.Length; i++)
                {
                    prefixSum[i] = prefixSum[i - 1] + sequence[i];
                }

                int start = -1, end = 0;
                int minStart = 0, minEnd = prefixSum.Length;
                int sum = 0;
                while (start <= end && end <= prefixSum.Length)
                {
                    Console.WriteLine($"start {start}, end {end}, sum {sum}");
                    if (start == -1) sum = prefixSum[end];
                    else if (end == prefixSum.Length) sum = prefixSum[end - 1];
                    else sum = prefixSum[end] - prefixSum[start];

                    if (sum > k) start++;
                    else if (sum < k) end++;
                    else
                    {
                        int length = minEnd - minStart + 1;
                        int curLength = end - start + 1;
                        if (start == -1) curLength = end + 1;

                        if (curLength < length)
                        {
                            minStart = start;
                            minEnd = end;
                            if (length == 1) break;
                        }
                    }
                }

                int[] answer = new int[] { minStart, minEnd};
                return answer;
            }
        }
    }
}
