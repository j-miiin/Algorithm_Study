using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class CoordinateCompression
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[] nums = new int[N];
            HashSet<int> numSet = new HashSet<int>();
            Dictionary<int, int> pressedValueDic = new Dictionary<int, int>();
            string[] str = Console.ReadLine().Split(" ");
            for (int i = 0; i < N; i++)
            {
                nums[i] = int.Parse(str[i]);
                numSet.Add(nums[i]);
            }

            List<int> setList = numSet.ToList();
            setList.Sort((n1, n2) => { return n2 - n1; });

            for (int i = 0; i < setList.Count; i++)
            {
                pressedValueDic.Add(setList[i], setList.Count - i - 1);
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < nums.Length; i++)
            {
                sb.Append(pressedValueDic[nums[i]]).Append(" ");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
