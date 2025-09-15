using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmStudy.Baekjoon.Silver3
{
    class NandM4
    {
        static HashSet<string> result = new HashSet<string>();

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            int N = int.Parse(str[0]);
            int M = int.Parse(str[1]);

            ChooseNum(N, M, 1, new List<int>());

            List<string> resultList = result.ToList();
            resultList.Sort();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < resultList.Count; i++)
            {
                sb.Append(resultList[i]).Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }

        static void ChooseNum(int N, int M, int start, List<int> numList)
        {
            if (numList.Count == M)
            {
                numList.Sort();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < numList.Count; i++)
                {
                    sb.Append(numList[i]);
                    if (i != numList.Count - 1)
                        sb.Append(" ");
                }

                result.Add(sb.ToString());

                return;
            }

            for (int i = start; i <= N; i++)
            {
                List<int> newList = numList.ToList();
                newList.Add(i);
                ChooseNum(N, M, i, newList);
            }
        }
    }
}
