using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class SameSumOfQueue
    {
        public class Solution
        {
            public int solution(int[] queue1, int[] queue2)
            {
                Queue<int> q1 = new Queue<int>();
                Queue<int> q2 = new Queue<int>();

                long sum1 = 0, sum2 = 0;
                for (int i = 0; i < queue1.Length; i++)
                {
                    q1.Enqueue(queue1[i]);
                    sum1 += queue1[i];
                }

                for (int i = 0; i < queue2.Length; i++)
                {
                    q2.Enqueue(queue2[i]);
                    sum2 += queue2[i];
                }

                if ((sum1 + sum2) % 2 != 0) return -1;

                int limit = queue1.Length * 3;

                int answer = 0;
                while (answer <= limit)
                {
                    if (sum1 == sum2) break;
                    if (q1.Count == 0 || q2.Count == 0)
                    {
                        answer = -1;
                        break;
                    }

                    if (sum1 < sum2)
                    {
                        int tmp = q1.Dequeue();
                        q2.Enqueue(tmp);
                        sum1 -= tmp;
                        sum2 += tmp;
                    } else if (sum1 > sum2)
                    {
                        int tmp = q2.Dequeue();
                        q1.Enqueue(tmp);
                        sum1 += tmp;
                        sum2 -= tmp;
                    }

                    answer++;
                }                

                if (answer > limit) answer = -1;
                return answer;
            }
        }
    }
}
