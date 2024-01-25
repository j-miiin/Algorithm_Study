using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class InnerProduct
    {
        public class Solution
        {
            public int solution(int[] a, int[] b)
            {
                int answer = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    answer += a[i] * b[i];
                }
                return answer;
            }
        }
    }
}
