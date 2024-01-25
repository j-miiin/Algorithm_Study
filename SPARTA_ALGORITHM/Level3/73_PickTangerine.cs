using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class PickTangerine
    {
        public class Solution
        {
            public int solution(int k, int[] tangerine)
            {
                Dictionary<int, int> mandarinDic = new Dictionary<int, int>();
                foreach (int i in tangerine)
                {
                    if (!mandarinDic.ContainsKey(i)) mandarinDic.Add(i, 1);
                    else mandarinDic[i]++;
                }

                List<int> mandarinList = mandarinDic.Values.ToList();
                mandarinList.Sort();
                mandarinList.Reverse();

                int idx = 0;
                int count = k;
                while (count > 0)
                {
                    if (mandarinList[idx] != 0)
                    {
                        mandarinList[idx]--;
                        count--;
                    }
                    else
                    {
                        idx++;
                    }
                }

                int answer = idx + 1;
                return answer;
            }
        }
    }
}
