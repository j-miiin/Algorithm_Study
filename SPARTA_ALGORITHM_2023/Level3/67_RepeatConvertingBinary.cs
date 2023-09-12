using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class RepeatConvertingBinary
    {
        public class Solution
        {
            public int[] solution(string s)
            {
                int convertCnt = 0, zeroCnt = 0;

                string curStr = s;
                while (curStr.Length != 1)
                {
                    string tmp = "";
                    for (int i = 0; i < curStr.Length; i++)
                    {
                        if (curStr[i] == '1') tmp += curStr[i];
                        else zeroCnt++;
                    }

                    int length = tmp.Length;
                    curStr = Convert.ToString(length, 2);
                    convertCnt++;
                }

                int[] answer = new int[] { convertCnt, zeroCnt };
                return answer;
            }
        }
    }
}
