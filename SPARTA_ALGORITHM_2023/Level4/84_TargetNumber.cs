using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class TargetNumber
    {
        public class Solution
        {
            public int solution(int[] numbers, int target)
            {
                int answer = 0;

                for (int i = 0; i < (1 << numbers.Length); i++)
                {
                    int sum = 0;
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        if ((i & (1 << j)) != 0) sum += numbers[j];
                        else sum -= numbers[j];
                    }

                    if (sum == target) answer++;
                }

                return answer;
            }
        }
    }
}
