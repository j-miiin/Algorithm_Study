using System;
using System.Collections.Generic;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level5
{
    internal class InterceptionSystem
    {
        public class Solution
        {
            public int solution(int[,] targets)
            {
                List<int[]> targetList = new List<int[]>();
                for (int i = 0; i < targets.GetLength(0); i++)
                {
                    targetList.Add(new int[] { targets[i, 0], targets[i, 1] });
                }

                targetList.Sort((int[] t1, int[] t2) =>
                {
                    return t1[1] - t2[1];
                });

                int curMissile = 0;
                int answer = 0;

                for (int i = 0; i < targetList.Count; i++)
                {
                    if (curMissile > targetList[i][0])
                    {
                        continue;
                    }

                    curMissile = targetList[i][1];
                    answer++;
                }

                return answer;
            }
        }
    }
}
