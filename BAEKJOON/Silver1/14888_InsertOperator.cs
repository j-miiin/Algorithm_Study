using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver1
{
    internal class InsertOperator
    {
        static int totalOperatorNum = 0;

        static int[] number;
        static int[] operators;

        static int minResult = int.MaxValue;
        static int maxResult = int.MinValue;

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            number = new int[N];

            string[] str = Console.ReadLine().Split(" ");
            for (int i = 0; i < N; i++)
            {
                number[i] = int.Parse(str[i]);
            }

            operators = new int[4];
            str = Console.ReadLine().Split(" ");
            for (int i = 0; i < 4; i++)
            {
                operators[i] = int.Parse(str[i]);
                totalOperatorNum += operators[i];
            }

            MakeOperation(new List<int>());

            Console.WriteLine(maxResult + "\n" + minResult);
        }

        static void MakeOperation(List<int> operatorList)
        {
            if (operatorList.Count == totalOperatorNum)
            {
                int result = GetResult(operatorList);
                minResult = Math.Min(minResult, result);
                maxResult = Math.Max(maxResult, result);
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                if (operators[i] == 0)
                {
                    continue;
                }

                operators[i]--;
                operatorList.Add(i);
                MakeOperation(operatorList);
                operators[i]++;
                operatorList.RemoveAt(operatorList.Count - 1);
            }
        }

        static int GetResult(List<int> operatorList)
        {
            int cur = number[0];
            int idx = 1;
            for (int i = 0; i < operatorList.Count; i++)
            {
                if (operatorList[i] == 0)
                {
                    cur += number[idx++];
                } else if (operatorList[i] == 1)
                {
                    cur -= number[idx++];
                }
                else if (operatorList[i] == 2)
                {
                    cur *= number[idx++];
                } else
                {
                    cur /= number[idx++];
                }
            }

            return cur;
        }
    }
}
