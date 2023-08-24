using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class ArrayWithGap
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Solution.solution(-4, 2)));
        }

        public class Solution
        {
            public static long[] solution(int x, int n)
            {
                long[] answer = new long[n];
                int idx = 0;
                long cur = x;
                while (idx < n)
                {
                    answer[idx] = cur;
                    cur += x;
                    idx++;
                }
                return answer;
            }
        }
    }
}
