using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class HallOfFame
    {
        public class Solution
        {
            public int[] solution(int k, int[] score)
            {
                int[] answer = new int[score.Length];

                List<int> sortedScoreList = new List<int>();
                for (int i = 0; i < score.Length; i++)
                {
                    sortedScoreList.Add(score[i]);
                    sortedScoreList.Sort();
                    sortedScoreList.Reverse();
                    if (i < k) answer[i] = sortedScoreList.Min();
                    else answer[i] = sortedScoreList[k - 1];
                }

                return answer;
            }
        }
    }
}
