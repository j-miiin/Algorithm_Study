using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class ConvertNum
    {
        public class Solution
        {
            static int result;
            public int solution(int x, int y, int n)
            {
                result = -1;

                bfs(x, y, n);

                int answer = result;
                return answer;
            }

            static void bfs(int x, int y, int n)
            {
                Queue<int[]> queue = new Queue<int[]>();
                HashSet<int> set = new HashSet<int>();

                queue.Enqueue(new int[] { x, 0 });

                while (queue.Count > 0)
                {
                    int[] cur = queue.Dequeue();
                    int curNum = cur[0];
                    int curCnt = cur[1];

                    if (curNum == y)
                    {
                        result = curCnt;
                        return;
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        int nextNum = 0;
                        switch (i)
                        {
                            case 0: nextNum = curNum + n; break;
                            case 1: nextNum = curNum * 2; break;
                            case 2: nextNum = curNum* 3; break;
                        }

                        if (nextNum <= y && !set.Contains(nextNum))
                        {
                            queue.Enqueue(new int[] { nextNum, curCnt + 1 });
                            set.Add(nextNum);
                        }
                    }
                }
            }
        }
    }
}
