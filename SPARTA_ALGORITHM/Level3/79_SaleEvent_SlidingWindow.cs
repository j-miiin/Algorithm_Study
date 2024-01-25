using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class SaleEvent_SlidingWindow
    {
        static Dictionary<string, int> wantDic;
        static Dictionary<string, int> curDic;
        public int solution(string[] want, int[] number, string[] discount)
        {
            int answer = 0;

            InitDic(want, number);

            for (int i = 0; i < 10; i++)
            {
                if (!curDic.ContainsKey(discount[i])) curDic.Add(discount[i], 1);
                else curDic[discount[i]]++;
            }

            if (IsPossible()) answer++;

            for (int i = 0, j = 10; j < discount.Length; i++, j++)
            {
                curDic[discount[i]]--;
                if (!curDic.ContainsKey(discount[j])) curDic.Add(discount[j], 1);
                else curDic[discount[j]]++;

                if (IsPossible()) answer++;
            }

            return answer;
        }

        static void InitDic(string[] want, int[] number)
        {
            wantDic = new Dictionary<string, int>();
            curDic = new Dictionary<string, int>();

            for (int i = 0; i < want.Length; i++)
            {
                wantDic.Add(want[i], number[i]);
                curDic.Add(want[i], 0);
            }
        }

        static bool IsPossible()
        {
            foreach (string key in wantDic.Keys)
            {
                if (wantDic[key] > curDic[key]) return false;
            }
            return true;
        }
    }
}
