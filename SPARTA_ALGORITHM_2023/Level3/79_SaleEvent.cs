using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class SaleEvent
    {
        public class Solution
        {
            public int solution(string[] want, int[] number, string[] discount)
            {
                int answer = 0;

                Dictionary<string, int> wantDic = new Dictionary<string, int>();
                for (int i = 0; i < want.Length; i++)
                {
                    wantDic.Add(want[i], number[i]);
                }

                for (int i = 0; i <= discount.Length - 10; i++)
                {
                    Dictionary<string, int> cntDic = new Dictionary<string, int>();
                    for (int j = i; j < i + 10; j++)
                    {
                        string cur = discount[j];
                        if (!cntDic.ContainsKey(cur)) cntDic.Add(cur, 1);
                        else cntDic[cur]++;
                    }

                    bool isPossible = true;
                    foreach (KeyValuePair<string, int> entry in wantDic)
                    {
                        if (!cntDic.ContainsKey(entry.Key) || cntDic[entry.Key] < entry.Value)
                        {
                            isPossible = false;
                            break;
                        }
                    }

                    if (isPossible) answer++;
                }

                return answer;
            }
        }
    }
}
