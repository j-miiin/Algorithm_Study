using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class DecreasingNum
    {
        static StringBuilder sb = new StringBuilder();  
        static HashSet<long> nums = new HashSet<long>();

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < 10; i++)
            {
                MakeNum(new List<long> { i });
            }

            List<long> sortedList = nums.ToList();
            sortedList.Sort();

            Console.WriteLine((N < sortedList.Count) ? sortedList[N] : -1);
        }

        static void MakeNum(List<long> curNums)
        {
            sb.Clear();
            for (int i = 0; i < curNums.Count; i++)
            {
                sb.Append(curNums[i]);
            }

            long result = long.Parse(sb.ToString());
            nums.Add(result);

            for (int i = 0; i < 10; i++)
            {
                long last = curNums[curNums.Count - 1];

                if (i < last)
                {
                    List<long> newNums = curNums.ToList();
                    newNums.Add(i);
                    MakeNum(newNums);
                }
            }
        }
    }
}
