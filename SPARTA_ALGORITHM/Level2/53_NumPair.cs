using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class NumPair
    {
        public class Solution
        {
            public string solution(string X, string Y)
            {
                string answer = "";

                int[] numCountX = new int[10];
                int[] numCountY = new int[10];

                for (int i = 0; i < X.Length; i++)
                {
                    int curStrNum = int.Parse(X[i] + "");
                    numCountX[curStrNum]++;
                }

                for (int i = 0; i < Y.Length; i++)
                {
                    int curStrNum = int.Parse(Y[i] + "");
                    numCountY[curStrNum]++;
                }

                List<int> resultNumList = new List<int>();
                for (int i = 0; i < 10; i++)
                {
                    int curCnt = (numCountX[i] < numCountY[i]) ? numCountX[i] : numCountY[i];
                    for (int j = 0; j < curCnt; j++) resultNumList.Add(i);
                }
                resultNumList.Sort();
                resultNumList.Reverse();

                StringBuilder sb = new StringBuilder();
                if (resultNumList.Count == 0) sb.Append("-1");
                else foreach (int i in resultNumList) sb.Append(i);

                answer = sb.ToString();
                if (answer[0] == '0') answer = "0";

                return answer;
            }
        }
    }
}
