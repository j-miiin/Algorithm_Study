using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class NearestSameChar
    {
        public class Solution
        {
            public int[] solution(string s)
            {
                int[] answer = new int[s.Length];
                Dictionary<string, int> idxDic = new Dictionary<string, int>();

                for (int i = 0; i < s.Length; i++)
                {
                    string curStr = s[i] + "";
                    if (idxDic.TryGetValue(curStr, out int charIdx))
                    {
                        answer[i] = i - charIdx;
                        idxDic[curStr] = i;
                    } else
                    {
                        answer[i] = -1;
                        idxDic.Add(curStr, i);
                    }
                }

                return answer;
            }
        }
    }
}
