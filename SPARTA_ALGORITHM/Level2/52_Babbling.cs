using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class Babbling
    {
        public class Solution
        {
            public int solution(string[] babbling)
            {
                int answer = 0;
                string[] possibleStr = { "aya", "ye", "woo", "ma" };

                foreach (string str in babbling)
                {
                    bool isPossible = true;
                    string curStr = "";
                    string prevStr = "";
                    for (int i = 0; i < str.Length; i++)
                    {
                        curStr += str[i];
                        if (curStr.Length > 3)
                        {
                            isPossible = false;
                            break;
                        }

                        if (possibleStr.Contains(curStr))
                        {
                            if (curStr != prevStr)
                            {
                                prevStr = curStr;
                                curStr = "";
                            }
                            else
                            {
                                isPossible = false;
                                break;
                            }
                        }
                        else if (!possibleStr.Contains(curStr) && i == str.Length - 1) isPossible = false;
                    }
                    if (isPossible) answer++;
                }
                return answer;
            }
        }
    }
}
