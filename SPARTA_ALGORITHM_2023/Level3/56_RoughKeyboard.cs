using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level3
{
    internal class RoughKeyboard
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Solution.solution(new string[] { "ABACD", "BCEFD" }, new string[] { "ABCD", "AABB"})));
        }

        public class Solution
        {
            public static int[] solution(string[] keymap, string[] targets)
            {
                int[] answer = new int[targets.Length];

                for (int i = 0; i < targets.Length; i++)
                {
                    bool isPossible = true;
                    int sum = 0;
                    for (int j = 0; j < targets[i].Length; j++)
                    {
                        int minCnt = int.MaxValue;
                        foreach (string key in keymap)
                        {
                            int cnt = key.IndexOf(targets[i][j]);
                            if (minCnt > cnt && cnt >= 0) minCnt = cnt + 1;
                        }

                        if (minCnt == int.MaxValue)
                        {
                            isPossible = false;
                            break;
                        }
                        else sum += minCnt;
                    }
                    if (isPossible) answer[i] = sum;
                    else
                    {
                        answer[i] = -1;
                        isPossible = true;
                    }
                }

                return answer;
            }
        }
    }
}
