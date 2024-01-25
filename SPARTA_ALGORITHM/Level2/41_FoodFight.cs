using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class FoodFight
    {
        public class Solution
        {
            public string solution(int[] food)
            {
                string firstStr = "";
                for (int i = 1; i < food.Length; i++)
                {
                    int foodNum = food[i] / 2;
                    for (int j = 0; j < foodNum; j++) firstStr += i;
                }

                string answer = firstStr + "0" + new string(firstStr.Reverse().ToArray());
                return answer;
            }
        }
    }
}
