using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class MaxNum
    {
        public class Solution
        {
            public string solution(int[] numbers)
            {
                string[] stringNums = new string[numbers.Length];
                for (int i = 0; i < numbers.Length; i++)
                {
                    stringNums[i] = numbers[i].ToString();
                }

                Array.Sort(stringNums, (s1, s2) =>
                {
                    return (s2 + s1).CompareTo(s1 + s2);
                });

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < stringNums.Length; i++) sb.Append(stringNums[i]);
                string answer = sb.ToString();

                if (answer[0] == '0') answer = "0";
                return answer;
            }
        }
    }
}
