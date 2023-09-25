using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class Process
    {
        public class Solution
        {
            public int solution(int[] priorities, int location)
            {
                Queue<int[]> queue = new Queue<int[]>();

                for (int i = 0; i < priorities.Length; i++)
                {
                    queue.Enqueue(new int[] {i, priorities[i]});
                }

                int answer = 0;

                while (queue.Count > 0)
                {
                    int maxPriority = GetMaxPriority(queue);

                    int[] curProcess = queue.Dequeue();
                    int processNum = curProcess[0];
                    int processPriority = curProcess[1];

                    if (maxPriority != processPriority) queue.Enqueue(curProcess);
                    else
                    {
                        answer++;
                        if (processNum == location) break;
                    }
                }

                return answer;
            }

            static int GetMaxPriority(Queue<int[]> queue)
            {
                int max = 0;
                foreach (int[] process in queue)
                {
                    if (process[1] > max) max = process[1];
                }
                return max;
            }
        }
    }
}
