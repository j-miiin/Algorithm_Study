using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class H_Index
    {
        public class Solution
        {
            public int solution(int[] citations)
            {
                int answer = 0;

                for (int i = 1; i <= citations.Length; i++)
                {
                    int count = 0;
                    for (int j = 0; j < citations.Length; j++)
                    {
                        if (i <= citations[j]) count++;
                    }

                    if (count >= i && count > answer) answer = count;
                }
                
                return answer;
            }
        }
    }
}
