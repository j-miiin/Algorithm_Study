using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class SumOfNonExistNum
    {
        public class Solution
        {
            public int solution(int[] numbers)
            {
                int answer = 0;
                bool[] check = new bool[10];
                foreach (int i in numbers) check[i] = true;
                for (int i = 0; i < check.Length; i++)
                {
                    if (!check[i]) answer += i;
                }
                return answer;
            }
        }
    }
}
