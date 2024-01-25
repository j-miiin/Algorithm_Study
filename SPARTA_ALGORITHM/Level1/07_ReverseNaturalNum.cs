using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata
{
    internal class ReverseNaturalNum
    {
        public class Solution
        {
            public int[] solution(long n)
            {
                string numStr = n.ToString();
                int[] answer = new int[numStr.Length];
                for (int i = 0, j = numStr.Length-1; i < numStr.Length; i++, j--)
                {
                    answer[i] = int.Parse(numStr[j]+"");
                }
                return answer;
            }
        }
    }
}
