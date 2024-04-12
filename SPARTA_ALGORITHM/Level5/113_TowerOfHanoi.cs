using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level5
{
    internal class TowerOfHanoi
    {
        public class Solution
        {
            static int idx = 0;
            static int[,] answer;

            public int[,] solution(int n)
            {
                int hanoiNum = 1;
                for (int i = 2; i <= n; i++)
                    hanoiNum = 2 * hanoiNum + 1;
                answer = new int[hanoiNum, 2];
                Hanoi(n, 1, 3, 2);
                return answer;
            }

            static void Hanoi(int n, int start, int end, int mid)
            {
                if (n == 1)
                {
                    answer[idx, 0] = start;
                    answer[idx, 1] = end;
                    idx++;
                    return;
                }

                Hanoi(n - 1, start, mid, end);
                answer[idx, 0] = start;
                answer[idx, 1] = end;
                idx++;
                Hanoi(n - 1, mid, end, start);
            }
        }
    }
}
