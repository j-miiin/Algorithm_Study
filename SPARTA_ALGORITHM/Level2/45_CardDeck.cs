using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class CardDeck
    {
        public class Solution
        {
            public string solution(string[] cards1, string[] cards2, string[] goal)
            {
                bool isPossible = true;
                int idx1 = 0, idx2 = 0;
                for (int i = 0; i < goal.Length; i++)
                {
                    if (idx1 < cards1.Length && goal[i] == cards1[idx1]) idx1++;
                    else if (idx2 < cards2.Length && goal[i] == cards2[idx2]) idx2++;
                    else
                    {
                        isPossible = false;
                        break;
                    }
                }

                string answer = isPossible ? "Yes" : "No";
                return answer;
            }
        }
    }
}
