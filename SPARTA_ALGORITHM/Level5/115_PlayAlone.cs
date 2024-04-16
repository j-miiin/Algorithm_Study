using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level5
{
    internal class PlayAlone
    {
        public class Solution
        {
            static int num;
            static bool[] isOpen;
            public int solution(int[] cards)
            {
                int answer = 0;
                num = cards.Length;
                isOpen = new bool[num];

                for (int i = 0; i < num; i++)
                {
                    int result1 = OpenBox(i, cards);
                    if (result1 == num) break;
                    for (int j = 0; j < num; j++)
                    {
                        if (isOpen[j]) continue;
                        int result2 = OpenBox(j, cards);
                        answer = Math.Max(answer, result1 * result2);
                    }
                    isOpen = new bool[num];
                }

                return answer;
            }

            static int OpenBox(int start, int[] box)
            {
                int count = 0;
                int idx = start;
                while (count <= num)
                {
                    isOpen[idx] = true;
                    count++;
                    idx = box[idx] - 1;
                    if (isOpen[idx]) break;
                }
                return count;
            }
        }
    }
}
