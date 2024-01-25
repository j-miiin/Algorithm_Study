using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class LottoRank
    {
        public class Solution
        {
            public int[] solution(int[] lottos, int[] win_nums)
            {
                int[] answer = new int[2];

                int maxCount = 0;
                int zeroCount = 0;
                foreach(int i in lottos)
                {
                    if (i == 0) zeroCount++;
                    else if (win_nums.Contains(i)) maxCount++;
                }

                int minScore = maxCount;
                int maxScore = maxCount + zeroCount;

                answer[0] = (maxScore < 2) ? 6 : 6 - maxScore + 1;
                answer[1] = (minScore < 2) ? 6 : 6 - minScore + 1;

                return answer;
            }
        }
    }
}
