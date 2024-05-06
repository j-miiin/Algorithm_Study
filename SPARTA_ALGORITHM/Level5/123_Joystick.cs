using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level5
{
    internal class Joystick
    {
        public class Solution
        {
            public int solution(string name)
            {
                char[] origin = name.ToCharArray();
                char[] result = new char[origin.Length];
                for (int i = 0; i < origin.Length; i++) result[i] = 'A';

                int answer = 0;
                int curIdx = 0;
                int up, down;
                while (true)
                {
                    up = origin[curIdx] - 'A';
                    down = 'Z' - origin[curIdx] + 1;
                    answer += Math.Min(up, down);
                    result[curIdx] = origin[curIdx];

                    if (new string(origin).CompareTo(new string(result)) == 0) break;

                    int[] nextChoice = GetNextChoice(curIdx, origin, result);
                    curIdx = nextChoice[0];
                    answer += nextChoice[1];
                }

                return answer;
            }

            static int[] GetNextChoice(int curIdx, char[] origin, char[] result)
            {
                int left = curIdx, right = curIdx;
                int leftCnt = 0, rightCnt = 0;

                while (true)
                {
                    leftCnt++;
                    left--;
                    if (left < 0) left = origin.Length - 1;
                    if (origin[left] != 'A' && origin[left] != result[left]) break;
                }

                while (true)
                {
                    rightCnt++;
                    right++;
                    if (right >= origin.Length) right = 0;
                    if (origin[right] != 'A' && origin[right] != result[right]) break;
                }

                if (rightCnt <= leftCnt) return new int[] { right, rightCnt };
                else return new int[] { left, leftCnt };
            }
        }
    }
}
