using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class MinMaxValue
    {
        public class Solution
        {
            public string solution(string s)
            {
                string[] values = s.Split(' ');

                int[] intValue = new int[values.Length];
                for (int i = 0; i < values.Length; i++)
                {
                    intValue[i] = int.Parse(values[i]);
                }

                string answer = intValue.Min() + " " + intValue.Max();
                return answer;
            }
        }
    }
}
