using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level5
{
    internal class NQueen
    {
        public class Solution
        {
            static int[] board;
            static int answer = 0;

            public int solution(int n)
            {
                board = new int[n];

                Dfs(0, n);

                return answer;
            }

            static void Dfs(int idx, int n)
            {
                if (idx >= n)
                {
                    answer++;
                    return;
                }

                for (int i = 0; i < n; i++)
                {
                    board[idx] = i;

                    if (IsPossiblePoint(idx))
                        Dfs(idx + 1, n);
                }
            }

            static bool IsPossiblePoint(int idx)
            {
                for (int i = 0; i < idx; i++)
                {
                    if (board[i] == board[idx]) return false;
                    if (Math.Abs(i - idx) == Math.Abs(board[i] - board[idx])) return false;
                }
                return true;
            }
        }
    }
}
