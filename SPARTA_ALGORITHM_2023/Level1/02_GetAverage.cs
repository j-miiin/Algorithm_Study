using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class GetAverage
    {
        public class Solution
        {
            public double solution(int[] arr)
            {
                double answer = 0;
                double sum = 0;
                foreach (int i in arr) sum += i;
                answer = sum / arr.Length;
                return answer;
            }
        }
    }
}
