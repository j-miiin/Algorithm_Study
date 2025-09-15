using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmStudy.Baekjoon.Silver3
{
    class NandM5
    {
        static List<int> nums = new List<int>();
        static HashSet<string> result = new HashSet<string>();

        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            int N = int.Parse(str[0]);
            int M = int.Parse(str[1]);

            str = Console.ReadLine().Split(' ');
            for (int i = 0; i < str.Length; i++)
            {
                nums.Add(int.Parse(str[i]));
            }

            nums.Sort();

            ChooseNum(N, M, new List<int>());

            List<string> resultList = result.ToList();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < resultList.Count; i++)
            {
                sb.Append(resultList[i]).Append("\n");
            }

            Console.WriteLine(sb.ToString());
        }

        static void ChooseNum(int N, int M, List<int> numList)
        {
            if (numList.Count == M)
            {
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

            for (int i = 0; i < nums.Count; i++)
            {
                int cur = nums[i];
                if (numList.Contains(cur))
                {
                    continue;
                }
                List<int> newList = numList.ToList();
                newList.Add(cur);
                ChooseNum(N, M, newList);
            }
        }
    }
}
