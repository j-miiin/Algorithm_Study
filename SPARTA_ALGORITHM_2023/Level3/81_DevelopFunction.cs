using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class DevelopFunction
    {
        public class Solution
        {
            public int[] solution(int[] progresses, int[] speeds)
            {
                List<int> result = new List<int>();
                int max = 0;
                int count = 0;
                for (int i = 0; i < progresses.Length; i++)
                {
                    progresses[i] = GetRemainingDay(progresses[i], speeds[i]);
                    if (i == 0) max = progresses[i];
                    if (progresses[i] > max)
                    {
                        max = progresses[i];
                        result.Add(count);
                        count = 1;
                    } else {
                        count++;
                    }
                }
                result.Add(count);

                int[] answer = result.ToArray();
                return answer;
            }

            static int GetRemainingDay(int progress, int speed)
            {
                int count = 0;
                while (progress < 100)
                {
                    progress += speed;
                    count++;
                }
                return count;
            }
        }
    }
}
