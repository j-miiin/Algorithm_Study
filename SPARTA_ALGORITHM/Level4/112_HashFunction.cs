using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class HashFunction
    {
        public class Solution
        {
            public int solution(int[,] data, int col, int row_begin, int row_end)
            {
                List<List<int>> dataList = new List<List<int>>();
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    dataList.Add(new List<int>());
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        dataList[i].Add(data[i, j]);
                    }
                }

                dataList.Sort((list1, list2) =>
                {
                    if (list1[col - 1] < list2[col - 1]) return -1;
                    else if (list1[col - 1] > list2[col - 1]) return 1;
                    else
                    {
                        if (list1[0] < list2[0]) return 1;
                        else if (list1[0] == list2[0]) return 0;
                        else return -1;
                    }
                });

                int answer = -1;
                for (int i = row_begin - 1; i < row_end; i++)
                {
                    int num = 0;
                    for (int j = 0; j < dataList[i].Count; j++)
                    {
                        num += (dataList[i][j] % (i + 1));
                    }
                    if (answer == -1) answer = num;
                    else answer = answer ^ num;
                }

                return answer;
            }
        }
    }
}
