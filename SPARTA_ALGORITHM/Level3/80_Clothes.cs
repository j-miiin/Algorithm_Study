using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class Clothes
    {
        public class Solution
        {
            public int solution(string[,] clothes)
            {
                Dictionary<string, List<string>> clothesDic = new Dictionary<string, List<string>>();
                for (int i = 0; i < clothes.GetLength(0); i++)
                {
                    string key = clothes[i, 1];
                    string value = clothes[i, 0];

                    if (!clothesDic.ContainsKey(key))
                    {
                        clothesDic.Add(key, new List<string>());
                    } 
                    clothesDic[key].Add(value);
                }

                int comb = 1;
                foreach (string key in clothesDic.Keys)
                {
                    comb *= clothesDic[key].Count + 1;
                }

                int answer = comb - 1;
                return answer;
            }
        }
    }
}
